using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace PseudoEnumerableTask
{
    public static class EnumerableSequences
    {

        /// <summary>
        /// Filters a sequence based on a predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source sequence.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="predicate">A <see cref="Func<TSource, bool>"/> delegate.</param>
        /// <returns>An sequence of elements from the source sequence that satisfy the condition.</returns>
        /// <exception cref="ArgumentNullException">Thrown when source sequence or predicate is null.</exception>
        public static IEnumerable<TSource> Filter<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            ValidateSourseByNull(source);
            ValidateSourseByNull(predicate);

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
        public static TSource[] SortBy<TSource>(this TSource[] source, Func<TSource, TSource, int> comparer)
        {
            ValidateSourseByNull(source);    

            return QuickSort<TSource>(source, 0, source.Length - 1, comparer);      
            
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
            ValidateSourseByNull(source);
            TResult[] result = new TResult[source.Length];
            int j = 0;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] is TResult temp)
                {
                    result[j] = temp;
                    j++;
                }
            }

            Array.Resize(ref result, j);

            return result;
        }

        /// <summary>
        /// Inverts the order of the elements in a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of sequence.</typeparam>
        /// <param name="source">A sequence of elements to reverse.</param>
        /// <exception cref="ArgumentNullException">Thrown when sequence is null.</exception>
        public static TSource[] Reverse<TSource>(this TSource[] source)
        {
            ValidateSourseByNull(source);

            source = System.Linq.Enumerable.Reverse(source).ToArray();          

            return source;
        }

        /// <summary>
        /// Swaps two objects.
        /// </summary>
        /// <typeparam name="T">The type of parameters.</typeparam>
        /// <param name="left">First object.</param>
        /// <param name="right">Second object.</param>
        internal static void Swap<T>(ref T left, ref T right)
        {
            T temp = left;
            left = right;
            right = temp;
        }

        static int Partition<TSource>(TSource[] array, int minIndex, int maxIndex, Func<TSource, TSource, int> comparer)
        {    
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (comparer(array[i], array[maxIndex])<=0) 
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        static TSource[] QuickSort<TSource>(TSource[] array, int minIndex, int maxIndex, Func<TSource, TSource, int> comparer)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex, comparer);
            QuickSort(array, minIndex, pivotIndex - 1, comparer);
            QuickSort(array, pivotIndex + 1, maxIndex, comparer);

            return array;
        }

        private static void ValidateSourseByNull<T>(T source)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{source} can't be null");
            }

            if (source is string str)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    return;
                }
                throw new ArgumentException("Array cannot be empty.");
            }
        }
    }
}