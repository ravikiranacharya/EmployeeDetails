using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    /**
     * Manager class - Extending Employee
     * Additional property here is the project that the manager is managing
     **/
    public class Manager : Employee
    {
        public String Project { get; private set; }
        /* Constructor which also initializes the super class */
        public Manager(string name, DateTime dateOfBirth, double salary, string city, string project) 
            : base(name, dateOfBirth, salary, city)
        {
            this.Project = project;
        }
    }
}
