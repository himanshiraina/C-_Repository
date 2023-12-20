// Instantiate services(objects)
using System;
using System.Collections.Generic;
using Assignment1.Entities;
using Assignment1.Repository;
using CMS.Entities;


ICourierUserService NewCourierUserAnalysis = new CourierUserService();
ICourierAdminService NewCourierAdminService = new CourierAdminService();
Courier cc = new Courier();
Orders u = new Orders();
Admin cc1 = new Admin();

string ch = "y";
            do
            {
                Console.WriteLine("Welcome to Courier Management\n");
                Console.WriteLine("\n 1 for Place Order\n 2 for Get Order Status\n 3 for Cancel Order\n 4 for AssignCourier \n 5 for Mark_Order_Delivered \n 6 for Get_Assigned_Orders \n 7 for Add_Courier_Staff \n 8 for RemoveCourierStaff \n 9 for Generate_Delivery_Report  ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Sender Name:");
                        string senderName = Console.ReadLine();

                        Console.WriteLine("Enter Sender Address:");
                        string senderAddress = Console.ReadLine();

                        Console.WriteLine("Enter Receiver Name:");
                        string receiverName = Console.ReadLine();

                        Console.WriteLine("Enter Receiver Address:");
                        string receiverAddress = Console.ReadLine();

                        Console.WriteLine("Enter Weight:");
                        double weight = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Enter Status:");
                        string status = Console.ReadLine();

                        Console.WriteLine("Enter the Date of the Delivery_Date\n"); 
                        int dd = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the Month of the Delivery_Date\n");
                        int mm = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the year of the Delivery_Date\n");
                        int yyyy = int.Parse(Console.ReadLine());

                         DateTime deliveryDate = new DateTime(yyyy, mm, dd);
                        
                        //Console.WriteLine("Enter Delivery Date (yyyy-MM-dd):");
                        //DateTime deliveryDate = Convert.ToDateTime(Console.ReadLine());

                        Console.WriteLine("Enter User ID:");
                        int userID = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Order Id: ");
                        int oid = int.Parse(Console.ReadLine());


                        Console.WriteLine("Enter Customer Id: ");
                        int cusid = int.Parse(Console.ReadLine());

                            u = new Orders() { 
                            OrderId = oid,
                            DeliveryDate = deliveryDate,
                            CustomerId = cusid
                            };  
                
                        Console.WriteLine(deliveryDate);
                        cc = new Courier()
                        {
                            SenderName = senderName,
                            SenderAddress = senderAddress,
                            ReceiverName = receiverName,
                            ReceiverAddress = receiverAddress,
                            Weight = weight,
                            Status = status,
                            DeliveryDate = deliveryDate,
                            UserId = userID
                        };
            NewCourierUserAnalysis.po(u);
            string placeOrderResult = NewCourierUserAnalysis.PlaceOrder(cc);

            

                        Console.WriteLine(placeOrderResult);
                        break;
        case 2:
            Console.WriteLine("Enter Tracking_Number to get order status\n");

            string tt = Console.ReadLine();

            string orderStatus = NewCourierUserAnalysis.GetOrderStatus(tt);

            Console.WriteLine(orderStatus);


            break;

        case 3:
            Console.WriteLine("Enter Tracking_Number to cancel order\n");
            string tt1 = Console.ReadLine();

            // Cancel the courier order
            bool cancelResult = NewCourierUserAnalysis.CancelOrder(tt1);

            Console.WriteLine(cancelResult);

            break;

        case 4:
            Console.WriteLine("Enter Tracking_Number assign courier\n");


            string ttt = Console.ReadLine();

            Console.WriteLine("Enter Courier Staff ID\n");

            int csid = int.Parse(Console.ReadLine());

            bool assignResult = NewCourierUserAnalysis.AssignCourier(ttt, csid);

            Console.WriteLine(assignResult);

            break;

        case 5:

            Console.WriteLine("Enter Tracking_Number mark order as delivered\n");

            string tt12 = Console.ReadLine();

            bool markDeliveredResult = NewCourierUserAnalysis.MarkOrderDelivered(tt12);

            Console.WriteLine(markDeliveredResult);

            break;

        case 6:

            Console.WriteLine("Enter Courier Staff ID\n");

            int courierStaffId = int.Parse(Console.ReadLine());

            List<string> assignedOrders = NewCourierUserAnalysis.GetAssignedOrders(courierStaffId);

            if (assignedOrders.Count > 0)
            {
                Console.WriteLine($"Assigned orders for courier staff ID {courierStaffId}:");
                foreach (var trackingNumber in assignedOrders)
                {
                    Console.WriteLine(trackingNumber);
                }
            }
            else
            {
                Console.WriteLine($"No orders assigned to courier staff ID {courierStaffId}.");
            }


            break;

            case 7:


            Console.WriteLine("Enter Courier Staff ID ... \n");
            int csid1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Name: .... \n");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Contact info .... \n:");
            string cont = Console.ReadLine();

            cc1 = new Admin()
            {

                Courier_StaffID = csid1,
                NAME = name,
            CONTACT_NO = cont


            };

            NewCourierAdminService.AddCourierStaff(cc1);

            break;
        case 8:
            Console.WriteLine("enter courier_staff_id\n");
            int c11 = int.Parse(Console.ReadLine());
            NewCourierAdminService.RemoveCourierStaff(c11);

            break;

        case 9:

            try
            {
                Console.WriteLine("Enter start date (yyyy-mm-dd):");
                DateTime startDate = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Enter end date (yyyy-mm-dd):");
                DateTime endDate = Convert.ToDateTime(Console.ReadLine());

                string report = NewCourierAdminService.GenerateDeliveryReport(startDate, endDate);
                Console.WriteLine(report);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            break;
    }



    Console.WriteLine("Do you want to continue ...  (y/n) \n");
    ch = Console.ReadLine();
    Console.Clear();
}
while (ch == "y");



