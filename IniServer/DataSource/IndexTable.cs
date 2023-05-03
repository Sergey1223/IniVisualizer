using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IniServer.DataSource
{
    internal class IndexTable
    {
        private readonly SortedList<string, int> data;

        internal IndexTable()
        {
            data = new SortedList<string, int>();
        }

        internal void Add(string key, int index)
        {
            data.Add(key, index);
        }

        internal void Delete(string key)
        {
            data.Remove(key);
        }

        internal IEnumerable<int> GetRange(int offset, int count, SortOrder sortOrder)
        {
            int leftPartitionCount = offset;
            int rightPartitionCount =  data.Count - (leftPartitionCount + count);

            if (rightPartitionCount < 0)
            {
                count = data.Count - leftPartitionCount;
                rightPartitionCount = 0;
            }

            if (sortOrder == SortOrder.Ascending)
            {
                // Range closer to left side (collection start)
                if (leftPartitionCount < rightPartitionCount)
                {
                    return data
                        .Values
                        .Skip(leftPartitionCount)
                        .Take(count);
                }
                // Range closer to right side (collection end)
                else
                {
                    return data
                        .Values
                        .Reverse()
                        .Skip(rightPartitionCount)
                        .Take(count)
                        .Reverse();
                }
            }
            
            if (sortOrder == SortOrder.Descending)
            {
                // Range closer to left side (collection end)
                if (leftPartitionCount < rightPartitionCount)
                {
                    return data
                        .Values
                        .Reverse()
                        .Skip(leftPartitionCount)
                        .Take(count)
                        .Reverse();
                }
                // Range closer to right side (collection start)
                else
                {
                    return data
                        .Values
                        .Skip(rightPartitionCount)
                        .Take(count);
                }
            }

            return null;
        }
    }
}
