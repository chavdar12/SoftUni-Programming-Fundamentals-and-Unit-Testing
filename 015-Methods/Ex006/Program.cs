namespace Ex006;

internal class Program
{
    private static void Main(string[] args)
    {
        var baseNumber = double.Parse(Console.ReadLine());
        var power = int.Parse(Console.ReadLine());

        Console.WriteLine(MathPower(baseNumber, power));
    }

    private static double MathPower(double number, int powerNumber)
    {
        double output = 1;

        for (var i = 1; i <= powerNumber; i++) output *= number;

        return output;
    }
}