﻿using HotelBLL.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
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
        ReservationManagement _reservationManager = new ReservationManagement();
        RoomManagement _roomManager = new RoomManagement();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                check_inCal.SelectedDate = DateTime.Now;
                check_outCal.SelectedDate = DateTime.Now.AddDays(1);
                FillDropDowns();
                AddGuestInfoPanel(1);
            }
            if (Session["userName"] == null)
            {
                Response.Redirect("Login.aspx");
            }


                ddlRooms.DataSource = null;
                ddlRooms.DataSource = _bookingManager.GetEmptyRooms(check_inCal.SelectedDate, check_outCal.SelectedDate).Tables[0];
                ddlRooms.DataTextField = "RoomNumber";
                ddlRooms.DataBind();

        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            _reservationManager.AddReservation(GetGuestInfoInForm(ddlPersonCount.SelectedIndex + 1), Session["userID"].ToString(), Convert.ToInt32(ddlPersonCount.SelectedValue), GetType(), _reservationManager.CalculateTotalPrice(Convert.ToInt32(ddlPersonCount.SelectedValue),check_inCal.SelectedDate,check_outCal.SelectedDate), _roomManager.GetRoomID(ddlRooms.SelectedValue), check_inCal.SelectedDate, check_outCal.SelectedDate);
        }

        public void FillDropDowns()
        {
            ddlType.DataSource = _typeManager.ListTypes().Tables[0];
            ddlType.DataTextField = "TypeName";
            ddlType.DataBind();
            Session["F"] = _typeManager.ListTypes().Tables[0].Rows[0].Field<string>(0);
            Session["FF"] = _typeManager.ListTypes().Tables[0].Rows[1].Field<string>(0);
            Session["S"] = _typeManager.ListTypes().Tables[0].Rows[2].Field<string>(0);



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

            AddGuestInfoPanel(ddlPersonCount.SelectedIndex + 1);
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
                txtCivilizationNo.Attributes["title"] = "11 Haneli sayısal giriş zorunludur.";
                txtCivilizationNo.Attributes["pattern"] = "[0-9]{11}";
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

        public DataTable GetGuestInfoInForm(int personCount)
        {
            DataTable customers = new DataTable();
            customers.Columns.Add("CivilizationNo");
            customers.Columns.Add("FirstName");
            customers.Columns.Add("LastName");

            for (int i = 1; i <= personCount; i++)
            {
                string name = "";
                string lastName = "";
                string civilizationNo = "";

                foreach (var item in Request.Form.AllKeys)
                {

                    if (item.Contains("txtFirstName"+i))
                    {
                        name = Request.Form[item].ToString();
                    }
                    else if (item.Contains("txtLastName"+i))
                    {
                        lastName = Request.Form[item].ToString();
                    }
                    else if (item.Contains("txtCivilizationNo"+i))
                    {
                        civilizationNo = Request.Form[item].ToString();
                    }

                }
                customers.Rows.Add(civilizationNo, name, lastName);

            }

            return customers;
        }

        public string GetType()
        {
            if (ddlType.SelectedValue == "Full")
            {
                return "F";
            }
            else if (ddlType.SelectedValue == "Full+Full")
            {
                return "FF";
            }
            else
            {
                return "S";
            }
        }
    }
}