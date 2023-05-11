using Casual;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using static Program;

internal class Program
{
    private static void Main(string[] args)
    {
        var randomValue = new Random();
        var intList = new List<int>() { };
        //for (int i = 0; i < randomValue.Next(5, 20); i++)
        //    intList.Add(randomValue.Next(0, 100));
        intList.Add(0);
        intList.Add(1);
        intList.Add(2);
        intList.Add(3);
        intList.Add(4);    
        intList.Add(5);

        var positiveNumbers = from number in intList
                              where number > 0
                              select number;

        var negativeNumbers = from number in intList
                              where number < 0
                              select number;

        var nonZeroNumbers = positiveNumbers.Union<int>(negativeNumbers);

        var evenNumbers = from number in intList
                          where number % 2 == 0
                          select number;

        Console.WriteLine (
            $"Количество положительных элементов: " +
            $"{positiveNumbers.Count()}"
            );
        Console.WriteLine(
            $"Количество отрицательных элементов: " +
            $"{negativeNumbers.Count()}"
            );

        Console.WriteLine(
            $"Произведение нечётных элементов: " +
            $"{nonZeroNumbers.Aggregate((int x, int y) => x + y)}"
            );

        Console.WriteLine(
            $"Сумма чётных элементов: " +
            $"{evenNumbers.Aggregate((int x, int y) => x + y)}"
            );      
    }
}
