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


        // Big O time is O(n^2)
        // Big O space is O(1)

        // Selection sort loops through the array and compares each item to every item after it.
        // If the other item is smaller, the algorithm continues but compares the smallest value
        // instead. At the end of the loop, the item at i and the smallest item it's found are
        // swapped. This guarantees that the smallest item in the array is always brought to the
        // beginning, so the array gradually sorts from smallest to largest.
        public static void SelectionSort(T[] arr)
        {
            // loop through each item besides the last
            for (int i = 0; i < arr.Length - 1; i++) 
            {
                // set smallest index to i
                int smallestIndex = i;
                // loop through each item after the current index
                for (int j = i + 1; j < arr.Length; j++)
                {
                    // if item at j < item at smallest index
                    if (arr[j].CompareTo(arr[smallestIndex]) < 0)
                    {
                        // set smallestIndex to new smallest index
                        smallestIndex = j;
                        // continue iterating through
                    }
                }
                // if smallestIndex is not i, swap the smallest number with i
                if (smallestIndex != i)
                {
                    T temp = arr[smallestIndex];
                    arr[smallestIndex] = arr[i];
                    arr[i] = temp;
                }
            }
        }

        // Big O time is O(n^2) or O(n) best case
        // Big O space is O(1)

        // Insertion sort loops through each item in the array (starting at 1) and stores the value
        // of the item. It then loops through each earlier index and checks that item against the
        // stored value. If the item is greater, it moves it up one in the array. Otherwise, it
        // inserts the stored value after the lesser item and moves on to the next value.
        public static void InsertionSort(T[] arr)
        {
            // loop through each item starting at 1
            for (int i = 1; i < arr.Length; i++)
            { 
                // set value to the item at i
                T value = arr[i];
                // loop through each lower index in decreasing order
                for (int j = i - 1; j >= 0; j--)
                {
                    // if value is less than the item at comparing index
                    if (value.CompareTo(arr[j]) < 0)
                    {
                        // set comparing index + 1 to the comparing item
                        arr[j + 1] = arr[j];
                        // if this is the first item in the array set it to the value and stop
                        if (j == 0)
                        {
                            arr[j] = value;
                            break;
                        }
                    }
                    // else
                    else
                    {
                        // set comparing index + 1 to value and stop
                        arr[j + 1] = value;
                        break;
                    }
                }
            }
        }
    }
}
