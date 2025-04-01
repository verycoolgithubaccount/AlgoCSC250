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
        public void ExampleTestMethod()
        {
            //Assemble
            //int[] testArray = { 5, 4, 3, 2, 1 };
            int[] testArray = GenerateDescending(5);
            //int[] expectedResult = { 1, 2, 3, 4, 5};
            int[] expectedResult = GenerateAscending(5);

            //Act
            Sorter<int>.BubbleSort(testArray);

            //Assert
            CollectionAssert.AreEqual(expectedResult, testArray);

        }

    }
}
