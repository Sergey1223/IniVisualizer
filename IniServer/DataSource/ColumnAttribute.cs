using System;

namespace IniServer.Repository
{
    internal class ColumnAttribute : Attribute
    {
        internal int Index { get; }

        internal bool HasIndexTable { get; }

        internal ColumnAttribute(int index, bool hasIndexTable)
        {
            Index = index;
            HasIndexTable = hasIndexTable;
        }
    }
}
