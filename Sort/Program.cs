using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //SampleMergeSort();
        SampleBinarySearch();
    }

    #region Sort

    /// <summary>
    /// Sample Merge Sort
    /// </summary>
    private static void SampleMergeSort()
    {
        PrintArray(MergeSort(new int[] { 2, 1, 7, 4, 2 }));
        Console.ReadLine();
    }

    /// <summary>
    /// Merge Sort
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    private static int[] MergeSort(int[] arr)
    {
        if (arr == null || arr.Length <= 1)
        {
            return arr;
        }

        int midPoint = arr.Length / 2;
        int[] left = new int[midPoint];
        int[] right;
        var isLengthEven = arr.Length % 2 == 0;
        if (isLengthEven)
        {
            right = new int[midPoint];
        }
        else
        {
            right = new int[midPoint + 1];
        }
        for (var i = 0; i < midPoint; i++)
        {
            left[i] = arr[i];
            right[i] = arr[midPoint + i];
        }
        if (!isLengthEven)
        {
            right[midPoint] = arr[arr.Length - 1];
        }
        var leftSorted = MergeSort(left);
        var rightSorted = MergeSort(right);
        var result = Merge(leftSorted, rightSorted);
        return result;
    }

    /// <summary>
    /// Merge Sort Helper function
    /// </summary>
    /// <param name="left">Left Array</param>
    /// <param name="right">Right Array</param>
    /// <returns>Result Array</returns>
    private static int[] Merge(int[] left, int[] right)
    {
        var resultLength = left.Length + right.Length;
        var result = new int[resultLength];
        var indexLeft = 0;
        var indexRight = 0;
        var indexResult = 0;
        while (indexLeft < left.Length || indexRight < right.Length)
        {
            if (indexLeft < left.Length && indexRight < right.Length)
            {
                if (left[indexLeft] <= right[indexRight])
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            else if (indexLeft < left.Length)
            {
                result[indexResult] = left[indexLeft];
                indexLeft++;
                indexResult++;
            }
            else if (indexRight < right.Length)
            {
                result[indexResult] = right[indexRight];
                indexRight++;
                indexResult++;
            }
        }
        return result;
    }
    #endregion

    #region Binary Search
    // TODO: why all of binary search are not correct?
    /// <summary>
    /// Sample Binary Search
    /// </summary>
    private static void SampleBinarySearch()
    {
        var input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        //var indices = new List<int>();
        //for (var i = 0; i < input.Length; i++)
        //{
        //    var index = BinarySearch(input, input[i]);
        //    indices.Add(index);
        //}
        //PrintArray(indices);
        //Console.ReadLine();
        var index = BinarySearch(input, 4);
        Console.WriteLine(index);
        Console.ReadLine();
    }
    /// <summary>
    /// Binary Search
    /// </summary>
    /// <param name="arr">input array</param>
    /// <param name="targetValue">target value</param>
    /// <returns>target value index, if couldn't find value then return -1 </returns>
    private static int BinarySearch(int[] arr, int targetValue)
    {
        var rightIndex = arr.Length -1;
        var leftIndex = 0;
        while (leftIndex <= rightIndex)
        {
            var midIndex = (int)Math.Floor((leftIndex + rightIndex) / 2.0);
            var midValue = arr[midIndex];
            if (midValue < targetValue)
            {
                leftIndex = midValue + 1;
            }
            else if (midValue > targetValue)
            {
                rightIndex = midIndex -1;
            }
            else
            {
                return midIndex;
            }
        }
        return -1;
    }
    #endregion

    #region Common Test Util
    /// <summary>
    /// Print Array to Console(Helper)
    /// </summary>
    /// <param name="arr">Input Array</param>
    private static void PrintArray(IList<int> arr)
    {
        if (arr == null || arr.Count < 1)
        {
            Console.WriteLine("Empty Array");
        }
        else
        {
            var resultString = "[";
            for (var i = 0; i < arr.Count - 1; i++)
            {
                resultString += $"{arr[i]},";
            }
            resultString += $"{arr[arr.Count - 1]})";
            Console.WriteLine(resultString);
        }
    }
    #endregion
}