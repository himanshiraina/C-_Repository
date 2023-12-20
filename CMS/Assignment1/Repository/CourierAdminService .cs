using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Entities;
namespace Assignment1.Repository
{
    internal class CourierAdminService :  ICourierAdminService
    {
        public CourierAdminService()
        {
            
        }

        private const string connectionString = "Server=LAPTOP-MK5JT9DU;Database=CMS;Trusted_Connection=True";

        public int AddCourierStaff(Admin obj)
        {
            // SQL query to insert a new record into the CourierStaff table
            string insertQuery = "INSERT INTO ADMIN (Courier_StaffID, NAME, CONTACT_NO) VALUES (@Name, @Department, @contact)";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", obj.Courier_StaffID);
                    command.Parameters.AddWithValue("@Department", obj.NAME);
                    command.Parameters.AddWithValue("@contact", obj.CONTACT_NO);
                    // Add other parameters as needed for the columns in your table

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    // You may need to retrieve the ID of the newly added staff member, 
                    // depending on how your database handles auto-generated IDs.
                    // For example, if your ID column is auto-incremented, 
                    // you might need to fetch the last inserted ID.
                    // This example assumes an auto-incrementing ID column named 'Id'.
                    string getLastIdQuery = "SELECT SCOPE_IDENTITY() AS LastId";
                    using (SqlCommand getLastIdCommand = new SqlCommand(getLastIdQuery, connection))
                    {
                        connection.Open();
                        object result = getLastIdCommand.ExecuteScalar();
                        connection.Close();

                        int lastInsertedId = 0;
                        if (result != null && int.TryParse(result.ToString(), out lastInsertedId))
                        {
                            return lastInsertedId; // Return the last inserted ID
                        }
                        else
                        {
                            return -1; // Failed to retrieve the last inserted ID
                        }
                    }
                }
            }
        }
        public bool RemoveCourierStaff(int courierStaffId)
        {
            // SQL query to delete a staff member based on ID from the CourierStaff table
            string deleteQuery = "DELETE FROM Admin WHERE Courier_StaffID = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", courierStaffId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        return true; // Successfully removed staff member
                    }
                    else
                    {
                        return false; // Staff member with the provided ID was not found
                    }
                }
            }
        }
        public string GenerateDeliveryReport(DateTime startDate, DateTime endDate)
        {
            StringBuilder report = new StringBuilder("Delivery Report:\n");

            string selectQuery = "SELECT OrderId, DeliveryDate FROM Orders WHERE DeliveryDate >= @StartDate AND DeliveryDate <= @EndDate";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate.Date);
                    command.Parameters.AddWithValue("@EndDate", endDate.Date);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int orderId = Convert.ToInt32(reader["OrderId"]);
                        DateTime deliveryDate = Convert.ToDateTime(reader["DeliveryDate"]);

                        report.AppendLine($"Order ID: {orderId}, Delivered On: {deliveryDate}");
                    }

                    reader.Close();
                }
            }

            return report.ToString();
        }

    }
}
