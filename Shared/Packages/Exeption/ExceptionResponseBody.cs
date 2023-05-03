using IniVisualizer.Shared.Packages;

namespace Shared.Packages.Exeption
{
    public class ExceptionResponseBody : IBody
    {
        public string Message { get; }

        public ExceptionResponseBody() { }

        public ExceptionResponseBody(string message)
        {
            Message = message;
        }
    }
}
