using System.Reflection;

namespace IniServer.DataSource
{
    internal class Column
    {
        internal int Index { get; }

        internal PropertyInfo ModelProperty { get; }

        internal IndexTable IndexTable { get; }

        public Column(int index, PropertyInfo modelProperty, IndexTable indexTable)
        {
            Index = index;
            ModelProperty = modelProperty;
            IndexTable = indexTable;
        }
    }
}
