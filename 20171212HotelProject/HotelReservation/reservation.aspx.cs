using HotelBLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
                AddGuestInfoPanel(1);
            }


        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            


           
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

            //txtFirstName.Text = PriceTrial((ddlPersonCount.SelectedIndex + 1), check_inCal.SelectedDate, check_outCal.SelectedDate).ToString();

            //foreach (var item in Request.Form.AllKeys)
            //{

            //    if(item.Contains("txtFirstName"))
            //    {
            //      string deger=Request.Form[item].ToString();
            //    }
            //    else if (item.Contains("txtLastName"))
            //    {

            //    }
            //    else if (item.Contains("txtCivilizationNo"))
            //    {

            //    }

            //}       

            AddGuestInfoPanel(ddlPersonCount.SelectedIndex + 1);
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

        public void AddGuestInfoPanel(int personCount)
        {
            for (int i = 1; i <= personCount; i++)
            {
                /*----Panel header begin----*/
                HtmlGenericControl panelHeader = new HtmlGenericControl("div");
                panelHeader.Attributes["class"] = "panel-heading";
                panelHeader.InnerHtml = "<h3 class='panel-title'>" + i + ".Kişi Bilgileri</h3>";

                #region firstName

                /*----TextBox for firstName----*/
                TextBox txtFirstName = new TextBox();
                txtFirstName.ID = "txtFirstName" + i;
                txtFirstName.Attributes["class"] = "form-control";
                txtFirstName.Attributes["runat"] = "server";


                /*----FirstName TXT Dıv group*/
                HtmlGenericControl innerDivName = new HtmlGenericControl("div");
                innerDivName.Attributes["class"] = "col-sm-3 col-sm-offset-1";
                innerDivName.Controls.Add(txtFirstName);
                #endregion

                #region lastName
                /*----TextBox for lastName----*/
                TextBox txtLastName = new TextBox();
                txtLastName.ID = "txtLastName" + i;
                txtLastName.Attributes["class"] = "form-control";
                txtLastName.Attributes["runat"] = "server";


                /*----LastName TXT Dıv group*/
                HtmlGenericControl innerDivSurname = new HtmlGenericControl("div");
                innerDivSurname.Attributes["class"] = "col-sm-3";
                innerDivSurname.Controls.Add(txtLastName);
                #endregion

                #region civilizationNo

                /*----TextBox for CivilizationNo----*/
                TextBox txtCivilizationNo = new TextBox();
                txtCivilizationNo.ID = "txtCivilizationNo" + i;
                txtCivilizationNo.Attributes["class"] = "form-control";
                txtCivilizationNo.Attributes["runat"] = "server";

                /*----CivilizationNo TXT Dıv group*/
                HtmlGenericControl innerDivCivNo = new HtmlGenericControl("div");
                innerDivCivNo.Attributes["class"] = "col-sm-3";
                innerDivCivNo.Controls.Add(txtCivilizationNo);

                #endregion

                /*----TextBoxtAdding----*/
                HtmlGenericControl txtDiv = new HtmlGenericControl("div");
                txtDiv.Attributes["class"] = "form-group";
                txtDiv.Controls.Add(innerDivName);
                txtDiv.Controls.Add(innerDivSurname);
                txtDiv.Controls.Add(innerDivCivNo);

                /*----headerLabels----*/
                HtmlGenericControl headerLabels = new HtmlGenericControl("div");
                headerLabels.Attributes["class"] = "form-group";
                headerLabels.InnerHtml = "<label for='inputEmail3' class='col-sm-3 control-label'>First Name</label><label for='inputEmail3' class='col-sm-3 control-label'>Last Name</label><label for='inputEmail3' class='col-sm-3 control-label'>Civilization Number</label>";


                /*----Panel body beginning----*/
                HtmlGenericControl panelBody = new HtmlGenericControl("div");
                panelBody.Attributes["class"] = "panel-body";
                panelHeader.Controls.Add(headerLabels);
                panelHeader.Controls.Add(txtDiv);

                /*----Panel Beginning*/
                HtmlGenericControl generalDiv = new HtmlGenericControl("div");
                generalDiv.Attributes["class"] = "panel panel-warning";
                generalDiv.Controls.Add(panelHeader);
                generalDiv.Controls.Add(panelBody);

                personInfo.Controls.Add(generalDiv);
            }
        }
    }
}