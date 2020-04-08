using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    /**
     * Employee class - Base class for all employees
     * This implements the IEmployee interface
     **/
    public class Employee : IEmployee
    {
        /* Properties with private setters. 
         * This is the example of Encapsulation to prevent user from 
         * setting values for these properties from outside this class */
        public String Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public double Salary { get; private set; }
        public String City { get; private set; }

        /* Parameterized constructor for easy initialization of an employee */
        public Employee(String name, DateTime dateOfBirth, double salary, String city)
        {
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
            this.Salary = salary;
            this.City = city;
        }

        /* Interface implementation */
        public string GetRole()
        {
            return this.GetType().ToString();
        }
    }
}
