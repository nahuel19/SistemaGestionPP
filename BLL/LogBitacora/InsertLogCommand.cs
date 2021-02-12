using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LogBitacora
{
    public class InsertLogCommand 
    {
        protected LogDAL logDAL;

        public InsertLogCommand(LogDAL _logDAL)
        {
            logDAL = _logDAL;
        }

        public void Execute(Log log)
        {
            logDAL.Insert(log);
        }
    }
}
