
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBLL.Repositories
{
    public class RoomManagement
    {
        HotelDAL.Repositories.RoomManagement _roomManager = new HotelDAL.Repositories.RoomManagement();

        public int GetRoomID(string roomNumber)
        {
            return _roomManager.GetRoomID(roomNumber);
        }
    }
}
