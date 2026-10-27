using System;

namespace TestApp;

public class Factorial
{
    public static int CalculateFactorial(int n)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(n);

        if (n == 0) return 1;

        return n * CalculateFactorial(n - 1);
    }
}