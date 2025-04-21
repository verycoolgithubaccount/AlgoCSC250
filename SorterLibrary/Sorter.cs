/*
 *https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1?view=net-8.0
 */
using System.Numerics;

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

        // Binary search recursively looks through a sorted array until it finds the value it's looking
        // for. It does this by starting at the middle index of the array, checking if the item is there,
        // and if not, doing the same thing with either the first or second half of the array depending on
        // whether the item is less or greater than the item at the middle index. This way, it divides the
        // array in half over and over until it's either found what it's looking for or has run out of items,
        // in which case the item is not in the array.

        // Big-O time is O(log(n)) because it halves the array size every time it loops
        // Big-O space is O(1)

        public static int BinarySearch(T[] arr, T item)
        {
            // return -1 if there are no items
            if (arr.Length == 0) return -1;
            // perform recursive search
            return BinarySearchRecursive(ref arr, ref item, 0, arr.Length);
        }

        private static int BinarySearchRecursive(ref T[] arr, ref T item, int min, int max)
        {
            // set the middle index to the index between the min and max
            int middleIndex = ((max - min) / 2) + min;

            // if the item at the middle index is the searching item, return it
            if (arr[middleIndex].CompareTo(item) == 0) return middleIndex;
            // else if the item's greater than the item at mid index
            else if (arr[middleIndex].CompareTo(item) < 0)
            {
                // if mid index is the end of the array, return -1
                if (middleIndex + 1 == arr.Length) return -1;
                // otherwise run again with mid index as the new min
                return BinarySearchRecursive(ref arr, ref item, middleIndex, max);
            }
            // else
            else
            {
                // if mid index is 0, return -1
                if (middleIndex == 0) return -1;
                // otherwise run again with mid index as the new max
                return BinarySearchRecursive(ref arr, ref item, min, middleIndex);
            }
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            // return 0 if both arrays are empty
            if (nums1.Length == 0 && nums2.Length == 0) return 0;
            // return the median of nums2 if nums1 is empty
            if (nums1.Length == 0) return (nums2.Length % 2 != 0) ? nums2[nums2.Length / 2] : 
                    (nums2[nums2.Length / 2] + (double)nums2[(nums2.Length / 2) - 1] / 2);
            // return the median of nums1 if nums2 is empty
            if (nums2.Length == 0) return (nums1.Length % 2 != 0) ? nums1[nums1.Length / 2] :
                    (nums1[nums1.Length / 2] + (double)nums1[(nums1.Length / 2) - 1] / 2);

            // if nums1 fits within nums2, swap the main logic
            if (nums2[0] <= nums1[0] && nums2[nums2.Length - 1] >= nums1[nums1.Length - 1]) return FindMedianMainLogic(ref nums2, ref nums1);
            // else, find the median as normal
            else return FindMedianMainLogic(ref nums1, ref nums2);
        }

        private static double FindMedianMainLogic(ref int[] nums1, ref int[] nums2)
        {
            // working index = nums1 length / 2
            int workingIndex = nums1.Length / 2;
            // loop until return 
            while (true)
            {
                // if working index is 0 
                if (workingIndex == 0)
                {
                    // if item at working index is greater than nums2 index 0
                    if (nums1[0] > nums2[0])
                    {
                        // calculate the median with nums2 first and nums1 second
                        return CalculateMedian(ref nums2, ref nums1);
                    }
                    // otherwise, do the opposite
                    else
                    {
                        return CalculateMedian(ref nums1, ref nums2);
                    }
                }
                // else if item at working index - 1 > nums2 index 0 
                else if (nums1[workingIndex - 1] > nums2[0])
                {
                    // restart with working index / 2
                    workingIndex = workingIndex / 2;
                    continue;
                }
                // else if item at working index <= nums2 index 0
                else if (nums1[workingIndex] <= nums2[0])
                {
                    // if the working index is the end of array 1, calculate result starting with nums1 then nums2
                    if (workingIndex == nums1.Length - 1)
                    {
                        return CalculateMedian(ref nums1, ref nums2);
                    }
                    // otherwise, restart with working index = working index + (nums1 length - working index)/2
                    else
                    {
                        workingIndex = workingIndex + ((nums1.Length - workingIndex) / 2);
                        continue;
                    }
                }
                // else arrays 1 and 2 must be combined
                else
                {
                    // store combined length
                    int combinedLength = nums1.Length + nums2.Length;
                    // store the upper median index
                    int medianIndex = combinedLength / 2;
                    // if there aren't an even total number of items
                    if ((nums1.Length + nums2.Length) % 2 != 0)
                    {
                        // if medianIndex is in the bounds of working index -1, find its spot in the first part of the first array
                        if (medianIndex < workingIndex - 1) return nums1[medianIndex];
                        // if it's within the bounts of working index -1 plus the length of array 2, find its spot in the second array
                        else if (medianIndex < (workingIndex + nums2.Length)) return nums2[medianIndex - (workingIndex)];
                        // else, find its spot in the second part of the first array
                        else return nums1[medianIndex - nums2.Length];
                    }
                    // otherwise
                    {
                        // store the lower median index
                        int lowerMedianIndex = (combinedLength / 2) - 1;

                        // find the lower number
                        double lowerNumber;
                        if (medianIndex < workingIndex - 1) lowerNumber = nums1[medianIndex];
                        else if (medianIndex < (workingIndex + nums2.Length)) lowerNumber = nums2[medianIndex - (workingIndex)];
                        else lowerNumber = nums1[medianIndex - nums2.Length];

                        // find the upper number
                        double upperNumber;
                        if (medianIndex < workingIndex - 1) upperNumber = nums1[medianIndex];
                        else if (medianIndex < (workingIndex + nums2.Length)) upperNumber = nums2[medianIndex - (workingIndex)];
                        else upperNumber = nums1[medianIndex - nums2.Length];

                        // return lower number + upper number divided by 2
                        return (lowerNumber + upperNumber) / 2;
                    }
                }
            }
        }

        private static double CalculateMedian(ref int[] nums1, ref int[] nums2)
        {
            // store combined length
            int combinedLength = nums1.Length + nums2.Length;
            // store the upper median index
            int medianIndex = combinedLength / 2;
            // if there aren't an even total number of items
            if ((nums1.Length + nums2.Length) % 2 != 0)
            {
                // return the number at the index in array 1 if the middle index is in array one
                if (medianIndex < nums1.Length) return nums1[medianIndex];
                // if it isn't, return the number at the index in array 2 - length of array 1
                else return nums2[medianIndex - nums1.Length];
            }
            // otherwise
            else
            {
                // store the lower median index
                int lowerMedianIndex = (combinedLength / 2) - 1;
                // find the lower number whether it's in array 1 or 2
                double lowerNumber = (lowerMedianIndex < nums1.Length) ? nums1[lowerMedianIndex] : nums2[lowerMedianIndex - nums1.Length];
                // find the upper number whether it's in array 1 or 2
                double upperNumber = (medianIndex < nums1.Length) ? nums1[medianIndex] : nums2[medianIndex - nums1.Length];
                // return lower number + upper number divided by 2
                return (lowerNumber + upperNumber) / 2;
            }
        }
    }
}
