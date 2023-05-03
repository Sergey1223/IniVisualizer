using System.Collections.Generic;

namespace IniVisualizer.Shared.Packages
{
    public class DataTableResponseBody : IBody
    {
        public int TotalCount { get; }

        public List<List<string>> Frame { get; }

        public DataTableResponseBody() { }

        public DataTableResponseBody(int maximumOffset, List<List<string>> frame)
        {
            Frame = frame;
            TotalCount = maximumOffset;
        }
    }
}

