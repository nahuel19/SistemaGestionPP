using BLL.LogBitacora;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.LogBitacora
{
    public class GetLogsCommand
    {
        protected LogDAL logDAL;

        public GetLogsCommand(LogDAL _logDAL)
        {
            logDAL = _logDAL;
        }

        public void Execute(int id)
        {
            logDAL.GetById(id);
        }
    }
}
