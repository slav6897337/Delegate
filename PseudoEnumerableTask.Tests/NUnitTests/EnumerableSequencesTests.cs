using System.Collections.Generic;
using System.Linq;
using ContainsDigitPredicate;
using Comparers;
using NUnit.Framework;
using System;

namespace PseudoEnumerableTask.Tests.NUnitTests
{
    [TestFixture]
    public class EnumerableSequencesTests
    {
        private static IEnumerable<TestCaseData> FilterTestCases
        {
            get
            {
                yield return new TestCaseData(new ContainsDigitValidator {Digit = 0},
                        new[] {2212332, 1405644, -1236674})
                    .Returns(new[] {1405644});
                yield return new TestCaseData(new ContainsDigitValidator {Digit = 7},
                        new[] {-27, 173, 371132, 7556, 7243, 10017, int.MinValue, int.MaxValue})
                    .Returns(new[] {-27, 173, 371132, 7556, 7243, 10017, int.MinValue, int.MaxValue});
                yield return new TestCaseData(new ContainsDigitValidator {Digit = 0},
                        new[] {int.MinValue, int.MinValue, int.MinValue, int.MaxValue, int.MaxValue})
                    .Returns(new int[] { });
                yield return new TestCaseData(new ContainsDigitValidator {Digit = 2},
                        new[] {-123, 123, 2202, 3333, 4444, 55055, 0, -7, 5402, 9, 0, -150, 287})
                    .Returns(new[] {-123, 123, 2202, 5402, 287});
            }
        }

        
        
        private static IEnumerable<TestCaseData> SortByTestCases
        {
            get
            {
                yield return new TestCaseData(
                        new StringByLengthComparer(),
                        new [] {"Beg", null, "Life", "I", "i", "I", null, "To"})
                    .Returns(new [] {null, null, "I", "i", "I", "To", "Beg", "Life"});
                yield return new TestCaseData(
                        new StringByLengthComparer(),
                        new [] {null, "Longer", "Longest", "Short", null, null})
                    .Returns(new [] {null, null, null, "Short", "Longer", "Longest"});
            }
        }

        
        [TestCaseSource(nameof(SortByTestCases))]
        public string[] SortByTests(IComparer<string> comparer, string[] source)
        {
            return source.SortBy(comparer).ToArray();
        }

        [TestCaseSource(nameof(FilterTestCases))]
        public int[] FilterByTests(ContainsDigitValidator filter, int[] source)
        {
            Func<int, bool> predicate = filter.Verify;
            return source.Filter(predicate).ToArray();
        }
    }
}