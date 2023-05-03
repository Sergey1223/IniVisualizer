using System.Collections.Generic;

namespace IniClient.Model
{
    internal interface IModelList<T> : IModel where T : IModel
    {
        List<T> Data { get; }
    }
}
