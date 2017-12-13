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
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            HotelBLL.Repositories.ReservationManagement _reservationManager = new HotelBLL.Repositories.ReservationManagement();
            _reservationManager.AddReservation(Convert.ToInt64(txtCivilizationNumber.Text), txtFirstName.Text, txtLastName.Text, txtUserID.Text, txtType.Text, Convert.ToInt32(txtRoom.Text), check_inCal.SelectedDate, check_outCal.SelectedDate);
        }

        protected void check_inCal_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Now)
            {
                e.Cell.BackColor = System.Drawing.Color.Cyan;
                e.Day.IsSelectable = false;
            } 
        }

        protected void check_outCal_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < check_inCal.SelectedDate)
            {
                e.Cell.BackColor = System.Drawing.Color.Cyan;
                e.Day.IsSelectable = false;
            }
        }
    }
}