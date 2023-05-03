using System;

namespace IniServer.Repository
{
    internal interface IGenerableEntityModel<T> : IIdentifable
    {
        void GenerateFields(ref Random random);

        void RegenerateFields(ref Random random);
    }
}