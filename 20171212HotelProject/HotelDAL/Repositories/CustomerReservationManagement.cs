using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDAL.Repositories
{
    public class CustomerReservationManagement
    {
        SqlConnection conn = Helper.Connection.DatabaseConnection;

        public void AddCustomerReservation(string civilizationNo,Guid reservationNo)
        {
            try
            {

                string peopleQuery = "INSERT INTO CustomerReservation VALUES (@reservationNo,@civilizationNo)";
                SqlCommand cmd = new SqlCommand(peopleQuery, conn);
                cmd.Parameters.AddWithValue("@civilizationNo", civilizationNo);
                cmd.Parameters.AddWithValue("@reservationNo", reservationNo);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                int a = cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
        }

    }
}
