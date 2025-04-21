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

        [TestMethod]
        public void SelectionSortCanSortRandomArray()
        {
            // Assemble
            int[] testArray = { 7, 2, 8, 3, 1, 12, 15 };
            int[] expectedResult = { 1, 2, 3, 7, 8, 12, 15 };

            // Act
            Sorter<int>.SelectionSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }


        [TestMethod]
        public void SelectionSortCanSortReverseSortedArray()
        {
            // Assemble
            int[] testArray = { 5, 4, 3, 2, 1 };
            int[] expectedResult = { 1, 2, 3, 4, 5 };

            // Act
            Sorter<int>.SelectionSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        public void SelectionSortCanSortAlreadySortedArray()
        {
            // Assemble
            int[] testArray = { 1, 2, 3, 4, 5 };
            int[] expectedResult = { 1, 2, 3, 4, 5 };

            // Act
            Sorter<int>.SelectionSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        public void SelectionSortCanSortArrayWithNegativeNumbers()
        {
            // Assemble
            int[] testArray = { -10, 3, 1, -2, 4 };
            int[] expectedResult = { -10, -2, 1, 3, 4 };

            // Act
            Sorter<int>.SelectionSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        public void SelectionSortCanSortArrayWithDuplicateNumbers()
        {
            // Assemble
            int[] testArray = { 3, 2, 4, 2, 3, 1 };
            int[] expectedResult = { 1, 2, 2, 3, 3, 4 };

            // Act
            Sorter<int>.SelectionSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        public void SelectionSortCanSortArrayWithEarlyUnsortedItem()
        {
            // Assemble
            int[] testArray = { 3, 2, 1, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int[] expectedResult = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            // Act
            Sorter<int>.SelectionSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        public void SelectionSortCanSortArrayWithLargeDataset()
        {
            // Assemble
            int[] testArray = GenerateDescending(1000);
            int[] expectedResult = GenerateAscending(1000);

            // Act
            Sorter<int>.SelectionSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        // This test was acquired through ChatGPT
        public void SelectionSortCanSortSingleElementArray()
        {
            // Assemble
            int[] testArray = { 42 };
            int[] expectedResult = { 42 };

            // Act
            Sorter<int>.SelectionSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        // This test was acquired through ChatGPT
        public void SelectionSortCanSortArrayWithAllIdenticalElements()
        {
            // Assemble
            int[] testArray = { 5, 5, 5, 5, 5 };
            int[] expectedResult = { 5, 5, 5, 5, 5 };

            // Act
            Sorter<int>.SelectionSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        // This test was acquired through ChatGPT
        public void SelectionSortCanSortEmptyArray()
        {
            // Assemble
            int[] testArray = { };
            int[] expectedResult = { };

            // Act
            Sorter<int>.SelectionSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        public void InsertionSortCanSortRandomArray()
        {
            // Assemble
            int[] testArray = { 7, 2, 8, 3, 1, 12, 15 };
            int[] expectedResult = { 1, 2, 3, 7, 8, 12, 15 };

            // Act
            Sorter<int>.InsertionSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }


        [TestMethod]
        public void InsertionSortCanSortReverseSortedArray()
        {
            // Assemble
            int[] testArray = { 5, 4, 3, 2, 1 };
            int[] expectedResult = { 1, 2, 3, 4, 5 };

            // Act
            Sorter<int>.InsertionSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        public void InsertionSortCanSortAlreadySortedArray()
        {
            // Assemble
            int[] testArray = { 1, 2, 3, 4, 5 };
            int[] expectedResult = { 1, 2, 3, 4, 5 };

            // Act
            Sorter<int>.InsertionSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        public void InsertionSortCanSortArrayWithNegativeNumbers()
        {
            // Assemble
            int[] testArray = { -10, 3, 1, -2, 4 };
            int[] expectedResult = { -10, -2, 1, 3, 4 };

            // Act
            Sorter<int>.InsertionSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        public void InsertionSortCanSortArrayWithDuplicateNumbers()
        {
            // Assemble
            int[] testArray = { 3, 2, 4, 2, 3, 1 };
            int[] expectedResult = { 1, 2, 2, 3, 3, 4 };

            // Act
            Sorter<int>.InsertionSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        public void InsertionSortCanSortArrayWithEarlyUnsortedItem()
        {
            // Assemble
            int[] testArray = { 3, 2, 1, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int[] expectedResult = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            // Act
            Sorter<int>.InsertionSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        public void InsertionSortCanSortArrayWithLargeDataset()
        {
            // Assemble
            int[] testArray = GenerateDescending(1000);
            int[] expectedResult = GenerateAscending(1000);

            // Act
            Sorter<int>.InsertionSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        // This test was acquired through ChatGPT
        public void InsertionSortCanSortSingleElementArray()
        {
            // Assemble
            int[] testArray = { 42 };
            int[] expectedResult = { 42 };

            // Act
            Sorter<int>.InsertionSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        // This test was acquired through ChatGPT
        public void InsertionSortCanSortArrayWithAllIdenticalElements()
        {
            // Assemble
            int[] testArray = { 5, 5, 5, 5, 5 };
            int[] expectedResult = { 5, 5, 5, 5, 5 };

            // Act
            Sorter<int>.InsertionSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        // This test was acquired through ChatGPT
        public void InsertionSortCanSortEmptyArray()
        {
            // Assemble
            int[] testArray = { };
            int[] expectedResult = { };

            // Act
            Sorter<int>.InsertionSort(testArray);

            // Assert
            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestMethod]
        public void FindMedianSortedArraysCanInsertToMiddle()
        {
            // Assemble
            int[] arrayOne = { 1, 3 };
            int[] arrayTwo = { 2 };
            double expectedResult = 2;

            // Act
            double realResult = Sorter<int>.FindMedianSortedArrays(arrayOne, arrayTwo);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        public void FindMedianSortedArraysCanAppendToEnd()
        {
            // Assemble
            int[] arrayOne = { 3, 4 };
            int[] arrayTwo = { 5 };
            double expectedResult = 4;

            // Act
            double realResult = Sorter<int>.FindMedianSortedArrays(arrayOne, arrayTwo);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        public void FindMedianSortedArraysCanPrependToBeginning()
        {
            // Assemble
            int[] arrayOne = { 4, 6 };
            int[] arrayTwo = { 2 };
            double expectedResult = 4;

            // Act
            double realResult = Sorter<int>.FindMedianSortedArrays(arrayOne, arrayTwo);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        public void FindMedianSortedArraysCanSortLargerArrays()
        {
            // Assemble
            int[] arrayOne = { 1, 2, 3, 8, 9, 10, 11 };
            int[] arrayTwo = { 4, 5, 6, 7 };
            double expectedResult = 6;

            // Act
            double realResult = Sorter<int>.FindMedianSortedArrays(arrayOne, arrayTwo);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        public void FindMedianSortedArraysCanSortEvenLengthArrays()
        {
            // Assemble
            int[] arrayOne = { 1, 2 };
            int[] arrayTwo = { 3, 4 };
            double expectedResult = 2.5;

            // Act
            double realResult = Sorter<int>.FindMedianSortedArrays(arrayOne, arrayTwo);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        public void FindMedianSortedArraysCanSortArraysWithDuplicates()
        {
            // Assemble
            int[] arrayOne = { 1, 2, 3, 3 };
            int[] arrayTwo = { 3, 4 };
            double expectedResult = 3;

            // Act
            double realResult = Sorter<int>.FindMedianSortedArrays(arrayOne, arrayTwo);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        public void FindMedianSortedArraysCanInsertArrayTwoIntoArrayOne()
        {
            // Assemble
            int[] arrayOne = { 0, 0, 0, 0, 0 };
            int[] arrayTwo = { -1, 0, 0, 0, 0, 0, 1 };
            double expectedResult = 0;

            // Act
            double realResult = Sorter<int>.FindMedianSortedArrays(arrayOne, arrayTwo);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        public void BinarySearchCanFindInBasicArray()
        {
            // Assemble
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int target = 3;
            int expectedResult = 2;

            // Act
            int realResult = Sorter<int>.BinarySearch(array, target);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        public void BinarySearchCanFindInArrayWithNegatives()
        {
            // Assemble
            int[] array = { -10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0 };
            int target = -3;
            int expectedResult = 7;

            // Act
            int realResult = Sorter<int>.BinarySearch(array, target);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        public void BinarySearchCanFindItemAtFirstIndexInEvenArray()
        {
            // Assemble
            int[] array = { 1, 2, 3, 4, 5, 6 };
            int target = 1;
            int expectedResult = 0;

            // Act
            int realResult = Sorter<int>.BinarySearch(array, target);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        public void BinarySearchCanFindItemAtFirstIndexInUnevenArray()
        {
            // Assemble
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };
            int target = 1;
            int expectedResult = 0;

            // Act
            int realResult = Sorter<int>.BinarySearch(array, target);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        public void BinarySearchCanFindItemAtLastIndexInEvenArray()
        {
            // Assemble
            int[] array = { 1, 2, 3, 4, 5, 6 };
            int target = 6;
            int expectedResult = 5;

            // Act
            int realResult = Sorter<int>.BinarySearch(array, target);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        public void BinarySearchCanFindItemAtLastIndexInUnevenArray()
        {
            // Assemble
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };
            int target = 7;
            int expectedResult = 6;

            // Act
            int realResult = Sorter<int>.BinarySearch(array, target);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        public void BinarySearchReturnsNegativeWhenItemOverArray()
        {
            // Assemble
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };
            int target = 8;
            int expectedResult = -1;

            // Act
            int realResult = Sorter<int>.BinarySearch(array, target);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        public void BinarySearchReturnsNegativeWhenItemUnderArray()
        {
            // Assemble
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };
            int target = 0;
            int expectedResult = -1;

            // Act
            int realResult = Sorter<int>.BinarySearch(array, target);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        public void BinarySearchReturnsNegativeWhenArrayIsEmpty()
        {
            // Assemble
            int[] array = { };
            int target = 40;
            int expectedResult = -1;

            // Act
            int realResult = Sorter<int>.BinarySearch(array, target);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        public void BinarySearchWorksWithArrayLengthOne()
        {
            // Assemble
            int[] array = { 5 };
            int target = 5;
            int expectedResult = 0;

            // Act
            int realResult = Sorter<int>.BinarySearch(array, target);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        public void BinarySearchWorksWithArrayWithGaps()
        {
            // Assemble
            int[] array = { -20, -17, -16, -15, -10, 0, 1, 3, 8, 9, 11 };
            int target = 8;
            int expectedResult = 8;

            // Act
            int realResult = Sorter<int>.BinarySearch(array, target);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        public void BinarySearchWorksWithDuplicates()
        {
            // Assemble
            int[] array = { 1, 1, 2, 3, 5, 8, 13 };
            int target = 1;
            int expectedResult = 1;

            // Act
            int realResult = Sorter<int>.BinarySearch(array, target);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        // This test was acquired through ChatGPT
        public void BinarySearchCanFindInLargeArray()
        {
            // Assemble
            int[] array = Enumerable.Range(1, 100000).ToArray(); // 1 to 100,000
            int target = 54321;
            int expectedResult = 54320; // zero-based index

            // Act
            int realResult = Sorter<int>.BinarySearch(array, target);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        // This test was acquired through ChatGPT
        public void BinarySearchFindsMiddleElement()
        {
            // Assemble
            int[] array = { 10, 20, 30, 40, 50 };
            int target = 30;
            int expectedResult = 2;

            // Act
            int realResult = Sorter<int>.BinarySearch(array, target);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        public void BinarySearchReturnsNegativeForMissingItemInMiddle()
        {
            // Assemble
            int[] array = { 10, 20, 30, 40, 50 };
            int target = 31;
            int expectedResult = -1;

            // Act
            int realResult = Sorter<int>.BinarySearch(array, target);

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

    }
}
