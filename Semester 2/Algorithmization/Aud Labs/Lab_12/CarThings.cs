using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casual
{
    internal class Car
    {
        public string Number { get; set; }
        public string Brand { get; set; }

        public Car(string number, string brand)
        {
            Number = number;
            Brand = brand;
        }
    }


    internal class Driver
    {
        private int lastId = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string CarNumber { get; set; }

        public Driver(string name, string carNumber)
        {
            Id = ++lastId;
            Name = name;
            CarNumber = carNumber;
        }
    }
}
