using HotelDAL.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDAL.Repositories
{
    public class PriceManagementcs
    {
        public double GetPrice()
        {
            SqlConnection conn = Connection.DatabaseConnection;
            string userIDQuery = "SELECT Price FROM Prices WHERE PriceID = 'S'";
            SqlCommand cmd = new SqlCommand(userIDQuery, conn);

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                return Convert.ToDouble(cmd.ExecuteScalar());


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
