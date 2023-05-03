using System;

namespace IniServer.Repository
{
    internal interface IIdentifable
    {
        Guid Id { get; set; }
    }
}