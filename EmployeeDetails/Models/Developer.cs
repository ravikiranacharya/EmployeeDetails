using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    /**
     * Developer class - Extending Employee
     * Additional property here is the technology the developer works on
     **/ 
    public class Developer : Employee
    {
        public String Technology { get; private set; }
        /* Constructor which also initializes the super class */
        public Developer(string name, DateTime dateOfBirth, double salary, string city, string technology) 
            : base(name, dateOfBirth, salary, city)
        {
            this.Technology = technology;
        }
    }
}
