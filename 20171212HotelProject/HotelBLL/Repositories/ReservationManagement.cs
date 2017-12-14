using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBLL.Repositories
{
    public class ReservationManagement
    {
        HotelDAL.Repositories.ReservationManagement _reservationManager = new HotelDAL.Repositories.ReservationManagement();

        public void AddReservation(long civilizationNo, string firstName, string lastName, string userID, string typeID, int roomID, DateTime check_in, DateTime check_out)
        {
            _reservationManager.AddReservation(civilizationNo, firstName, lastName, userID, typeID, roomID, check_in, check_out);
        }
    }
}
