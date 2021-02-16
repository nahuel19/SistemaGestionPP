using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Clase con propiedades de los tipo de log disponibles
    /// </summary>
    public static class ETipoLog
    {
        public static int Insert { get => Convert.ToInt32(ConfigurationManager.AppSettings["Insert"]); }
        public static int InsertError { get => Convert.ToInt32(ConfigurationManager.AppSettings["InsertError"]); }

        public static int Delete { get => Convert.ToInt32(ConfigurationManager.AppSettings["Delete"]); }
        public static int DeleteError { get => Convert.ToInt32(ConfigurationManager.AppSettings["DeleteError"]); }

        public static int Update { get => Convert.ToInt32(ConfigurationManager.AppSettings["Update"]); }
        public static int UpdateError { get => Convert.ToInt32(ConfigurationManager.AppSettings["UpdateError"]); }

        public static int Error { get => Convert.ToInt32(ConfigurationManager.AppSettings["Error"]); }
        public static int Login { get => Convert.ToInt32(ConfigurationManager.AppSettings["Login"]); }
        public static int LoginError { get => Convert.ToInt32(ConfigurationManager.AppSettings["LoginError"]); }

    }
}
