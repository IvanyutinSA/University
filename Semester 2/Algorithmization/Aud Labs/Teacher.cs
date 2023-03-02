using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casual
{
    class Teacher
    {
        public string SchoolSubject { get; set; }
        public string FullName { get; set; }
        public string BirthDay { get; set; }
        public string EducCorp { get; set; }

        public List<List<string>> EmpHistory { get; set; }

        public Teacher(string fullName, string schoolSubject, string birthDay, string edCorp, List<List<string>> empHistory)
        {
            this.FullName = fullName;
            this.BirthDay = birthDay;
            this.EducCorp = edCorp;
            this.EmpHistory = empHistory;
            this.SchoolSubject = schoolSubject;
        }
    }
}
