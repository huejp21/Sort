using System;

class Program
{
    static void Main(string[] args)
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

    /// <summary>
    /// Print Array to Console(Helper)
    /// </summary>
    /// <param name="arr">Input Array</param>
    private static void PrintArray(int[] arr)
    {
        if (arr == null || arr.Length < 1)
        {
            Console.WriteLine("Empty Array");
        }
        else
        {
            var resultString = "[";
            for (var i = 0; i < arr.Length - 1; i++)
            {
                resultString += $"{arr[i]},";
            }
            resultString += $"{arr[arr.Length - 1]})";
            Console.WriteLine(resultString);
        }
    }
}