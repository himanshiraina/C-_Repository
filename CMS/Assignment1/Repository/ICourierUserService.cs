using Assignment1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Repository
{
    internal interface ICourierUserService
    {
        // Customer-related functions

        // Place a new courier order
        public string PlaceOrder(Courier courierObj);

        public void po(Orders o);

        // Get the status of a courier order
        string GetOrderStatus(string trackingNumber);

        // Cancel a courier order
        bool CancelOrder(string trackingNumber);

        // Courier Staff-related functions

        // Assign a courier staff member to deliver an order
        bool AssignCourier(string trackingNumber, int courierStaffId);

        // Mark an order as delivered
        bool MarkOrderDelivered(string trackingNumber);

        // Get a list of orders assigned to a specific courier staff member
        List<string> GetAssignedOrders(int courierStaffId);
    }


    }
