namespace IniClient.Model
{
    internal class ExceptionEntityModel : IModel
    {
        internal string Message { get; }

        public ExceptionEntityModel() { }

        public ExceptionEntityModel(string message)
        {
            Message = message;
        }
    }
}
