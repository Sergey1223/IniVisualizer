using System;

namespace IniServer.Repository.Fields
{
    internal class GenerableBooleanField : GenerableField<bool>
    {
        public GenerableBooleanField(bool minimumValue, bool maximumValue, ref Random random)
            : base(minimumValue, maximumValue, ref random)
        { }

        internal override bool ValidateBounds(bool minimum, bool maximum) {
            return minimum == maximum;
        }

        internal override void Generate(ref Random random)
        {
            Value = random.Next(0, 2) != 0;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
