using Casual;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using static Program;

internal class Program
{
    public delegate void Arithmetic(object sender, MathEventArgs Args);
    private static void Main(string[] args)
    {
        MathEvent arithmeticExample = new MathEvent();

        arithmeticExample.Math += (sender, args) => Console.WriteLine($"Результат вычисления ({args.x} * {args.y}), когда * оператор:");
        arithmeticExample.Math += (sender, args) => Console.WriteLine("1. Сложения: {0}", IArithmetic.Add(args.x, args.y));
        arithmeticExample.Math += (sender, args) => Console.WriteLine("2. Разности: {0}", IArithmetic.Sub(args.x, args.y));
        arithmeticExample.Math += (sender, args) => Console.WriteLine("3. Умножения: {0}", IArithmetic.Prod(args.x, args.y));
        arithmeticExample.Math += (sender, args) =>
        {
            try
            {
                Console.WriteLine("4. Деления: {0}", IArithmetic.Div(args.x, args.y));
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("4. Деления: {0}", "не определенно");
            }
        };

        arithmeticExample.OnMathEvent(4, 5);
    }
}
