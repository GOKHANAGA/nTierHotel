using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBLL.Repositories
{
    public class PeopleManagement
    {
        //,int reservationNo,Guid UserID,string resTypeID,int roomID
        HotelDAL.Repositories.PeopleManagement _peopleManager = new HotelDAL.Repositories.PeopleManagement();

        public void AddPeople(long civilizationNo,string firstName,string lastName)
        {
            _peopleManager.AddPeople(civilizationNo, firstName, lastName);
        }

    }
}
