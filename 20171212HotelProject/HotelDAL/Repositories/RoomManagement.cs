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
    public class RoomManagement
    {
        public int GetRoomID(string roomNumber)
        {
            SqlConnection conn = Connection.DatabaseConnection;
            string userIDQuery = "SELECT * FROM Room WHERE RoomNumber=@roomNumber";
            SqlCommand cmd = new SqlCommand(userIDQuery, conn);
            cmd.Parameters.AddWithValue("@roomNumber", Convert.ToInt32(roomNumber));
           
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlDataReader dR = cmd.ExecuteReader();
                dR.Read();
                return Convert.ToInt32(dR[0]);

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
