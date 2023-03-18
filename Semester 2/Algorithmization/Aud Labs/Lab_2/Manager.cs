using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    internal class Manager : Employee
    {
        public List<string> Orders { get; set; }

        public Manager(List<string> orders, string fullName, string jobTitle, List<List<object>> empHistory) 
            : base (fullName, jobTitle, empHistory)
        {
            Orders = orders;
        }
    }
}
