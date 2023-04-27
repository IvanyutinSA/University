using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Casual
{
    internal class Car
    {
        public string Name { get; set; }
        public int Id { init; get; }
        private static int lastIndex = 0;

        public Car(string name)
        {
            this.Id = ++lastIndex;
            this.Name = name;
        }
    }
}
