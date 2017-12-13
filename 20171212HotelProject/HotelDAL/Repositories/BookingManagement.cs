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
        public void AddBooking(Guid reservationID,int roomID,DateTime check_in,DateTime check_out)
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

        public DataSet GetEmptyRooms(DateTime check_in,DateTime check_out)
        {
            SqlConnection conn = Helper.Connection.DatabaseConnection;
            DataSet dS = new DataSet();

            try
            {
                string selectQuery = "SELECT * FROM Room WHERE RoomID NOT IN (SELECT r.RoomID FROM Room r INNER JOIN Booked b ON b.RoomID=r.RoomID WHERE (@checkIn BETWEEN b.Check_In AND b.Check_Out) OR (@checkOut BETWEEN b.Check_In AND b.Check_Out) OR(b.Check_In BETWEEN @checkIn AND @checkOut) OR(b.Check_Out BETWEEN @checkIn AND @checkOut))";

                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.Add("@checkIn", check_in);
                cmd.Parameters.Add("@checkOut", check_out);

                SqlDataAdapter dA = new SqlDataAdapter(cmd);
                dA.Fill(dS);
            }
            catch
            {

            }
            return dS;
        }
    }
}
