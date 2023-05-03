using Shared.Packages;
using System;

namespace IniVisualizer.Shared.Packages
{
    public abstract class Package<T> where T : IBody, new()
    {
        public byte StartMarker { get; }

        public byte EndMarker { get; }

        public byte Type { get; }

        public byte[] RawBody { get; private set; }

        public T Body { get; private set; }

        public ushort DataLength
        {
            get
            {
                if (RawBody == null)
                {
                    return 0;
                }

                return (ushort)RawBody.Length;
            }
        }

        public byte[] ToBytes()
        {
            // Start marker + type + data lenth + data + end marker.
            int length = 1 + 1 + 2 + RawBody.Length + 1;

            byte[] result = new byte[length];

            result[0] = StartMarker;
            result[Constants.PACKAGE_TYPE_OFFSET] = Type;

            byte[] dataLength = BitConverter.GetBytes(DataLength);
            Array.Copy(dataLength, 0, result, Constants.DATA_LENGTH_OFFSET, sizeof(short));

            Array.Copy(RawBody, 0, result, Constants.DATA_OFFSET, RawBody.Length);

            result[result.Length - 1] = EndMarker;

            return result;
        }

        protected Package(byte type, byte[] sequence)
        {
            StartMarker = Constants.PACKAGE_START_MARKER;
            EndMarker = Constants.PACKAGE_END_MARKER;
            Type = type;

            Parse(sequence);
        }

        protected Package(byte type, T body)
        {
            StartMarker = Constants.PACKAGE_START_MARKER;
            EndMarker = Constants.PACKAGE_END_MARKER;
            Type = type;

            RawBody = BodyToBytes(body);
        }

        protected abstract T ParseBody(byte[] sequence);

        protected abstract byte[] BodyToBytes(T body);

        private void Parse(byte[] sequence)
        {
            if (sequence.Length == 0
                || sequence[0] != StartMarker
                || sequence[Constants.PACKAGE_TYPE_OFFSET] != Type
                || sequence[sequence.Length - 1] != EndMarker)
            {
                throw new ArgumentException("Byte sequence is invalid.", "sequence");
            }

            byte[] dataLenthSequence = new byte[2];

            Array.Copy(sequence, Constants.DATA_LENGTH_OFFSET, dataLenthSequence, 0, sizeof(ushort));

            ushort dataLenth = BitConverter.ToUInt16(dataLenthSequence, 0);
            byte[] data = new byte[dataLenth];

            Array.Copy(sequence, Constants.DATA_OFFSET, data, 0, dataLenth);

            RawBody = data;
            
            Body = ParseBody(data);
        }
    }
}
