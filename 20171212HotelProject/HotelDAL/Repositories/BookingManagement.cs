using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDAL.Repositories
{
    public class BookingManagement
    {
        public void AddBooking(int reservationID,int roomID,DateTime check_in,DateTime check_out)
        {
            SqlConnection conn = Helper.Connection.DatabaseConnection;

            try
            {
                string bookQuery = "INSERT INTO Booked VALUES (@reservationID,@roomID,@check_in,@check_out)";
                SqlCommand cmd = new SqlCommand(bookQuery, conn);
                cmd.Parameters.AddWithValue("@reservationID", reservationID);
                cmd.Parameters.AddWithValue("@roomID", roomID);
                cmd.Parameters.AddWithValue("check_in", check_in);
                cmd.Parameters.AddWithValue("@check_out", check_out);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                int a = cmd.ExecuteNonQuery();
            }
            catch(Exception )
            {
                /*
                 * dive id ver onun içine textbox ekle
                 * 
                 */
            }
            finally
            {
                conn.Close();
            }


        }
    }
}
