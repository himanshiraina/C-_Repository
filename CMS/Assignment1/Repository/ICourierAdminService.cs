using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Entities;

namespace Assignment1.Repository
{
    internal interface ICourierAdminService
    {
        // Admin functions

        // Add a new courier staff member to the system
        int AddCourierStaff(Admin obj);

        // Remove a courier staff member from the system
        bool RemoveCourierStaff(int courierStaffId);

        // Generate a report of orders delivered within a specified date range
        string GenerateDeliveryReport(DateTime startDate, DateTime endDate);
    }

  
}
