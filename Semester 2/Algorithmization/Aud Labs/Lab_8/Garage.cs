using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casual
{
    internal class Garage
    {
        public List<Car> Cars { get; set; }
        public Garage()
        { this.Cars = new List<Car>();}
    }
}
