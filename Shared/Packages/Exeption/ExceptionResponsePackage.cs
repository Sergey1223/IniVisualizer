using IniVisualizer.Shared.Packages;
using System.Text;

namespace Shared.Packages.Exeption
{
    public class ExceptionResponsePackage : Package<ExceptionResponseBody>
    {
        public const byte TYPE = 0xFB;

        public ExceptionResponsePackage(byte[] sequence) :
            base(TYPE, sequence)
        { }

        public ExceptionResponsePackage(ExceptionResponseBody body)
            : base(TYPE, body)
        { }

        protected override ExceptionResponseBody ParseBody(byte[] sequence)
        {
            if (sequence.Length == 0)
            {
                return null;
            }

            return new ExceptionResponseBody(Encoding.ASCII.GetString(sequence));
        }

        protected override byte[] BodyToBytes(ExceptionResponseBody body)
        {
            return Encoding.ASCII.GetBytes(body.Message);
        }
    }
}
