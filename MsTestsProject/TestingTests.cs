using SorterLibrary;
/**
 * These test use MsTests
 *  //https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert?view=mstest-net-3.8
    //https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert.throws?view=mstest-net-3.8
 */

namespace MsTestsProject
{
    [TestClass]
    public class TestingTests
    {
        [TestMethod]
        public void Int_Reflexive_Property_Test()
        {
            //Assemble
            int value = 5;

            bool expectedResult = true;

            //Act
            bool actualResult = (value == value);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);

        }


        [TestMethod]
        public void Cannot_Access_Array_Out_Of_Bounds_Test()
        {
            //Assemble
            int[] input = { 5, 4, 3, 2, 1 };

            bool expectedResult = false;

            //Act
            bool actualResult;
            try
            {
                actualResult = (input[input.Length + 5] != null);
            }
            catch (Exception ex) {
                actualResult = false;  
            }

            //Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void Int_Divided_By_Zero_Does_Not_Equal_5_Test()
        {
            //Assemble
            int value = 16;

            bool expectedResult = false;

            //Act
            bool actualResult;
            try
            {
                actualResult = ((value / 0) == 5);
            }
            catch (Exception ex)
            {
                actualResult = false;
            }

            //Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

    }
}
