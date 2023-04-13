using System.Security.Cryptography.X509Certificates;

internal class Program
{
    delegate int ThreeOp(int x, int y, int z);
    public static int Minimum (int x, int y) => x < y ? x : y;
    public static int Maximum (int x, int y) => x < y ? y : x;
    private static void Main(string[] args)
    {
        while (true)
        {
            ThreeOp Function = (x, y, z) => 0;
            Console.WriteLine(
                "1. Min\n" +
                "2. Max\n" +
                "3. Sum\n" +
                "4. Prod\n" +
                "5. Average"
                );

            int message = int.Parse(Console.ReadLine());

            switch (message)
            {
                case 1:
                    Function = (x, y, z) => Minimum(x, Minimum(y, z));
                    break;
                case 2:
                    Function = (x, y, z) => Maximum(x, Maximum(y, z));
                    break;
                case 3:
                    Function = (x, y, z) => x + y + z;
                    break;
                case 4:
                    Function = (x, y, z) => x * y * z;
                    break;
                case 5:
                    Function = (x, y, z) => (x + y + z) / 3;
                    break;
            }

            Console.WriteLine("Введите 3 числа");
            int[] line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int x = line[0];
            int y = line[1];
            int z = line[2];

            Console.WriteLine("Результат: " + Function(x, y, z));
            Console.WriteLine("Нажмите клавишу...");
            Console.ReadKey();
            Console.Clear();
}
    }
}
