using System;

namespace IniClient
{
    internal class ClientConnectionEventArgs : EventArgs
    {
        internal bool IsSuccessful { get; }

        internal string ErrrorMessage { get; }

        public ClientConnectionEventArgs(bool isSuccessfull, string errrorMessage)
        {
            IsSuccessful = isSuccessfull;
            ErrrorMessage = errrorMessage;
        }
    }
}
