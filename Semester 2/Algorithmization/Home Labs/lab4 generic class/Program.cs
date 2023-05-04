using Casual;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using static Program;

internal class Program
{
    private static void Main(string[] args)
    {
        var arr1 = new SomeArray<int>(5);
        arr1.SetValueByIndex(0, 23423);
        arr1.SetValueByIndex(1, 234);
        arr1.Display();
        arr1.DeleteValueByIndex(0);
        arr1.Display();
        arr1.Remove(234);
        arr1.Display();

        Console.WriteLine();
        var arr2 = new SomeArray<string>(5);
        arr2.SetValueByIndex(0, "sdfds");
        arr2.SetValueByIndex(1, "asdfasdg");
        arr2.Display();
        arr2.DeleteValueByIndex(0);
        arr2.Display();
        arr2.Remove("asdfasdg");
        arr2.Display();
    }
}
