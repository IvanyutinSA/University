using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casual
{
    internal class CarWashEvent
    {
        private event EventHandler<CarWashEventArgs> CarWash;
        private void OnCarWashEvent(List<Car> cars)
        {
            if (CarWash != null)
            {
                var args = new CarWashEventArgs();
                args.Cars = new List<Car>(cars);
                CarWash(this, args);
            }  
        }
        public void WashCars(Garage garage)
        {
            for (int i = 0; i < garage.Cars.Count; i++)
                CarWash += (sender, args) =>
                {
                    var car = args.Cars[0];
                    Console.WriteLine("Машина {0}, c id={1}, успешно вымыта!", car.Name, car.Id);
                    args.Cars.RemoveAt(0);
                };
            OnCarWashEvent(garage.Cars);
        }
    }
    internal class CarWashEventArgs : EventArgs
    {
        public List<Car> Cars { get; set; }
    }
}
