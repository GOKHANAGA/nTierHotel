using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBLL.Repositories
{
    public class ReservationTypeManagement
    {
        HotelDAL.Repositories.ReservationTypeManagement _typeManager = new HotelDAL.Repositories.ReservationTypeManagement();

        public DataSet ListTypes()
        {
            return _typeManager.ListTypes();
        }




    }
}
