using System;

namespace TestApp;

public class Reverse
{
    public static string ReverseArray(int[] arr)
    {
        return string.Join(" ", Enumerable.Reverse(arr));
    }
}