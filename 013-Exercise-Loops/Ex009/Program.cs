namespace Ex009;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Please, enter your password.");
        var passWord = Console.ReadLine();

        while (passWord != "myPass")
        {
            Console.WriteLine("Wrong Pass");
            Console.WriteLine("Please enter new password");
            passWord = Console.ReadLine();
        }

        Console.WriteLine("Welcome");
    }
}