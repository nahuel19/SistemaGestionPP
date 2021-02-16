using BLL.LogBitacora;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.LogBitacora
{
    /// <summary>
    /// Command para obetener lista de logs
    /// </summary>
    public class GetLogsCommand
    {
        protected LogDAL logDAL;

        /// <summary>
        /// Constructor GetLogsCommand, inicia variable LogDAL
        /// </summary>
        /// <param name="_logDAL"></param>
        public GetLogsCommand(LogDAL _logDAL)
        {
            logDAL = _logDAL;
        }

        /// <summary>
        /// Ejecuta metodo de la dal para obetener lista de logs
        /// </summary>
        /// <param name="id"></param>
        public void Execute(int id)
        {
            logDAL.GetById(id);
        }
    }
}
