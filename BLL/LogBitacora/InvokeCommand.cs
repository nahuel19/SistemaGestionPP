using DAL;
using DAL.LogBitacora;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LogBitacora
{
    /// <summary>
    /// Clase para invokar los Commands de Logs
    /// </summary>
    public static class InvokeCommand
    {
        private static InsertLogCommand _insertLogCommand;
        private static GetLogsCommand _getLogsCommand;
        private static GetLogByIdCommand _getLogByIdCommand;

        /// <summary>
        /// Retorna instancia de InsertLogCommand
        /// </summary>
        /// <returns>InsertLogCommand</returns>
        public static InsertLogCommand InsertLog()
        {
            return _insertLogCommand ?? (_insertLogCommand = new InsertLogCommand(new LogDAL()));
        }

        /// <summary>
        /// Retorna instancia de GetLogsCommand
        /// </summary>
        /// <returns>GetLogsCommand</returns>
        public static GetLogsCommand GetLogs()
        {
            return _getLogsCommand ?? (_getLogsCommand = new GetLogsCommand(new LogDAL()));
        }

        /// <summary>
        /// Retorna instancia de GetLogByIdCommand
        /// </summary>
        /// <returns>GetLogsCommand</returns>
        public static GetLogByIdCommand GetLogById()
        {
            return _getLogByIdCommand ?? (_getLogByIdCommand = new GetLogByIdCommand(new LogDAL()));
        }

    }
}

