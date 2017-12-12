using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDAL.Helper
{
    public static class Connection
    {
        private static string _connectionString = "Server=.;Database=Hotel;Integrated Security=true";
        private static string _connectionStringMars = "Server=.;Database=Hotel;Integrated Security=true;MultipleActiveResultSets=True";
        private static SqlConnection _databaseConnection;
        private static SqlConnection _marsDatabaseConnection;


        public static string ConnectionString
        {
            get { return Connection._connectionString; }
        }

        public static string ConnectionStringMars
        {
            get { return Connection._connectionStringMars; }

        }


        public static SqlConnection MarsDatabaseConnection
        {
            get
            {
                if (_marsDatabaseConnection == null)
                {
                    _marsDatabaseConnection = new SqlConnection(ConnectionStringMars);
                }

                return _marsDatabaseConnection;
            }
        }


        public static SqlConnection DatabaseConnection
        {
            get
            {
                if (_databaseConnection == null)
                {
                    _databaseConnection = new SqlConnection(ConnectionString);
                }

                return _databaseConnection;
            }
        }



    }
}
