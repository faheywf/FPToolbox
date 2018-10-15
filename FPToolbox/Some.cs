using System;

namespace FPToolbox
{
    /// <summary>
    /// Encapsulates a non-null value.
    /// </summary>
    /// <typeparam name="T">Type of enclose value.</typeparam>
    public class Some<T> : Option
    {
        internal readonly T Value = default;

        /// <summary>
        /// Constructs Some of T. Throws an ArgumentNullException if value is null.
        /// </summary>
        /// <param name="value">Non-null value.</param>
        public Some(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            Value = value;
        }
    }
}
