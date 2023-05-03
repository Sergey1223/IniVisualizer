namespace IniServer.DataSource
{
    internal class DeleteOperationContext : IOperationContext
    {
        internal int Index { get; }

        public object Result { get; }

        public DeleteOperationContext(int index)
        {
            Index = index;
        }
    }
}
