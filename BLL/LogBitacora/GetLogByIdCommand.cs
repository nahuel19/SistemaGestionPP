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
    /// Command para obetener log por id
    /// </summary>
    public class GetLogByIdCommand
    {
        protected LogDAL logDAL;

        /// <summary>
        /// Constructor GetLogByIdCommand, inicia variable LogDAL
        /// </summary>
        /// <param name="_logDAL"></param>
        public GetLogByIdCommand(LogDAL _logDAL)
        {
            logDAL = _logDAL;
        }

        /// <summary>
        /// Ejecuta metodo de la dal para obetener log by id
        /// </summary>
        /// <param name="id"></param>
        public Log Execute(int id)
        {
            return logDAL.GetById(id);
        }
    }
}
