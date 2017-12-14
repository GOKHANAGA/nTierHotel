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

        public void AddReservation(DataTable customerInfos, string userID,int guestAmount, string typeID,double totalPrice, int roomID,DateTime check_in,DateTime check_out)
        {
            CustomerManagement _customerManager = new CustomerManagement();
            BookingManagement _bookingManager = new BookingManagement();
            PeopleManagement _peopleManager = new PeopleManagement();
            CustomerReservationManagement _customerReservationManager = new CustomerReservationManagement();

            SqlConnection conn = Helper.Connection.DatabaseConnection;


            try
            {
                Guid reservationNo = Guid.NewGuid();
                string reservationQuery = "INSERT INTO Reservation (ReservationID,UserID,GuestAmonut,TypeID,TotalPrice) VALUES (@reservationID,@userID,@guestAmount,@typeID,@totalPrice)";
                SqlCommand cmd = new SqlCommand(reservationQuery, conn);
                cmd.Parameters.AddWithValue("@reservationID", reservationNo);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@typeID", typeID);
                cmd.Parameters.AddWithValue("@guestAmount", guestAmount);
                cmd.Parameters.AddWithValue("@totalPrice", totalPrice);

                for (int i = 0; i < customerInfos.Rows.Count; i++)
                {
                    _peopleManager.AddPeople(customerInfos.Rows[i].Field<string>(0), customerInfos.Rows[i].Field<string>(1), customerInfos.Rows[i].Field<string>(2));
                    _customerManager.AddCustomer(customerInfos.Rows[i].Field<string>(0));
                }


                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                int effectedRowCount = cmd.ExecuteNonQuery();

                for (int i = 0; i < customerInfos.Rows.Count; i++)
                {
                    _customerReservationManager.AddCustomerReservation(customerInfos.Rows[i].Field<string>(0), reservationNo);
                }

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
