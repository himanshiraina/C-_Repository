using Assignment1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities
{
    internal class CourierCompany
    {
        string companyName;
        Courier[] courierDetails;
        Employee[] employeeDetails;
        Location[] locationDetails;
        // Default constructor
        public CourierCompany()
        {
            // dc
        }

        // Parameterized constructor
        public CourierCompany(string companyName, Courier[] courierDetails, Employee[] employeeDetails, Location[] locationDetails)
        {
            this.companyName = companyName;
            this.courierDetails = courierDetails;
            this.employeeDetails = employeeDetails;
            this.locationDetails = locationDetails;
        }
        // Getters and Setters
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        public Courier[] CourierDetails
        {
            get { return courierDetails; }
            set { courierDetails = value; }
        }

        public Employee[] EmployeeDetails
        {
            get { return employeeDetails; }
            set { employeeDetails = value; }
        }

        public Location[] LocationDetails
        {
            get { return locationDetails; }
            set { locationDetails = value; }
        }

        // ToString method to represent object as a string
        public override string ToString()
        {
            return $"CompanyName: {companyName}, CourierDetails Length: {courierDetails.Length}, EmployeeDetails Length: {employeeDetails.Length}, LocationDetails Length: {locationDetails.Length}";
        }
    }
}

