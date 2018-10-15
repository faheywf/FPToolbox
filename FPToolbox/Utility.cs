using System;

namespace FPToolbox
{
    /// <summary>
    /// Static class that contains helper functions for interacting with Option types.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Static Option constructor for a given value.
        /// </summary>
        /// <typeparam name="T">Type of object passed as value.</typeparam>
        /// <param name="value">Value to be wrapped in Option.</param>
        /// <returns>Some&lt;<typeparamref name="T"/>&gt; if value is not null, othwerwise None.</returns>
        public static Option Option<T>(T value)
        {
            try
            {
                return Some(value);
            }
            catch (ArgumentNullException)
            {
                return None();
            }
        }

        /// <summary>
        /// Static Some&lt;<typeparamref name="T"/>&gt; constructor for a given value.
        /// </summary>
        /// <typeparam name="T">Type of object passed as value.</typeparam>
        /// <param name="value">Value to be wrapped in Option.</param>
        /// <returns>Some&lt;<typeparamref name="T"/>&gt; if value is not null.</returns>
        public static Some<T> Some<T>(T value)
        {
            return new Some<T>(value);
        }

        /// <summary>
        /// Static None constructor.
        /// </summary>
        /// <returns>An instance of None.</returns>
        public static None None()
        {
            return new None();
        }
    }
}
