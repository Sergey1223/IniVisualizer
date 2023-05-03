using System;
using System.Collections.Generic;
using System.Text;

namespace IniVisualizer.Shared.Packages
{
    /// <summary>
    /// Represents response package.
    /// Raw input data example:
    ///     "150{Row1Value1:Row1Value2:Row1Value:}{Row2Value4:Row2Value5:Row2Value6}"
    /// </summary>
    public class DataTableResponsePackage : Package<DataTableResponseBody>
    {
        public const byte TYPE = 0xFC;

        private const byte ROW_START_MARKER = 0x7B;     // {
        private const byte ROW_END_MARKER = 0x7D;       // }
        private const byte VALUE_DELIMETER = 0x3A;      // :
        private const int FRAME_OFFSET = 4;

        public DataTableResponsePackage(byte[] sequence) :
            base(TYPE, sequence)
        { }

        public DataTableResponsePackage(DataTableResponseBody body)
            : base(TYPE, body)
        { }

        protected override DataTableResponseBody ParseBody(byte[] sequence)
        {
            if (sequence.Length == 0)
            {
                return null;
            }

            byte[] offsetSequence = new byte[sizeof(int)];

            Array.Copy(sequence, 0, offsetSequence, 0, offsetSequence.Length);

            int offset = BitConverter.ToInt32(offsetSequence, 0);

            List<List<string>> frame = new List<List<string>>(); 
            
            int index = FRAME_OFFSET;
            int valueIndex = 0;
            List<string> row = null;

            while (index < sequence.Length)
            {
                if (sequence[index] == ROW_START_MARKER)
                {
                    row = new List<string>();
                    valueIndex = index + 1;
                    
                    index++;

                    continue;
                }

                if (sequence[index] == VALUE_DELIMETER)
                {
                    row.Add(Encoding.ASCII.GetString(sequence, valueIndex, index - valueIndex));

                    valueIndex = index + 1;

                    index++;

                    continue;
                }

                if (sequence[index] == ROW_END_MARKER)
                {
                    row.Add(Encoding.ASCII.GetString(sequence, valueIndex, index - valueIndex));

                    frame.Add(row);

                    index++;

                    continue;
                }

                index++;
            }

            return new DataTableResponseBody(offset, frame);
        }

        protected override byte[] BodyToBytes(DataTableResponseBody body)
        {
            List<byte> result = new List<byte>();

            // Maximum offset
            result.AddRange(BitConverter.GetBytes(body.TotalCount));

            // Frame
            foreach (List<string> row in body.Frame)
            {
                // Row start marker
                result.Add(ROW_START_MARKER);

                // Values
                for (int i = 0; i < row.Count; i++)
                {
                    result.AddRange(Encoding.ASCII.GetBytes(row[i]));

                    if (i != row.Count - 1)
                    {
                        result.Add(VALUE_DELIMETER);
                    }
                }

                // Row start marker
                result.Add(ROW_END_MARKER);
            }

            return result.ToArray();
        }
    }
}