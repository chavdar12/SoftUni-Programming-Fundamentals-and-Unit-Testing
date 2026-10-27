using System.Globalization;
using System.Reflection;

namespace ConsoleApps.Tests;

// Each program is referenced by the csproj; its assembly name is "<chapter>-<folder>".
public class ProgramTests
{
    private static string Run(string program, string input)
    {
        var stdin = Console.In;
        var stdout = Console.Out;
        var output = new StringWriter(CultureInfo.InvariantCulture);
        try
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            Console.SetIn(new StringReader(input));
            Console.SetOut(output);
            Assembly.Load(program).EntryPoint!.Invoke(null, [Array.Empty<string>()]);
        }
        finally
        {
            Console.SetIn(stdin);
            Console.SetOut(stdout);
        }

        return output.ToString().ReplaceLineEndings("\n").TrimEnd();
    }

    // 002 Simple Commands
    [TestCase("002-Ex001", "", "Hello C#")]
    [TestCase("002-Ex002", "", "25")]
    [TestCase("002-Ex003", "", "Chavdar\n8")]
    [TestCase("002-Ex004", "", "11\n20\n6")]
    [TestCase("002-Ex005", "2", "* * \n* * \nHello, SoftUni")]
    // 003 Visual Studio
    [TestCase("003-Ex001", "", "Hello, SoftUni")]
    [TestCase("003-Ex002", "Peter", "Hello Peter")]
    [TestCase("003-Ex003", "John\nSmith\nj@s.com", "Customer: John Smith (j@s.com)")]
    [TestCase("003-Ex004", "John\nSmith\nBulgaria\nSofia", "John Smith from Bulgaria - Sofia!")]
    [TestCase("003-Ex005", "Sofia\nBulgaria", "Sofia is in Bulgaria")]
    // 004 Exercise: Simple Commands and Visual Studio
    [TestCase("004-Ex001", "echo", "echo")]
    [TestCase("004-Ex002", "5", "25")]
    [TestCase("004-Ex003", "3\n4", "12")]
    [TestCase("004-Ex004", "3\n4\n5", "17.5")]
    [TestCase("004-Ex004", "8\n13\n7", "73.5")]
    [TestCase("004-Ex005", "3\n4\n5", "12")]
    [TestCase("004-Ex006", "5", "12.7")]
    // 005 Data Types and Variables
    [TestCase("005-Ex001", "2", "Minutes = 2880")]
    [TestCase("005-Ex002", "100\n3", "33.33")]
    [TestCase("005-Ex003", "2", "Area = 12.57\nPerimeter = 12.57")]
    [TestCase("005-Ex004", "1500", "1.50")]
    [TestCase("005-Ex005", "100", "212.00")]
    [TestCase("005-Ex006", "2\n3", "17.00 lv.")]
    [TestCase("005-Ex007", "Sanya\n4", "The architect Sanya will need 12 hours to complete 4 project/s.")]
    // 006 Simple Calculations
    [TestCase("006-Ex001", "100", "88.00")]
    [TestCase("006-Ex002", "5\n2", "5.00 + 2.00 = 7.00\n5.00 - 2.00 = 3.00\n5.00 * 2.00 = 10.00\n5.00 / 2.00 = 2.50")]
    [TestCase("006-Ex003", "2\n3\n1.5\n2", "9.00")]
    [TestCase("006-Ex004", "2\n3\n0.5\n0.5", "26")]
    [TestCase("006-Ex005", "200\n3\n5.7", "202.85")]
    [TestCase("006-Ex006", "212\n20\n2", "5")]
    [TestCase("006-Ex007", "2\n3\n4\n25", "28.5")]
    [TestCase("006-Ex007", "2\n3\n4\n0", "38")]
    // 007 Exercise: Data Types, Variables and Simple Calculations
    [TestCase("007-Ex001", "", "Hello, World!")]
    // 008 Simple Conditional Statements
    [TestCase("008-Ex001", "-5", "Freezing weather!")]
    [TestCase("008-Ex001", "5", "")]
    [TestCase("008-Ex002", "3", "odd")]
    [TestCase("008-Ex002", "4", "even")]
    [TestCase("008-Ex003", "3", "three")]
    [TestCase("008-Ex003", "10", "out of range")]
    [TestCase("008-Ex004", "5\n3", "Greater number: 5")]
    [TestCase("008-Ex004", "3\n5", "Greater number: 5")]
    [TestCase("008-Ex005", "s3cr3t!", "Welcome")]
    [TestCase("008-Ex005", "secret", "Wrong password!")]
    [TestCase("008-Ex006", "101", "The water is boiling")]
    [TestCase("008-Ex006", "100", "The water is not hot enough")]
    [TestCase("008-Ex007", "30", "Slow")]
    [TestCase("008-Ex007", "31", "Fast")]
    [TestCase("008-Ex008", "student", "$1.00")]
    [TestCase("008-Ex008", "regular", "$1.60")]
    [TestCase("008-Ex008", "vip", "Invalid ticket type!")]
    [TestCase("008-Ex009", "square\n5", "25.00")]
    [TestCase("008-Ex009", "rectangle\n7\n2.5", "17.50")]
    [TestCase("008-Ex009", "circle\n6", "113.10")]
    [TestCase("008-Ex010", "3\n4\n5", "Valid Triangle")]
    [TestCase("008-Ex010", "1\n2\n10", "Invalid Triangle")]
    [TestCase("008-Ex011", "coffee\nsugar", "Final price: $1.40")]
    [TestCase("008-Ex011", "tea\nno", "Final price: $0.60")]
    // 009 Complex Conditional Statements
    [TestCase("009-Ex001", "Banana\nWeekday", "2.50")]
    [TestCase("009-Ex001", "Kiwi\nWeekend", "3.00")]
    [TestCase("009-Ex002", "1\n3\n2", "3")]
    [TestCase("009-Ex002", "-5\n-2\n-9", "-2")]
    [TestCase("009-Ex003", "2", "7")]
    [TestCase("009-Ex003", "8", "28")]
    [TestCase("009-Ex004", "sushi", "food")]
    [TestCase("009-Ex004", "juice", "drink")]
    [TestCase("009-Ex004", "rock", "unknown")]
    [TestCase("009-Ex005", "50", "invalid")]
    [TestCase("009-Ex005", "150", "")]
    [TestCase("009-Ex005", "0", "")]
    [TestCase("009-Ex006", "3", "Wednesday")]
    [TestCase("009-Ex006", "8", "Error")]
    [TestCase("009-Ex007", "e", "Vowel")]
    [TestCase("009-Ex007", "b", "Consonant")]
    [TestCase("009-Ex008", "1\n2\n3", "Ascending")]
    [TestCase("009-Ex008", "3\n2\n1", "Descending")]
    [TestCase("009-Ex008", "1\n3\n2", "Not sorted")]
    [TestCase("009-Ex009", "Premiere\n10\n12", "1440.00")]
    [TestCase("009-Ex009", "Normal\n21\n13", "2047.50")]
    // 010 Exercise: Simple and Complex Conditional Statements
    [TestCase("010-Ex001", "", "Hello, World!")]
    // 011 For Loop
    [TestCase("011-Ex001", "3\n5", "3\n4\n5")]
    [TestCase("011-Ex002", "4", "1+2+3+4=10")]
    [TestCase("011-Ex003", "3\n1\n2.5\n3", "6.5")]
    [TestCase("011-Ex004", "30", "7\n17\n27")]
    [TestCase("011-Ex005", "10", "1\n4\n7\n10")]
    [TestCase("011-Ex006", "2", "2 days before the exam\n1 days before the exam\nThe exam has come")]
    [TestCase("011-Ex007", "a\nd", "a b c d")]
    // 012 While Loop
    [TestCase("012-Ex001", "", "Hello, World!")]
    // 013 Exercise: Loops
    [TestCase("013-Ex001", "2\n10", "1024")]
    [TestCase("013-Ex001", "5\n0", "1")]
    [TestCase("013-Ex002", "3", "3 x 1 = 3\n3 x 2 = 6\n3 x 3 = 9\n3 x 4 = 12\n3 x 5 = 15\n3 x 6 = 18\n3 x 7 = 21\n3 x 8 = 24\n3 x 9 = 27\n3 x 10 = 30")]
    [TestCase("013-Ex003", "3\n-5\n10\n2", "10")]
    [TestCase("013-Ex004", "", "Hello, World!")]
    [TestCase("013-Ex005", "4\n2\n3\n4\n6", "75.00%\n50.00%\n25.00%")]
    [TestCase("013-Ex006", "12", "12 is special")]
    [TestCase("013-Ex006", "13", "13 is not special")]
    [TestCase("013-Ex006", "10", "10 is not special")]
    [TestCase("013-Ex007", "5\n1\n2\n5", "2.4")]
    [TestCase("013-Ex008", "120\n-45.5\nEnd", "Increase: 120.00\nDecrease: 45.50\nBalance: 74.50")]
    [TestCase("013-Ex009", "abc\nmyPass", "Please, enter your password.\nWrong Pass\nPlease enter new password\nWelcome")]
    [TestCase("013-Ex009", "myPass", "Please, enter your password.\nWelcome")]
    // 014 Nested Loops and 016 Exercise: Nested Loops and Methods (same exercises)
    [TestCase("014-Ex001", "3", "212 236")]
    [TestCase("016-Ex001", "3", "212 236")]
    [TestCase("014-Ex002", "2", "112 121 211")]
    [TestCase("016-Ex002", "2", "112 121 211")]
    [TestCase("014-Ex003", "3\n5\n5", "222\n224\n232\n234\n252\n254")]
    [TestCase("016-Ex003", "3\n5\n5", "222\n224\n232\n234\n252\n254")]
    [TestCase("014-Ex004", "a\nc\nb", "aaa aac aca acc caa cac cca ccc \n8")]
    [TestCase("016-Ex004", "a\nc\nb", "aaa aac aca acc caa cac cca ccc \n8")]
    [TestCase("014-Ex005", "1", "1001 1010")]
    [TestCase("016-Ex005", "1", "1001 1010")]
    [TestCase("014-Ex006", "SoftUni", "3")]
    [TestCase("016-Ex006", "SoftUni", "3")]
    [TestCase("014-Ex007", "5\n2", "60.00")]
    [TestCase("014-Ex007", "15\n13", "210.00")]
    [TestCase("016-Ex007", "5\n2", "60.00")]
    [TestCase("016-Ex007", "15\n13", "210.00")]
    [TestCase("014-Ex008", "2\n-3\n-4", "positive")]
    [TestCase("014-Ex008", "-1\n2\n3", "negative")]
    [TestCase("014-Ex008", "0\n5\n1", "zero")]
    [TestCase("016-Ex008", "2\n-3\n-4", "positive")]
    [TestCase("016-Ex008", "-1\n2\n3", "negative")]
    [TestCase("016-Ex008", "0\n5\n1", "zero")]
    [TestCase("014-Ex009", "MyPass123", "Password is valid")]
    [TestCase("014-Ex009", "logIn", "Password must be between 6 and 10 characters\nPassword must have at least 2 digits")]
    [TestCase("014-Ex009", "Pa$s$s", "Password must consist only of letters and digits\nPassword must have at least 2 digits")]
    [TestCase("016-Ex009", "MyPass123", "Password is valid")]
    [TestCase("016-Ex009", "logIn", "Password must be between 6 and 10 characters\nPassword must have at least 2 digits")]
    [TestCase("016-Ex009", "Pa$s$s", "Password must consist only of letters and digits\nPassword must have at least 2 digits")]
    // 015 Methods
    [TestCase("015-Ex001", "2", "The number 2 is positive.")]
    [TestCase("015-Ex001", "0", "The number 0 is zero.")]
    [TestCase("015-Ex001", "-5", "The number -5 is negative.")]
    [TestCase("015-Ex002", "2.99", "Fail")]
    [TestCase("015-Ex002", "3.495", "Average")]
    [TestCase("015-Ex002", "4.50", "Very good")]
    [TestCase("015-Ex002", "5.6", "Excellent")]
    [TestCase("015-Ex003", "3", "1 \n1 2 \n1 2 3 \n1 2 \n1")]
    [TestCase("015-Ex004", "3\n4", "12")]
    [TestCase("015-Ex005", "abc\n3", "abcabcabc")]
    [TestCase("015-Ex006", "2\n8", "256")]
    [TestCase("015-Ex006", "5.5\n3", "166.375")]
    [TestCase("015-Ex006", "3\n0", "1")]
    [TestCase("015-Ex007", "int\n2\n16", "16")]
    [TestCase("015-Ex007", "char\na\nz", "z")]
    [TestCase("015-Ex007", "string\naaa\nbbb", "bbb")]
    [TestCase("015-Ex007", "string\nbbb\naaa", "bbb")]
    [TestCase("015-Ex008", "-12345", "54")]
    [TestCase("015-Ex009", "water\n5", "5.00")]
    [TestCase("015-Ex009", "coffee\n2", "3.00")]
    // 017 Arrays
    [TestCase("017-Ex001", "1", "Monday")]
    [TestCase("017-Ex001", "7", "Sunday")]
    [TestCase("017-Ex001", "8", "Invalid day!")]
    [TestCase("017-Ex002", "1 2 3", "6")]
    [TestCase("017-Ex003", "3\n10\n20\n30", "30 20 10")]
    [TestCase("017-Ex004", "1 2 3 4 5 6", "3")]
    [TestCase("017-Ex005", "1 2 3\n1 2 3", "Arrays are identical.")]
    [TestCase("017-Ex005", "1 2 3\n1 2 4", "Arrays are not identical.")]
    [TestCase("017-Ex005", "1 2\n1 2 3", "Arrays are not identical.")]
    [TestCase("017-Ex006", "1 2 3\n3 4 1", "1 3")]
    // 018 Lists
    [TestCase("018-Ex001", "1 2 3 2\nDelete 2\nInsert 5 0\nend", "5 1 3")]
    [TestCase("018-Ex002", "3\nTomatoes\nPotatoes\nBread", "1.Bread\n2.Potatoes\n3.Tomatoes")]
    [TestCase("018-Ex003", "10 -5 7 9 -33 50", "50 9 7 10")]
    [TestCase("018-Ex003", "-1 -2", "empty")]
    [TestCase("018-Ex004", "4 19 2 53 6 43\nAdd 3\nRemove 2\nRemoveAt 1\nInsert 8 3\nend", "4 53 6 8 43 3")]
    [TestCase("018-Ex005", "2 13 43 876 342 23 543\nContains 100\nContains 543\nPrintEven\nPrintOdd\nGetSum\nFilter >= 43\nend",
        "No such number\nYes\n2 876 342 \n13 43 23 543 \n1842\n43 876 342 543")]
    [TestCase("018-Ex006", "", "Hello, World!")]
    // 019 Exercise: Arrays and Lists
    [TestCase("019-Ex001", "", "Hello, World!")]
    // 023 Exam Preparation
    [TestCase("023-Ex001", "1234", "26")]
    [TestCase("023-Ex002", "1 2 3 4", "2.50")]
    public void Program_PrintsExpectedOutput(string program, string input, string expected)
    {
        Assert.That(Run(program, input), Is.EqualTo(expected));
    }
}
