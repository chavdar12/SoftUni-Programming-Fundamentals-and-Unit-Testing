namespace Ex010;

internal class Program
{
    private static void Main(string[] args)
    {
        var sideA = int.Parse(Console.ReadLine());
        var sideB = int.Parse(Console.ReadLine());
        var sideC = int.Parse(Console.ReadLine());

        if (sideA < sideB + sideC && sideB < sideA + sideC && sideC < sideA + sideB)
            Console.WriteLine("Valid Triangle");
        else
            Console.WriteLine("Invalid Triangle");
    }
}