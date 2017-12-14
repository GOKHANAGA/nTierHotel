using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBLL.Repositories
{
    public class CustomerReservationManagement
    {
        HotelDAL.Repositories.CustomerReservationManagement _customerReservationManager = new HotelDAL.Repositories.CustomerReservationManagement();

        public void AddCustomerReservation(string civilizationNo,Guid reservationID)
        {
            _customerReservationManager.AddCustomerReservation(civilizationNo, reservationID);
        }
    }
}
