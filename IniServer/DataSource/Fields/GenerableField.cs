using IniServer.Repository.Fields;
using System;

namespace IniServer.Repository
{
    internal abstract class GenerableField<T> : RangeField<T>, IComparable where T : IComparable
    {
        internal GenerableField(T minimumValue, T maximumValue, ref Random random)
        {
            if (ValidateBounds(minimumValue, maximumValue))
            {
                OnInvalidBounds();
            }

            MinimumValue = minimumValue;
            MaximumValue = maximumValue;

            Generate(ref random);
        }

        internal abstract bool ValidateBounds(T minimum, T maximum);

        internal abstract void Generate(ref Random random);

        protected void OnInvalidBounds()
        {
            throw new ArgumentOutOfRangeException("Bounds values is invalid.");
        }

        public int CompareTo(object obj)
        {
            if (obj is GenerableField<T> otherField)
            {
                if (otherField == null || otherField.Value == null)
                {
                    return 1;
                }

                if (Value == null)
                {
                    return -1;
                }

                return Value.CompareTo(otherField.Value);
            }

            throw new ArgumentException("Comparable object is not a GenerableField.");
        }
    }
}
