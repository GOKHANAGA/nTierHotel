using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDAL.Repositories
{
    public class ReservationTypeManagement
    {

        public DataSet ListTypes()
        {
            SqlConnection conn = Helper.Connection.DatabaseConnection;
            DataSet dS = new DataSet();

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ReservationTypes", conn);
                SqlDataAdapter dA = new SqlDataAdapter(cmd);
                dA.Fill(dS);
            }
            catch
            {

            }

            return dS;
        }
    }
}
