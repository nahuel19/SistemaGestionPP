using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Clase para instanciar la SqlConnection
    /// </summary>
    public class ConnectionBD
    {
        private ConnectionBD() { }

        private static ConnectionBD _instance;

        /// <summary>
        /// Verifica si ya está instanciada la clase (singleton)
        /// </summary>
        /// <returns>ConnectionBD</returns>
        public static ConnectionBD Instance() => _instance == null ? _instance = new ConnectionBD() : _instance;

        /// <summary>
        /// Busca la cadena de conexión en app.config y la devuelve como sql connection
        /// </summary>
        /// <returns>SqlConnecion</returns>
        public SqlConnection Conect()
        {
            SqlConnection conn = new SqlConnection();
            string connString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
            conn.ConnectionString = connString;
            return conn;
        }
    }
}
