using Casual;
using System.Runtime.CompilerServices;

internal class Program
{
    public delegate int Arithmetic(int x, int y);
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine(
                "1. Add\n" +
                "2. Sub\n" +
                "3. Prod\n" +
                "4. Div"
                );

            Arithmetic Function;
            int message = int.Parse(Console.ReadLine());
            switch (message)
            {
                case 1:
                    Function = IArithmetic.Add;
                    break;
                case 2:
                    Function = IArithmetic.Sub;
                    break;
                case 3:
                    Function = IArithmetic.Prod;
                    break;
                case 4:
                    Function = IArithmetic.Div;
                    break;
                default:
                    Function = (x, y) => 0;
                    Console.WriteLine("Такой функции нет");
                    break;
            }
            Console.WriteLine("Введите 2 числа через пробел");
            int[] line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int x = line[0];
            int y = line[1];
            try
            {
                Console.WriteLine(Function(x, y));
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Write("\nНажимите клавишу...");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
