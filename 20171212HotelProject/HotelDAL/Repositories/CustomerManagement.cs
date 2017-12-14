using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDAL.Repositories
{
    public class CustomerManagement
    {
        public void AddCustomer(long CivilizationNo)
        {
            SqlConnection conn = Helper.Connection.DatabaseConnection;

            try
            {
                string customerQuery = "INSERT INTO Customers VALUES (@civilizationNo)";
                SqlCommand cmd = new SqlCommand(customerQuery, conn);
                cmd.Parameters.AddWithValue("@civilizationNo", CivilizationNo);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                int effectedRowCount = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }


         }
    }
}
