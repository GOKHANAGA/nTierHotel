using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBLL.Repositories
{
    public class CustomerManagement
    {
        HotelDAL.Repositories.CustomerManagement _customerManager = new HotelDAL.Repositories.CustomerManagement();

        public void AddCustomer(string civilizationNo)
        {
            _customerManager.AddCustomer(civilizationNo);
        }
    }
}
