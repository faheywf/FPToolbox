using System;

namespace FPToolbox
{
    /// <summary>
    /// Abstract Option type inherited by both Some and None.
    /// </summary>
    public abstract class Option
    {
        /// <summary>
        /// Matches an Option and invokes the appropriate delegate function.
        /// </summary>
        /// <typeparam name="T">Type of the option value.</typeparam>
        /// <param name="some">Function to invoke if option is Some value. Value is passed to delegate function.</param>
        /// <param name="none">Function to invoke if option is None.</param>
        /// <returns>Result of the invoked functions.</returns>
        public T Match<T>(Func<Some<T>, T> some, Func<T> none)
        {
            switch (this)
            {
                case Some<T> s:
                    return some(s);
                case None n:
                    return none();
                default:
                    throw new Exception("Match was called on an Option type that is not supported");
            }
        }

        /// <summary>
        /// Matches an Option and returns value if option is Some, otherwise invokes none delegate function.
        /// </summary>
        /// <typeparam name="T">Type of the option value.</typeparam>
        /// <param name="none">Function to invoke if option is None.</param>
        /// <returns>Option value or result of the invoked function.</returns>
        public T Match<T>(Func<T> none)
        {
            switch (this)
            {
                case Some<T> s:
                    return s.Value;
                case None n:
                    return none();
                default:
                    throw new Exception("Match was called on an Option type that is not supported");
            }
        }

        /// <summary>
        /// Matches an Option and returns value if option is Some, otherwise returns given none value.
        /// </summary>
        /// <typeparam name="T">Type of the option value.</typeparam>
        /// <param name="none">Value to return if option is none.</param>
        /// <returns>Option value or none value.</returns>
        public T Match<T>(T none)
        {
            switch (this)
            {
                case Some<T> s:
                    return s.Value;
                case None n:
                    return none;
                default:
                    throw new Exception("Match was called on an Option type that is not supported");
            }
        }
    }
}
