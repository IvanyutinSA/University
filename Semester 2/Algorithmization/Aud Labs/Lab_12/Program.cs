using Casual;
using System.Security;

internal class Program
{
    private static void Main(string[] args)
    {
        var car1 = new Car("as234c", "VeryCoolBrand");
        var car2 = new Car("as432c", "VeryCoolBrand");
        var car3 = new Car("as555c", "CoolBrand");
        var car4 = new Car("as234c", "VeryCoolBrand");
        var car5 = new Car("av324c", "NiceBrand");

        var cars = new Dictionary<string, Car>();
        cars[car1.Number] = car1;
        cars[car2.Number] = car2;
        cars[car3.Number] = car3;
        cars[car4.Number] = car4;
        cars[car5.Number] = car5;

        var drivers = new List<Driver>();
        drivers.Add(new Driver("sfdsafasdf", car1.Number));
        drivers.Add(new Driver("sfdsafdsff", car2.Number));
        drivers.Add(new Driver("vcvasdf", car3.Number));
        drivers.Add(new Driver("qewte;wqgm", car4.Number));
        drivers.Add(new Driver(";asdgklh", car5.Number));

        var groupedByBrand = from driver in drivers
                             group driver by cars[driver.CarNumber].Brand;

        foreach(var carBrand in groupedByBrand)
        {
            bool isFirstLoop = true;
            foreach(var driver in carBrand)
            {
                if (isFirstLoop)
                {
                    isFirstLoop = false;
                    Console.Write(cars[driver.CarNumber].Brand + ": ");
                }
                    
                Console.Write(driver.Name + ", ");
            }
            Console.WriteLine();
        }

        var driversQuery = from driver in drivers
                           select driver;

        Console.WriteLine("Фамилия водителя начинается с буквы s:");
        foreach(var driver in driversQuery.Where(x => x.Name[0] == 's'))
        {
            Console.WriteLine(driver.Name);
        }
    }
}
