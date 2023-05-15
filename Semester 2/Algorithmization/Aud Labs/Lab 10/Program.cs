using Casual;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using static Program;

internal class Program
{
    private static void Main(string[] args)
    {
        var numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var numbersQuery = from number in numbers
                         select number;
        Console.WriteLine(numbersQuery.Min());

        foreach (var number in new List<int>(numbers))
            if (number % 2 == 0)
                numbers.Remove(number);

        Console.WriteLine(numbersQuery.Min());
    }
}
