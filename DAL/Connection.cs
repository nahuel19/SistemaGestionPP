using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Connection
    {
        private Connection() { }

        private static Connection _instance;

        public static Connection Instance() => _instance == null ? _instance = new Connection() : _instance;

        public SqlConnection Conect()
        {
            SqlConnection conn = new SqlConnection();
            string connString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
            conn.ConnectionString = connString;
            return conn;
        }
    }
}
