namespace IniServer.Repository.Fields
{
    internal class RangeField<T> : Field
    {
        protected internal T MinimumValue { get; protected set; }

        protected internal T MaximumValue { get; protected set; }
    }
}
