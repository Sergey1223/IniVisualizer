using IniClient.Model;
using System;

namespace IniClient
{
    internal class ClientUpdatedEventArgs : EventArgs
    {
        internal bool IsSuccessful { get; }

        internal IModel Model { get; }

        internal ClientUpdatedEventArgs(bool isSuccessful, IModel model)
        {
            IsSuccessful = isSuccessful;
            Model = model;
        }
    }
}