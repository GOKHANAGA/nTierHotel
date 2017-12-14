using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBLL.Repositories
{
    public class ReservationManagement
    {
        HotelDAL.Repositories.ReservationManagement _reservationManager = new HotelDAL.Repositories.ReservationManagement();
        HotelDAL.Repositories.PriceManagementcs _priceManager = new HotelDAL.Repositories.PriceManagementcs();

        public void AddReservation(DataTable customerInfos, string userID, int guestAmount, string typeID, double totalPrice, int roomID, DateTime check_in, DateTime check_out)
        {
            _reservationManager.AddReservation(customerInfos, userID, guestAmount, typeID,totalPrice, roomID, check_in, check_out);
        }

        public double CalculateTotalPrice(int kisiSayisi, DateTime check_in, DateTime check_out)
        {
            double totalPrice = 0;
            double weekDayPrice = _priceManager.GetPrice();
            double weekendPrice = weekDayPrice + (weekDayPrice * 0.3);

            for (DateTime i = check_in; i <= check_out; i = i.AddDays(1))
            {
                double standart = 0;
                if (i.DayOfWeek == DayOfWeek.Saturday || i.DayOfWeek == DayOfWeek.Sunday)
                {
                    standart = weekendPrice;
                }
                else
                {
                    standart = weekDayPrice;
                }

                while (kisiSayisi != 0)
                {
                    if (kisiSayisi % 3 == 0)
                    {
                        totalPrice += (standart + (standart * 0.3));
                        kisiSayisi -= 3;
                    }
                    else if (kisiSayisi % 3 == 1)
                    {
                        totalPrice += (standart - (standart * 0.2));
                        kisiSayisi -= 1;
                    }
                    else if (kisiSayisi % 3 == 2)
                    {
                        totalPrice += standart;
                        kisiSayisi -= 2;
                    }
                }
            }


            return totalPrice;

        }
    }
}
