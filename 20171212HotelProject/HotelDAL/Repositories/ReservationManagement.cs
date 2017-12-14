using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDAL.Repositories
{
    public class ReservationManagement
    {

        public void AddReservation(long civilizationNo, string firstName, string lastName, string userID, string typeID, int roomID,DateTime check_in,DateTime check_out)
        {
            CustomerManagement _customerManager = new CustomerManagement();
            BookingManagement _bookingManager = new BookingManagement();
            PeopleManagement _peopleManager = new PeopleManagement();

            SqlConnection conn = Helper.Connection.DatabaseConnection;


            try
            {
                Guid reservationNo = Guid.NewGuid();
                string reservationQuery = "INSERT INTO Reservation (ReservationNo,UserID,TypeID) VALUES (@reservationID,@userID,@typeID)";
                SqlCommand cmd = new SqlCommand(reservationQuery, conn);
                cmd.Parameters.AddWithValue("@reservationID", reservationNo);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@typeID", typeID);

                _peopleManager.AddPeople(civilizationNo, firstName, lastName);
                _customerManager.AddCustomer(civilizationNo);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                int effectedRowCount = cmd.ExecuteNonQuery();

                _bookingManager.AddBooking(reservationNo, roomID,check_in,check_out);


            }
            catch
            {

            }
            finally
            {

            }




        }
    }
}
