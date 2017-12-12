using HotelBLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelReservation
{
    public partial class signUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            UserManagement _userManager = new UserManagement();
            _userManager.AddUser(txtUserName.Text, txtMail.Text, txtPassword.Text, txtFirstName.Text, txtLastName.Text, Convert.ToInt64(txtCivilizationNumber.Text));

        }
    }
}