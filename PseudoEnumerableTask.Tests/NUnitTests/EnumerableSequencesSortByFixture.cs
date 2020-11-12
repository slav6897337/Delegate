using System;
using System.Collections.Generic;
using Comparers;
using NUnit.Framework;

namespace PseudoEnumerableTask.Tests.NUnitTests
{
    [TestFixture(
        new[] {"Beg", null, "Life", "I", "i", "I", null, "To"},
        new[] {null, null, "i", "I", "I", "To", "Beg", "Life"},
        TypeArgs = new Type[] {typeof(string)})]

    [TestFixture(
        new[] {0, 12, -12, 34, 0, 2, -567, 12, -12, 89, int.MaxValue, -1000},
        new[] {0, 0, 2, 12, -12, 12, -12, 34, 89, -567, -1000, int.MaxValue},
        TypeArgs = new Type[] {typeof(int)})]

    public class EnumerableSequencesSortByFixture<T>
    {
        private readonly T[] source;
        private readonly T[] expected;
        private Func<T, T, int> comparer;

        public EnumerableSequencesSortByFixture(T[] source, T[] expected)
        {
            this.expected = expected;
            this.source = source;
            comparer = ComparerCreator(typeof(T));
        }

        [Test]
        public void SortByTest() => CollectionAssert.AreEqual(expected, source.SortBy(comparer));
        
        private Func<T, T, int> ComparerCreator(Type type)
        {
            if (type == typeof(string))
            {
                var temp = new StringByLengthComparer<string>();
                comparer = temp.Compare;
                return comparer;
            }

            if (type == typeof(int))
            {
                var temp = new StringByLengthComparer<string>();
                comparer = temp.Compare;
                return comparer;
            }

            return null;
        }
    }
}