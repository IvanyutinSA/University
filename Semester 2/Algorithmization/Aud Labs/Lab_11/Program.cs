using Casual;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using static Program;

internal class Program
{
    private static void Main(string[] args)
    {
        var numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int halfCount= numbers.Count / 2;
        var orderedNumbersFirstHalf = from number in numbers.GetRange(0, halfCount)
                             orderby number descending
                             select number;
        int penalty = numbers.Count - halfCount * 2;
        var orderedNumbersMiddle = from number in numbers.GetRange(halfCount, penalty)
                                  select number;
        
        var orderedNumbersLast = from number in numbers.GetRange(halfCount + penalty, halfCount)
                                 orderby number ascending
                                 select number;

        
        var orderedNumbers = orderedNumbersFirstHalf.Union(orderedNumbersMiddle).Union(orderedNumbersLast);
        foreach (var number in orderedNumbers)
            Console.Write("{0} ", number);
    }
}
