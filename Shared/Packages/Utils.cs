using Shared.Packages;
using System;
using System.Diagnostics;

namespace IniVisualizer.Shared.Packages
{
    public static class Utils
    {
        public static bool TryReadPackage(byte[] rawSequence, out byte[] packageSequence)
        {
            packageSequence = null;

            int index = 0;
            while (index < rawSequence.Length && rawSequence[index] != Constants.PACKAGE_START_MARKER)
            {
                index++;
            }

            if (index >= rawSequence.Length)
            {
                return false;
            }

            try
            {
                byte[] dataLengthSequence = new byte[sizeof(ushort)];

                Array.Copy(rawSequence, Constants.DATA_LENGTH_OFFSET, dataLengthSequence, 0, dataLengthSequence.Length);

                ushort dataLength = BitConverter.ToUInt16(dataLengthSequence, 0);

                if (rawSequence[Constants.DATA_OFFSET + dataLength] == Constants.PACKAGE_END_MARKER)
                {
                    packageSequence = new byte[Constants.DATA_OFFSET + dataLength + 1];

                    Array.Copy(rawSequence, 0, packageSequence, 0, packageSequence.Length);

                    return true;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Debug.WriteLine(e.Message);

                return false;
            }

            return false;
        }

        public static byte? GetPackageType(byte[] sequence)
        {
            if (sequence.Length > Constants.PACKAGE_TYPE_OFFSET)
            {
                return sequence[Constants.PACKAGE_TYPE_OFFSET];
            }

            return null;
        }
    }
}
