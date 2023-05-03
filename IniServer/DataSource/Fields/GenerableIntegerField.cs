using System;

namespace IniServer.Repository
{
    internal class GenerableIntegerField : GenerableField<int>
    {
        public GenerableIntegerField(int minimumValue, int maximumValue, ref Random random)
            : base(minimumValue, maximumValue, ref random)
        { }

        internal override bool ValidateBounds(int minimum, int maximum)
        {
            return maximum < minimum;
        }

        internal override void Generate(ref Random random)
        {
            Value = random.Next(MinimumValue, MaximumValue + 1);
        }

        public override string ToString()
        {
            // Filling zeros before value for alignment (formatting fro index generation)
            return ((int)Value).ToString("D10");
        }
    }
}
