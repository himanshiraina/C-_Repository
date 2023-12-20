using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Exception
{
    internal class InvalidEmployeeIdException : IOException
    {
            public int EmployeeID { get; }
            public InvalidEmployeeIdException(int employeeID)
                : base($"Employee with number {employeeID} not found.")
            {
                EmployeeID = employeeID;
            }
    }
}
