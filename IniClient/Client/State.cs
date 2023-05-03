using System.Windows.Forms;

namespace IniClient
{
    internal class State
    {
        internal int Offset { get;  }

        internal int Count { get; }

        internal int SortColumnIndex { get; }

        internal SortOrder SortOrder { get; }

        public State(int offset, int count, int sortColumnIndex, SortOrder sortOrder)
        {
            Offset = offset;
            Count = count;
            SortColumnIndex = sortColumnIndex;
            SortOrder = sortOrder;
        }
    }
}
