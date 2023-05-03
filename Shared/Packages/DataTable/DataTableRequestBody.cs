using System;
using System.Windows.Forms;

namespace IniVisualizer.Shared.Packages
{
    public class DataTableRequestBody : IBody
    {
        public int Offset { get; private set; }

        public byte Count { get; private set; }

        public byte SortColumnIndex { get; private set; }

        public SortOrder SortOrder { get; private set; }

        public DataTableRequestBody() { }

        public DataTableRequestBody(int offset, int count, int sortColumnIndex, SortOrder sortOrder)
        {
            Offset = offset;
            Count = (byte)count;
            SortColumnIndex = (byte)sortColumnIndex;
            SortOrder = sortOrder;
        }

        public void SetOffset(byte[] sequence)
        {
            if (sequence != null && sequence.Length == sizeof(int))
            {
                Offset = BitConverter.ToInt32(sequence, 0);
            }
        }

        public void SetCount(byte[] sequence) {
            if (sequence != null && sequence.Length == 1)
            {
                Count = sequence[0];
            }
        }

        public void SetSortColumnIndex(byte[] sequence) {
            if (sequence != null && sequence.Length == 1)
            {
                SortColumnIndex = sequence[0];
            }
        }

        public void SetSortOrder(byte[] sequence) {
            if (sequence != null && sequence.Length == 1)
            {
                SortOrder = (SortOrder)sequence[0];
            }
        }
    }
}
