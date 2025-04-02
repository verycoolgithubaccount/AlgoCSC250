/*
 *https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1?view=net-8.0
 */
namespace SorterLibrary
{
    public class Sorter<T> where T : IComparable<T>
    {
        // called that bc large numbers bubble up, each time it's sorted the next largest number goes to the end
        // Big O time is O(n^2)
        // Big O space is O(1)
        public static void BubbleSort(T[] arr) 
        {
            // Set iteration end to end of array
            int iterationEnd = arr.Length;
            // Repeat until iteration end = 0
            while (iterationEnd > 1)
            {
                // Set last swapped item to 0
                int lastSwappedItem = 0;

                // Repeat until iteration end -1
                for (int i = 0; i < iterationEnd - 1; i++)
                {
                    // Compare number at index with next number
                    if (arr[i].CompareTo(arr[i + 1]) > 0)
                    {
                        // Swap them if the first is greater
                        T temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;

                        // Set last swapped index to index of second item
                        lastSwappedItem = i + 1;
                    }
                    // Else move on
                }
                // Set iteration end to last swapped index
                iterationEnd = lastSwappedItem;
            }
        }
    }
}
