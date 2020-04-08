using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    /**
     * Employee interface - Just in case we want to decouple the Employee class
     **/
    public interface IEmployee
    {
        String GetRole(); // Method which can be overridden in all implementations
    }
}
