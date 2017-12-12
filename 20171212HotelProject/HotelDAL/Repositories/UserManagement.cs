﻿using HotelDAL.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDAL.Repositories
{
    public class UserManagement
    {
        public void AddUser(string userName,string e_mail,string password,string firstName,string lastName,long civilizationNo)
        {
            SqlConnection conn = Connection.DatabaseConnection;
            string addPeopleQuery="INSERT INTO People (CivilizationNo,FirstName,lastName) VALUES (@civilizationNo,@firstName,@lastName)";
            SqlCommand cmdPeople = new SqlCommand(addPeopleQuery, conn);
            cmdPeople.Parameters.AddWithValue("@civilizationNo", civilizationNo);
            cmdPeople.Parameters.AddWithValue("@firstName", firstName);
            cmdPeople.Parameters.AddWithValue("@lastName", lastName);


            string addUserQuery = "INSERT INTO Users (UserID,UserName,E_Mail,CivilizationNo) VALUES (@userID,@userName,@e_mail,@civilizationNo)";
            Guid userID = Guid.NewGuid();
            SqlCommand cmdUser = new SqlCommand(addUserQuery,conn);
            cmdUser.Parameters.AddWithValue("@userID", userID);
            cmdUser.Parameters.AddWithValue("@userName", userName);
            cmdUser.Parameters.AddWithValue("@e_mail", e_mail);
            cmdUser.Parameters.AddWithValue("@civilizationNo", civilizationNo);

            string addPasswordQuery = "INSERT INTO Passwords (UserID,UserPassword) VALUES (@userID,@userPassword)";
            SqlCommand cmdPassword = new SqlCommand(addPasswordQuery,conn);
            cmdPassword.Parameters.AddWithValue("@userID", userID);
            cmdPassword.Parameters.AddWithValue("@userPassword", password);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                int addPerson = cmdPeople.ExecuteNonQuery();
                int addUser = cmdUser.ExecuteNonQuery();
                int addPw = cmdPassword.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }

        public bool UserLogin(string e_mail,string password)
        {
            SqlConnection conn = Connection.DatabaseConnection;
            string userIDQuery = "SELECT COUNT(*) FROM Passwords WHERE UserID=(SELECT UserID FROM Users WHERE E_Mail = @e_mail) AND UserPassword = @password AND IsActive = 'True'";
            SqlCommand cmd = new SqlCommand(userIDQuery,conn);
            cmd.Parameters.AddWithValue("@e_mail", e_mail);
            cmd.Parameters.AddWithValue("@password", password);

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
