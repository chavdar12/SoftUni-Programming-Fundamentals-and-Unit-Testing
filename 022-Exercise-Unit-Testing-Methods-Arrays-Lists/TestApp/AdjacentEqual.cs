using System;
using System.Collections.Generic;

namespace TestApp;

public class AdjacentEqual
{
    public static string Sum(List<int> numbers)
    {
        var result = new List<int>();

        foreach (var number in numbers)
        {
            result.Add(number);

            // a fresh sum can equal its left neighbour, so keep folding
            while (result.Count > 1 && result[^1] == result[^2])
            {
                result[^2] += result[^1];
                result.RemoveAt(result.Count - 1);
            }
        }

        return string.Join(" ", result);
    }
}