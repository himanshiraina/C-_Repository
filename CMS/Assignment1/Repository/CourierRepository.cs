using Assignment1.Utility;
using System.Data.SqlClient;


namespace Assignment1.Repository
{
    internal class CourierRepository : ICourierRepository
    {
            public string connectionString;
            SqlCommand cmd = null;

            public CourierRepository()
            {
                //sqlConnection = new SqlConnection("Server=LAPTOP-MK5JT9DU;Database=CMS;Trusted_Connection=True");
                connectionString = DBConnUtil.GetConnectionString();
                cmd = new SqlCommand();
            }
    }
}
