using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    internal class Ordinary : Employee
    {
        public Dictionary<DateTime, int> Copies { get; set; }
        public Ordinary(Dictionary<DateTime, int> copies, string fullName, string jobTitle, List<List<object>> empHistory) 
            : base(fullName, jobTitle, empHistory)
        {
            Copies = copies;
        }
    }
}
