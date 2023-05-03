using System;
using System.Linq;
using System.Text;

namespace IniServer.Repository.Fields
{
    /// <summary>
    /// Represents randomly generable field in specified range and pattern.
    /// Pattern string example: "%%%%-%%%".
    /// Maximum pattern length restricted by <see cref="PATTERN_LENGTH"/>
    /// </summary>
    internal class GenerableStringField : RangeField<string>
    {
        private const char INTERPOLATION_SYMBOL = '%';
        private const int PATTERN_LENGTH = 8;

        internal string Pattern { get; set; }

        public GenerableStringField(string minimum, string maximum, string pattern, ref Random random)
        {
            pattern = pattern.Substring(0, PATTERN_LENGTH);

            Validate(minimum, maximum, pattern);

            MinimumValue = minimum;
            MaximumValue = maximum;
            Pattern = pattern.Substring(0, PATTERN_LENGTH);

            Generate(ref random);
        }

        internal void Validate(string minimum, string maximum, string pattern)
        {
            if ((minimum.Length != 1 && maximum.Length != 1)
                || (maximum.First() < minimum.First()))
            {
                throw new ArgumentOutOfRangeException("MaximumValue");
            };
            
            if (string.IsNullOrWhiteSpace(pattern))
            {
                throw new ArgumentOutOfRangeException("Pattern");
            };
        }

        internal void Generate(ref Random random)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < Pattern.Length; i++)
            {
                if (Pattern[i] == INTERPOLATION_SYMBOL)
                {
                    builder.Append((char)random.Next(MinimumValue.First(), MaximumValue.First() + 1));
                }
                else
                {
                    builder.Append(Pattern[i]);
                }
            }

            Value = builder.ToString();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
