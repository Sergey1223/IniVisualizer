using System;

namespace IniServer.DataSource
{
    internal class DataSourceException : Exception
    {
        internal DataSourceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
