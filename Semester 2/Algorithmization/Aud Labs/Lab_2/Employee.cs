using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    internal class Employee
    {
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public List<List<object>> EmpHistory { get; set; }

        public Employee(string fullName, string jobTitle, List<List<object>> empHistory)
        {
            FullName = fullName;
            JobTitle = jobTitle;
            EmpHistory = empHistory;
        }
    }
}
