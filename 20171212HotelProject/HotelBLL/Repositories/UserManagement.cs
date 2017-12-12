﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBLL.Repositories
{
    public class UserManagement
    {
        HotelDAL.Repositories.UserManagement _userManager = new HotelDAL.Repositories.UserManagement();

        public void AddUser(string userName,string e_mail,string password,string firstName,string lastName,long civilizationNo)
        {
            _userManager.AddUser(userName, e_mail, password, firstName, lastName, civilizationNo);
        }

        public bool UserLogin(string e_mail,string password)
        {
           return _userManager.UserLogin(e_mail,password);
        }
    }
}
