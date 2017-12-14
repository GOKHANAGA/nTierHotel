using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBLL.Repositories
{
    public class BookingManagement
    {
        HotelDAL.Repositories.BookingManagement _bookingManager = new HotelDAL.Repositories.BookingManagement();

        public DataSet GetEmptyRooms(DateTime check_in,DateTime check_out)
        {
            return _bookingManager.GetEmptyRooms(check_in, check_out);
        }
    }
}
