using System;

namespace IniServer
{
    internal class ServerException : Exception {
    
        internal ServerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
