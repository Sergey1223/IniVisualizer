namespace Shared.Packages
{
    internal class Constants
    {
        internal const byte PACKAGE_START_MARKER = 0xFE;
        internal const byte PACKAGE_END_MARKER = 0xFF;
        internal const int PACKAGE_TYPE_OFFSET = 1;
        internal const int DATA_LENGTH_OFFSET = 2;
        internal const int DATA_OFFSET = 4;
    }
}
