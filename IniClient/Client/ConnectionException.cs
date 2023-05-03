using System;

namespace IniClient
{
    internal class ConnectionException : Exception
    {
        internal ConnectionException(string message, Exception innerException) : base(message, innerException) { }
    }
}
