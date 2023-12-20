using Assignment1.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Repository
{
    internal class CourierUserService : ICourierUserService
    {
        private Dictionary<string, string> orders = new Dictionary<string, string>(); // Tracking number -> order status
        private Dictionary<string, int> assignedCouriers = new Dictionary<string, int>(); // Tracking number -> courier staff ID

        private const string connectionString = "Server=LAPTOP-MK5JT9DU;Database=CMS;Trusted_Connection=True";

        public string PlaceOrder(Courier courierObj)
        {

            Console.WriteLine(courierObj.DeliveryDate);
            // Validate delivery date format
            if (!DateTime.TryParseExact(courierObj.DeliveryDate.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validatedDate))
            {
                return "Invalid date format. Please enter the date in yyyy-MM-dd format.";
            }

            // Check if the validated date is within the allowed range
            if (validatedDate < SqlDateTime.MinValue.Value || validatedDate > SqlDateTime.MaxValue.Value)
            {
                return "Delivery date is outside the allowed range.";
            }

            string trackingNumber = courierObj.trackingNumber.ToString();

            // Insert query for SQL
            string insertQuery = "INSERT INTO Courier (CourierID, SenderName, SenderAddress, ReceiverName, ReceiverAddress, Weight, Status, TrackingNumber, DeliveryDate) " +
                                 "VALUES (@CourierID, @SenderName, @SenderAddress, @ReceiverName, @ReceiverAddress, @Weight, @Status, @TrackingNumber, @DeliveryDate)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@CourierID", courierObj.CourierID);
                    command.Parameters.AddWithValue("@SenderName", courierObj.SenderName);
                    command.Parameters.AddWithValue("@SenderAddress", courierObj.SenderAddress);
                    command.Parameters.AddWithValue("@ReceiverName", courierObj.ReceiverName);
                    command.Parameters.AddWithValue("@ReceiverAddress", courierObj.ReceiverAddress);
                    command.Parameters.AddWithValue("@Weight", courierObj.Weight);
                    command.Parameters.AddWithValue("@Status", courierObj.Status);
                    command.Parameters.AddWithValue("@TrackingNumber", courierObj.TrackingNumber);
                    command.Parameters.AddWithValue("@DeliveryDate", courierObj.DeliveryDate);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            return courierObj.trackingNumber.ToString(); // Successfully added to the database
                        }
                        else
                        {
                            return "Failed to place order"; // Insertion failed
                        }
                    }
                    catch (IOException ex)
                    {
                        return "Error: " + ex.Message; // Handle exception
                    }
                }
            }
        }

        public void po(Orders o)
        {
            // Insert query for SQL
            string iq = "INSERT INTO Orders (OrderId, DeliveryDate, CustomerId) VALUES (@oid, @dd, @cid)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(iq, connection))
                {
                    command.Parameters.AddWithValue("@oid", o.OrderId);
                    command.Parameters.AddWithValue("@dd", o.DeliveryDate);
                    command.Parameters.AddWithValue("@cid", o.CustomerId);
                    
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                      
                }
            }
        }
    

        public string GetOrderStatus(string trackingNumber)
        {
            // SQL query to fetch status based on tracking number
            string selectQuery = "SELECT Status FROM Courier WHERE TrackingNumber = @TrackingNumber";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    connection.Close();

                    if (result != null)
                    {
                        return result.ToString();
                    }
                    else
                    {
                        return "Order not found";
                    }
                }
            }
        }

        public bool CancelOrder(string trackingNumber)
        {
            // SQL query to delete an order based on the tracking number
            string deleteQuery = "DELETE FROM Courier WHERE TrackingNumber = @TrackingNumber";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool AssignCourier(string trackingNumber, int courierStaffId)
        {
            string updateQuery = "UPDATE Courier SET CourierStaffId = @CourierStaffId WHERE TrackingNumber = @TrackingNumber";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@CourierStaffId", courierStaffId);
                    command.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool MarkOrderDelivered(string trackingNumber)
        {
            // SQL query to update the status of a delivered order
            string updateQuery = "UPDATE Courier SET Status = 'Delivered' WHERE TrackingNumber = @TrackingNumber";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        return true; // Successfully marked order as delivered
                    }
                    else
                    {
                        return false; // Order with the provided tracking number was not found
                    }
                }
            }
        }

        public List<string> GetAssignedOrders(int courierStaffId)
        {
            List<string> assignedOrders = new List<string>();

            // SQL query to retrieve assigned orders for a specific courier staff ID
            string selectQuery = "SELECT TrackingNumber FROM Courier WHERE CourierStaffId = @CourierStaffId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@CourierStaffId", courierStaffId);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string trackingNumber = reader["TrackingNumber"].ToString();
                        assignedOrders.Add(trackingNumber);
                    }

                    reader.Close();
                    connection.Close();
                }
            }

            return assignedOrders;
        }

    }
}
