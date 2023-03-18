using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    internal class Support : Employee
    {
        public List<DateTime> CompletedWork { get; set; }
        public Support(List<DateTime> completedWork, string fullName, string jobTitle, List<List<object>> empHistory) 
            : base(fullName, jobTitle, empHistory)
        {
            CompletedWork = completedWork;
        }
    }
}
