namespace IniServer.DataSource.OperationContext
{
    internal class GetRangeOperationContext : IOperationContext
    {
        internal int Offset { get; }

        internal int Count { get; }

        public object Result { get; set; }

        public GetRangeOperationContext(int offset, int count)
        {
            Offset = offset;
            Count = count;
        }
    }
}
