using Casual;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using static Program;

internal class Program
{
    public delegate void EventHandler(object sender,  CarWashEventArgs args);
    private static void Main(string[] args)
    {
        var garage = new Garage();
        for (int i = 1; i < 10; i++)
            garage.Cars.Add(new Car(String.Format("car-{0}", i)));
        var washMashine = new CarWashEvent();
        washMashine.WashCars(garage);
    }
}
