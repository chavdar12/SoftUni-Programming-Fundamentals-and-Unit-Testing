namespace Ex004;

internal class Program
{
    private static void Main(string[] args)
    {
        var sideA = int.Parse(Console.ReadLine()!);
        var sideB = int.Parse(Console.ReadLine()!);
        var height = int.Parse(Console.ReadLine()!);

        var area = (sideA + sideB) * height / 2.0;

        Console.WriteLine(area);
    }
}