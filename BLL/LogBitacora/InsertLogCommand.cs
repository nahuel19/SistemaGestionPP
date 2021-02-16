using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LogBitacora
{
    /// <summary>
    /// Command para insertar logs
    /// </summary>
    public class InsertLogCommand 
    {
        protected LogDAL logDAL;

        /// <summary>
        /// Constructor InsertLogCommand, inicia variable de LogDAL
        /// </summary>
        /// <param name="_logDAL"></param>
        public InsertLogCommand(LogDAL _logDAL)
        {
            logDAL = _logDAL;
        }

        /// <summary>
        /// Ejecuta método de DAL para inserta un log en la base
        /// </summary>
        /// <param name="log">Entidad Log</param>
        public void Execute(Log log)
        {
            logDAL.Insert(log);
        }
    }
}
