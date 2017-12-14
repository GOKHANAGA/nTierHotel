using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDAL.Repositories
{
    public class PeopleManagement
    {

        public void AddPeople(long civilizationNo,string firstName,string lastName)
        {
            SqlConnection conn = Helper.Connection.DatabaseConnection;
            try
            {
                
                string peopleQuery = "INSERT INTO People VALUES (@civilNo,@firstName,@lastName)";
                SqlCommand cmd = new SqlCommand(peopleQuery, conn);
                cmd.Parameters.AddWithValue("@civilNo", civilizationNo);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                int a = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                if (ex.Message == "İsim-KimlikNo uyuşmazlığı")
                {
                    string asd = "olmadiii";
                }
                else
                {
                    throw;
                }
            }
            finally
            {
                conn.Close();
            }



            

        }

    }
}
