using HotelBLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelReservation
{
    public partial class reservation : System.Web.UI.Page
    {
        ReservationTypeManagement _typeManager = new ReservationTypeManagement();
        BookingManagement _bookingManager = new BookingManagement();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                check_inCal.SelectedDate = DateTime.Now;
                check_outCal.SelectedDate = DateTime.Now.AddDays(1);
                FillDropDowns();
            }


        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            //HotelBLL.Repositories.ReservationManagement _reservationManager = new HotelBLL.Repositories.ReservationManagement();
            //_reservationManager.AddReservation(Convert.ToInt64(txtCivilizationNumber.Text), txtFirstName.Text, txtLastName.Text, txtUserID.Text, txtType.Text, Convert.ToInt32(txtRoom.Text), check_inCal.SelectedDate, check_outCal.SelectedDate);


            //            }


        }

        public void FillDropDowns()
        {
            ddlType.DataSource = _typeManager.ListTypes().Tables[0];
            ddlType.DataTextField = "TypeName";
            ddlType.DataBind();

            for (int i = 1; i <= 10; i++)
            {
                ddlPersonCount.Items.Add(i.ToString());
            }

            ddlRooms.DataSource = _bookingManager.GetEmptyRooms(check_inCal.SelectedDate, check_outCal.SelectedDate).Tables[0];
            ddlRooms.DataTextField = "RoomNumber";
            ddlRooms.DataBind();
        }

        protected void check_inCal_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Now)
            {
                e.Cell.BackColor = System.Drawing.Color.LightYellow;
                e.Day.IsSelectable = false;
            }
        }

        protected void check_outCal_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < check_inCal.SelectedDate)
            {
                e.Cell.BackColor = System.Drawing.Color.LightYellow;
                e.Day.IsSelectable = false;
            }
        }

        protected void ddlPersonCount_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFirstName.Text = PriceTrial((ddlPersonCount.SelectedIndex + 1), check_inCal.SelectedDate, check_outCal.SelectedDate).ToString();

        }

        public double PriceTrial(int kisiSayisi, DateTime check_in, DateTime check_out)
        {
            double totalPrice = 0;
            double weekDayPrice = 20.0;
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