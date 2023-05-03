using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IniVisualizer.Shared.Packages
{
    public class DataTableRequestPackage : Package<DataTableRequestBody>
    {
        public const byte TYPE = 0xFD;

        private const byte VALUE_DELIMETER = 0x3A;      // :
        private const byte PROPERTY_DELIMETER = 0x26;   // &
        private const string SETTER_PREFIX = "Set";

        public DataTableRequestPackage(byte[] sequence) :
            base(TYPE, sequence)
        { }

        public DataTableRequestPackage(DataTableRequestBody body)
            : base(TYPE, body)
        { }

        protected override DataTableRequestBody ParseBody(byte[] sequence)
        {
            if (sequence.Length == 0)
            {
                return null;
            }

            DataTableRequestBody body = new DataTableRequestBody();
            string propertyName = null;
            int pointer = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == VALUE_DELIMETER) {
                    propertyName = Encoding.ASCII.GetString(sequence, pointer, i - pointer);

                    pointer = i + 1;
                }

                if (sequence[i] == PROPERTY_DELIMETER || i == sequence.Length - 1)
                {
                    int count = (i == sequence.Length - 1) ? i - pointer + 1 : i - pointer;
                    byte[] value = new byte[count];

                    Array.Copy(sequence, pointer, value, 0, count);

                    WriteProperty(body, propertyName, value);

                    pointer = i + 1;
                }
            }

            return body;
        }

        protected override byte[] BodyToBytes(DataTableRequestBody body)
        {
            byte[] offsetPropertyName = Encoding.ASCII.GetBytes(nameof(body.Offset));
            byte[] countPropertyName = Encoding.ASCII.GetBytes(nameof(body.Count));
            byte[] sortColumnIndexPropertyName = Encoding.ASCII.GetBytes(nameof(body.SortColumnIndex));
            byte[] sortOrderPropertyName = Encoding.ASCII.GetBytes(nameof(body.SortOrder));

            List<byte> result = new List<byte>();

            // Offset property
            result.AddRange(offsetPropertyName);
            result.Add(VALUE_DELIMETER);
            result.AddRange(BitConverter.GetBytes(body.Offset));

            result.Add(PROPERTY_DELIMETER);

            // Count property
            result.AddRange(countPropertyName);
            result.Add(VALUE_DELIMETER);
            result.Add(body.Count);

            result.Add(PROPERTY_DELIMETER);

            // Sort column index property
            result.AddRange(sortColumnIndexPropertyName);
            result.Add(VALUE_DELIMETER);
            result.Add(body.SortColumnIndex);

            result.Add(PROPERTY_DELIMETER);

            // Sort order property
            result.AddRange(sortOrderPropertyName);
            result.Add(VALUE_DELIMETER);
            result.Add((byte)body.SortOrder);

            return result.ToArray();
        }

        private static void WriteProperty(DataTableRequestBody body, string name, byte[] value)
        {
            MethodInfo methodInfo = body.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where((p) => p.Name.Equals(SETTER_PREFIX + name))
                .FirstOrDefault();

            if (methodInfo != null)
            {
                methodInfo.Invoke(body, new object[] { value });
            }
        }
    }
}
