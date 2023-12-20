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
        string employeeName;
        string email;
        long contactNumber;
        string role;
        double salary;

        // Default constructor
        public Employee()
        {
            //dc
        }
        // Parameterized constructor
        public Employee(long employeeID, string employeeName, string email, long contactNumber, string role, double salary)
        {
            this.employeeID = employeeID;
            this.employeeName = employeeName;
            this.email = email;
            this.contactNumber = contactNumber;
            this.role = role;
            this.salary = salary;
        }

        // Getter and Setter for EmployeeID
        public long EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        // Getters and Setters
        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public long ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        // ToString method to represent object as a string
        public override string ToString()
        {
            return $"EmployeeID: {employeeID}, EmployeeName: {employeeName}, Role: {role}, Salary: {salary}";
        }
    }
}


