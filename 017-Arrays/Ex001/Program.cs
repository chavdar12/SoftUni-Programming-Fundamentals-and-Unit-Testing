namespace Ex001;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] moreDays =
        [
            "Invalid day!",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
        ];

        var currentDay = int.Parse(Console.ReadLine());

        Console.WriteLine(currentDay is >= 1 and <= 7 ? moreDays[currentDay] : moreDays[0]);
    }
}