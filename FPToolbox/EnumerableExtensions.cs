using System;
using System.Collections.Generic;

namespace FPToolbox
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Enumerates over an enumerable applying map function to each item.
        /// </summary>
        /// <typeparam name="T">Type of enumerable item.</typeparam>
        /// <typeparam name="U">Return type of map function.</typeparam>
        /// <param name="enumerable">Enumerable to enumerate and apply map on.</param>
        /// <param name="map">Mapping function to apply to each enumerated item.</param>
        /// <returns>Enumerable of <typeparam name="U"> returned by map function invocations.</returns>
        public static IEnumerable<U> Map<T, U>(this IEnumerable<T> enumerable, Func<T, U> map)
        {
            foreach (T item in enumerable)
            {
                yield return map(item);
            }
        }

        /// <summary>
        /// Enumerates over an enumerable and returns only items that, when passed to the filter function as parameters,
        /// the function returns true.
        /// </summary>
        /// <typeparam name="T">Type of the enumerable item.</typeparam>
        /// <param name="enumerable">Enumerable to enumerate and apply filter on.</param>
        /// <param name="filter">Filtering function that returns true on items that should be retained.</param>
        /// <returns>Enumerable of <typeparamref name="T"/> that the filter returned true for.</returns>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> enumerable, Func<T, bool> filter)
        {
            foreach (T item in enumerable)
            {
                if (filter(item))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Enumerates over an enumerable and applies reducer function to items, returning the accumulation.
        /// </summary>
        /// <typeparam name="T">Type of the enumerable item.</typeparam>
        /// <typeparam name="U">Type of the accumulation.</typeparam>
        /// <param name="enumerable">Enumerable to enumerate and apply reduce on.</param>
        /// <param name="reducer">Reducing function that returns reduction of accumulation and each enumerated item.</param>
        /// <param name="initialValue">Initial value of the accumulator.</param>
        /// <returns>Final value of accumulator.</returns>
        public static U Reduce<T, U>(this IEnumerable<T> enumerable, Func<U, T, U> reducer, U initialValue)
        {
            U acc = initialValue;
            foreach(T item in enumerable)
            {
                acc = reducer(acc, item);
            }
            return acc;
        }
    }
}
