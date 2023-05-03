using IniServer.DataSource;
using IniServer.DataSource.OperationContext;
using IniServer.Repository.Fields;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IniServer.Repository
{
    internal class GenerableDataSource<T> where T : class, IGenerableEntityModel<T>, new()
    {
        private const char KEY_DELIMETER = '~';
        private const int DEFAULT_CAPACITY = 5000;
        private const int DEFAULT_CAPACITY_DELTA = 100;
        private const int DEFAULT_OPERATIONS_COUNT_PER_CYCLE = 100;
        private const int DEFAULT_INTERVAL = 1000;

        private static readonly Random random = new Random();
        private static readonly OperationType[] operations = (OperationType[])Enum.GetValues(typeof(OperationType));

        private T[] data;
        private int freeSpacePointer;
        private int sortColumnIndex;
        private SortOrder sortOrder;
        private Column[] columns;
        private delegate void OperationHandler(IOperationContext context);

        internal int Capacity { get; }

        internal int CapacityDelta { get; }

        internal int OperationsPerCycle { get; }

        internal int Interval { get; }

        internal bool SimulationIsActive { get; private set; }

        internal int Count { get; private set; }

        public GenerableDataSource(
            int? capacity = null,
            int? capacityDelta = null,
            int? operationsCount = null,
            int? operationTimeout = null,
            int? interval = null)
        {
            if (capacityDelta > capacity)
            {
                throw new ArgumentException("Capacity delta is great than capacity.", nameof(capacityDelta));
            }

            Capacity = capacity.HasValue && capacity > 0 ? capacity.Value : DEFAULT_CAPACITY;
            CapacityDelta = capacityDelta.HasValue && capacityDelta > 0 ? capacityDelta.Value : DEFAULT_CAPACITY_DELTA;
            OperationsPerCycle = operationsCount.HasValue && operationsCount > 0 ? operationsCount.Value : DEFAULT_OPERATIONS_COUNT_PER_CYCLE;
            Interval = interval.HasValue && interval > 0 ? interval.Value : DEFAULT_INTERVAL;

            sortColumnIndex = -1;
        }

        internal void GenerateData()
        {
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where((p) => p.GetCustomAttributes(typeof(ColumnAttribute), false).Count() == 1)
                .ToArray();

            columns = new Column[properties.Length];

            try
            {
                foreach (PropertyInfo property in properties)
                {
                    ColumnAttribute attribute = property.GetCustomAttribute<ColumnAttribute>();
                    IndexTable indexTable = null;

                    if (attribute.HasIndexTable)
                    {
                        indexTable = new IndexTable();
                    }

                    Column column = new Column(attribute.Index, property, indexTable);

                    columns[attribute.Index] = column;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                throw new DataSourceException(
                    "Column attributes is invalid. Inxes must represent continuous sequence and has to start from 0 index.",
                    e);
            }

            int count = Capacity - random.Next(0, CapacityDelta + 1);

            data = new T[Capacity];
            freeSpacePointer = 0;

            for (int i = 0; i < count; i++)
            {
                Add();
            }
        }

        internal void StartSimulation()
        {
            SimulationIsActive = true;

            Task task = Task.Run(Simulate);
        }

        internal void StopSimulation()
        {
            SimulationIsActive = false;
        }

        internal void ClearData()
        {
            if (SimulationIsActive)
            {
                StopSimulation();
            }

            data = null;
        }

        internal List<T> GetRange(int offset, int count)
        {
            GetRangeOperationContext context = new GetRangeOperationContext(offset, count);

            PerformOperation(context, GetRange);

            return (List<T>)context.Result;
        }

        internal void ApplySort(int sortColumnIndex, SortOrder sortOrder)
        {
            this.sortColumnIndex = sortColumnIndex;
            this.sortOrder = sortOrder;
        }

        private void Simulate()
        {
            while (SimulationIsActive)
            {
                RegenerateData();

                Thread.Sleep(Interval);
            }

            Console.WriteLine("Closed");
        }

        private void RegenerateData()
        {
            for (int i = 0; i < OperationsPerCycle; i++)
            {
                OperationType operationType = (OperationType)random.Next(operations.Length);

                switch (operationType)
                {
                    case OperationType.Add:
                        if (CanAdd())
                        {
                            SimulateAdding();
                        }
                        else
                        {
                            i--;
                        }

                        break;
                    case OperationType.Remove:
                        if (CanDelete())
                        {
                            SimulateDeleting();
                        }
                        else
                        {
                            i--;
                        }

                        break;
                    case OperationType.Update:
                        SimulateUpdating();

                        break;
                }
            }
        }

        private void SimulateAdding()
        {
            if (freeSpacePointer > 0)
            {
                PerformOperation(new AddOperationContext(), Add);
            }
        }

        private void SimulateDeleting()
        {
            int index = FindFirst(random.Next(data.Length));

            if (index > 0)
            {
                PerformOperation(new DeleteOperationContext(index), Delete);
            }
        }

        private void SimulateUpdating()
        {
            int index = FindFirst(random.Next(data.Length));

            if (index > 0)
            {
                PerformOperation(new UpdateOperationContext(index), Update);
            }
        }

        private void Add(IOperationContext context = null)
        {
            Random randomReferance = random;
            
            T entity = new T
            {
                Id = Guid.NewGuid()
            };

            entity.GenerateFields(ref randomReferance);

            CreateIndexes(entity, freeSpacePointer);

            data[freeSpacePointer] = entity;

            UpdateFreeSpacePointer();
            
            Count++;
        }

        private void Delete(IOperationContext context)
        {
            DeleteOperationContext deletingContext = (DeleteOperationContext)context;

            DeleteIndexes(data[deletingContext.Index]);

            data[deletingContext.Index] = null;

            UpdateFreeSpacePointer(deletingContext.Index);

            Count--;
        }

        private void Update(IOperationContext context)
        {
            UpdateOperationContext updatingContext = (UpdateOperationContext)context;
            Random randomReference = random;
            T entity = data[updatingContext.Index];

            DeleteIndexes(entity);

            entity.RegenerateFields(ref randomReference);

            CreateIndexes(entity, updatingContext.Index);
        }

        private void GetRange(IOperationContext context)
        {
            GetRangeOperationContext getRangeContext = (GetRangeOperationContext)context;
            int offset = getRangeContext.Offset;

            // Offset outside of the upper bound
            if (getRangeContext.Offset > Count - getRangeContext.Count)
            {
                offset = Count - getRangeContext.Count;
            }

            // Offset outside of the lower bound
            if (offset < 0)
            {
                offset = 0;
            }

            // Applying sort
            if (sortColumnIndex >= 0 && sortOrder != SortOrder.None)
            {
                IndexTable indexTable = columns[sortColumnIndex].IndexTable;

                if (indexTable != null)
                {
                    IEnumerable<int> indexes = indexTable.GetRange(offset, getRangeContext.Count, sortOrder);

                    getRangeContext.Result = indexes
                        .Select((i) => data[i])
                        .ToList();

                    return;
                }
                else
                {
                    PropertyInfo property = columns[sortColumnIndex].ModelProperty;
                    IEnumerable<T> sortedData = null;

                    switch (sortOrder)
                    {
                        case SortOrder.Ascending:
                            sortedData = data.OrderBy((e) => ((Field)property.GetValue(e)).Value);

                            break;
                                
                        case SortOrder.Descending:
                            sortedData = data.OrderByDescending((e) => ((Field)property.GetValue(e)).Value);

                            break;
                        default:
                            sortedData = data;

                            break;
                    }

                    getRangeContext.Result = sortedData
                        .Skip(getRangeContext.Offset)
                        .Take(getRangeContext.Count)
                        .ToList();

                    return;
                }
            }

            getRangeContext.Result = GetUnsortedRange(getRangeContext.Offset, getRangeContext.Count);
        }

        private List<T> GetUnsortedRange(int offset, int count)
        {
            List<T> result = new List<T>(count);

            int index;
            if (offset < freeSpacePointer)
            {
                index = offset;
            }
            else
            {
                index = FindFirst(freeSpacePointer);

                int delta = offset - index + 1;

                index++;

                while (delta > 0 && index < data.Length)
                {
                    if (data[index] != null)
                    {
                        delta--;
                    }

                    index++;
                }
            }

            while (index < data.Length && result.Count < count)
            {
                if (data[index] != null)
                {
                    result.Add(data[index]);
                }

                index++;
            }

            return result;
        }

        private void PerformOperation(IOperationContext context, OperationHandler handler)
        {
            lock (data)
            {
                handler.Invoke(context);
            }
        }

        private bool CanAdd()
        {
            return Count < Capacity;
        }

        private bool CanDelete()
        {
            return Count > Capacity - CapacityDelta;
        }

        private int FindFirst(int startIndex)
        {
            for (int i = startIndex; i < data.Length; i++)
            {
                if (data[i] != null)
                {
                    return i;
                }
            }

            return -1;
        }

        private void UpdateFreeSpacePointer()
        {
            for (int i = freeSpacePointer; i < data.Length; i++)
            {
                if (data[i] == null)
                {
                    freeSpacePointer = i;

                    break;
                }
            }
        }

        private void UpdateFreeSpacePointer(int index)
        {
            if (freeSpacePointer > index)
            {
                freeSpacePointer = index;
            }
        }

        private string CreateIndexKey(T entity, Column column)
        {
            return column.ModelProperty.GetValue(entity).ToString() + KEY_DELIMETER + entity.Id;
        }

        private void CreateIndexes(T entity, int index)
        {
            foreach (Column column in columns)
            {
                if (column.IndexTable != null)
                {
                    column.IndexTable.Add(CreateIndexKey(entity, column), index);
                }
            }
        }

        private void DeleteIndexes(T entity)
        {
            foreach (Column column in columns)
            {
                if (column.IndexTable != null)
                {
                    column.IndexTable.Delete(CreateIndexKey(entity, column));
                }
            }
        }
    }
}
