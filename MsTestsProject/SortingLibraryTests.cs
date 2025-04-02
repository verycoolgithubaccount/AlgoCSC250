using SorterLibrary;
/**
 * These test use MsTests
 *  //https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert?view=mstest-net-3.8
    //https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert.throws?view=mstest-net-3.8
 */

namespace MsTestsProject
{   
    [TestClass]
    public class SorterTests
    {
        #region Generation Code
        private static readonly int Seed = 12271978;

        public static int[] GenerateRandom(int size)
        {
            var rand = new Random(Seed);
            return Enumerable.Range(0, size)
                             .Select(_ => rand.Next(100001))
                             .ToArray();
        }

        public static int[] GenerateAscending(int size)
        {
            return GenerateRandom(size).OrderBy(x => x).ToArray();
        }

        public static int[] GenerateDescending(int size)
        {
            return GenerateRandom(size).OrderByDescending(x => x).ToArray();
        }

        public static Person[] GeneratePersonList(int size, PersonOrder order)
        {
            return PersonGenerator.Generate(size, Seed, order);
        }

        #endregion

        
        [TestMethod]
        public void BubbleSortCanSortRandomArray()
        {
            // Assemble
            int[] testArray = { 7, 2, 8, 3, 1, 12, 15 };
            int[] expectedResult = { 1, 2, 3, 7, 8, 12, 15 };

            // Act
            Sorter<int>.BubbleSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }


        [TestMethod]
        public void BubbleSortCanSortReverseSortedArray()
        {
            // Assemble
            int[] testArray = { 5, 4, 3, 2, 1 };
            int[] expectedResult = { 1, 2, 3, 4, 5 };

            // Act
            Sorter<int>.BubbleSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        public void BubbleSortCanSortAlreadySortedArray()
        {
            // Assemble
            int[] testArray = { 1, 2, 3, 4, 5 };
            int[] expectedResult = { 1, 2, 3, 4, 5 };

            // Act
            Sorter<int>.BubbleSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        public void BubbleSortCanSortArrayWithNegativeNumbers()
        {
            // Assemble
            int[] testArray = { -10, 3, 1, -2, 4 };
            int[] expectedResult = { -10, -2, 1, 3, 4 };

            // Act
            Sorter<int>.BubbleSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        public void BubbleSortCanSortArrayWithDuplicateNumbers()
        {
            // Assemble
            int[] testArray = { 3, 2, 4, 2, 3, 1 };
            int[] expectedResult = { 1, 2, 2, 3, 3, 4 };

            // Act
            Sorter<int>.BubbleSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        public void BubbleSortCanSortArrayWithEarlyUnsortedItem()
        {
            // Assemble
            int[] testArray = { 3, 2, 1, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int[] expectedResult = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            // Act
            Sorter<int>.BubbleSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        public void BubbleSortCanSortArrayWithLargeDataset()
        {
            // Assemble
            int[] testArray = GenerateDescending(1000);
            int[] expectedResult = GenerateAscending(1000);

            // Act
            Sorter<int>.BubbleSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        // This test was acquired through ChatGPT
        public void BubbleSortCanSortSingleElementArray()
        {
            // Assemble
            int[] testArray = { 42 };
            int[] expectedResult = { 42 };

            // Act
            Sorter<int>.BubbleSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        // This test was acquired through ChatGPT
        public void BubbleSortCanSortArrayWithAllIdenticalElements()
        {
            // Assemble
            int[] testArray = { 5, 5, 5, 5, 5 };
            int[] expectedResult = { 5, 5, 5, 5, 5 };

            // Act
            Sorter<int>.BubbleSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        // This test was acquired through ChatGPT
        public void BubbleSortCanSortEmptyArray()
        {
            // Assemble
            int[] testArray = { };
            int[] expectedResult = { };

            // Act
            Sorter<int>.BubbleSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }
    }
}
