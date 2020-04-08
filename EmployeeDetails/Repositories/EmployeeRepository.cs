using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDetails.Models;

namespace EmployeeDetails.Controllers
{
    /**
     * Repository for Employee
     **/
    public class EmployeeRepository
    {
        public List<Employee> Employees { get; private set; }
        public EmployeeRepository()
        {
            this.Employees = new List<Employee>();
            this.Initialize();
        }

        public void AddEmployee(Employee employee)
        {
            this.Employees.Add(employee);
        }

        /** This is an example of Abstraction. We are preventing the user from accessing the
         * implementation logic of this class **/
        private void Initialize()
        {
            this.AddEmployee(new Developer("Acharya", DateTime.Parse("03-Feb-1992"), 30000, "Hyderabad", "ReactJs"));
            this.AddEmployee(new Manager("Akshay", DateTime.Parse("06-Apr-1992"), 40000, "Mumbai", "Enhancemo"));
            this.AddEmployee(new Manager("Nikhil", DateTime.Parse("21-Sep-1992"), 50000, "Mumbai", "Scratcho"));
            this.AddEmployee(new Manager("Dikshant", DateTime.Parse("27-Aug-1992"), 60000, "Mumbai", "Re-Engineero"));
            this.AddEmployee(new Developer("Rajesh", DateTime.Parse("04-May-1992"), 70000, "Hyderabad", ".NET"));
            this.AddEmployee(new Developer("Dinesh", DateTime.Parse("14-Oct-1992"), 80000, "Hyderabad", "NodeJs"));
            this.AddEmployee(new Developer("Sridhar", DateTime.Parse("24-May-1992"), 90000, "Hyderabad", "SQL"));
            this.AddEmployee(new Developer("Ravi", DateTime.Parse("25-May-1992"), 100000, "Hyderabad", "Salesforce"));
        }

        public List<Employee> GetData()
        {
            return this.Employees;
        }

        /**
         * Method to filter data by property and value
         * Again, this is using Abstraction to hide the internal working from user
         **/ 
        public List<Employee> GetFilteredData(int property, String value)
        {
            switch (property)
            {
                case 0:
                    if (!value.All(Char.IsDigit))
                        throw new Exception("Invalid value");

                    return FilterEmployeesByBirthday(Convert.ToInt32(value));
                case 1:
                    if (!value.All(Char.IsDigit))
                        throw new Exception("Invalid value");

                    return GetEmployeeWithNthHighestSalary(Convert.ToInt32(value));
                case 2:
                    return GetEmployeesByCityName(value);
                default:
                    return this.Employees;
            }
        }

        private List<Employee> FilterEmployeesByBirthday(int weeks)
        {
            return this.Employees
                       .Where(e =>
                               (e.DateOfBirth.DayOfYear >= DateTime.Now.DayOfYear) &&
                               (e.DateOfBirth.DayOfYear <= DateTime.Now.AddDays(7 * Convert.ToInt32(weeks)).DayOfYear))
                       .ToList();
        }

        private List<Employee> GetEmployeeWithNthHighestSalary(int n)
        {
            return this.Employees
                        .OrderByDescending(e => e.Salary)
                        .Select(e => e)
                        .Skip(n-1)
                        .Take(1)
                        .ToList();
        }

        private List<Employee> GetEmployeesByCityName(String city)
        {
            return this.Employees
                .Where(e => e.City.ToUpper().Contains(city.ToUpper()))
                .ToList();
        }
    }

}
