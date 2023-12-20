using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities
{
    internal class Employee
    {
        long employeeID;
        string employeename;
        string email;
        long contactnumber;
        string role;
        double salary;

        public long EmployeeID { get { return employeeID; } set { employeeID = value; } }
        public string Name { get { return employeename; } set { employeename = value; } }
        public string Email { get { return email; } set { email = value; } }
        public long ContactNumber { get { return contactnumber; } set { contactnumber = value; } }
        public string Role { get { return role; } set { role = value; } }
        public double Salary { get { return salary; } set { salary = value; } }
 
        public Employee(long employeeID, string employeename, string email, long contactnumber, string role,
            double salary)
        {
            EmployeeID = employeeID;
            Name = employeename;
            Email = email;
            ContactNumber = contactnumber;
            Role = role;
            Salary = salary;
        }
    }
}


