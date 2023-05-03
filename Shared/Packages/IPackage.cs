namespace IniServer
{
    internal interface IPackage
    {
        byte StartMarker { get; }

        byte EndMarker { get; }

        byte Type { get; }

        ushort DataLength { get; }

        byte[] Data { get; }

        byte[] ToBytes();
    }
}
