namespace IniServer.DataSource.OperationContext
{
    internal class UpdateOperationContext : IOperationContext
    {
        internal int Index { get; }

        public object Result { get; }

        public UpdateOperationContext(int index)
        {
            Index = index;
        }
    }
}
