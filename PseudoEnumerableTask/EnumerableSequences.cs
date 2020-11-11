using System;
using System.Collections.Generic;

namespace PseudoEnumerableTask
{
    public static class EnumerableSequences
    {

        /// <summary>
        /// Filters a sequence based on a predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source sequence.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="predicate">A <see cref="IPredicate{T}"/> to test each element of a sequence for a condition.</param>
        /// <returns>An sequence of elements from the source sequence that satisfy the condition.</returns>
        /// <exception cref="ArgumentNullException">Thrown when source sequence or predicate is null.</exception>
        public static IEnumerable<TSource> Filter<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{source} can't be null");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.");
            }

            List<TSource> result = new List<TSource>();

            foreach (var number in source)
            {
                if (predicate(number))
                {
                    result.Add(number);
                }
            }

            return result;
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending order by using a specified comparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source sequence.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> to compare keys.</param>
        /// <returns>An ordered by comparer sequence.</returns>
        /// <exception cref="ArgumentNullException">Thrown when sequence is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when comparer is null, and one or more elements
        /// of the sequence do not implement the <see cref="IComparable{T}"/>  interface.
        ///</exception>
        public static TSource[] SortBy<TSource>(this TSource[] source, IComparer<TSource> comparer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Filters the elements of source sequence based on a specified type.
        /// </summary>
        /// <typeparam name="TResult">Type selector to return.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <returns>A sequence that contains the elements from source sequence that have type TResult.</returns>
        /// <exception cref="ArgumentNullException">Thrown when sequence is null.</exception>
        public static TResult[] TypeOf<TResult>(this object[] source)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inverts the order of the elements in a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of sequence.</typeparam>
        /// <param name="source">A sequence of elements to reverse.</param>
        /// <exception cref="ArgumentNullException">Thrown when sequence is null.</exception>
        public static TSource[] Reverse<TSource>(this TSource[] source)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
        /// Swaps two objects.
        /// </summary>
        /// <typeparam name="T">The type of parameters.</typeparam>
        /// <param name="left">First object.</param>
        /// <param name="right">Second object.</param>
        internal static void Swap<T>(ref T left, ref T right)
        {
            throw new NotImplementedException();
        }
    }
}