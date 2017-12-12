using HotelBLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelReservation
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserManagement _userManager = new UserManagement();
            if (_userManager.UserLogin(txtMail.Text, txtPassword.Text)) ;
            {
                txtMail.Text = "Giriş Onaylandı";
            }
        }
    }
}