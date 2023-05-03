using IniServer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniServer.Repository
{
    internal class GenerableFloatField : GenerableField<float>
    {
        public GenerableFloatField(float minimumValue, float maximumValue, ref Random random)
            : base(minimumValue, maximumValue, ref random)
        { }

        internal override bool ValidateBounds(float minimum, float maximum)
        {
            return maximum < minimum;
        }

        internal override void Generate(ref Random random)
        {
            Value = MinimumValue + MaximumValue * random.NextDouble();
        }

        public override string ToString()
        {
            // Formatting for index generation
            return string.Format("{0:0000000000.00}", Value);
        }
    }
}
