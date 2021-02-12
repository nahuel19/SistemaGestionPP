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
    public static class InvokeCommand
    {
        private static InsertLogCommand _insertLogCommand;
        private static GetLogsCommand _getLogsCommand;

        public static InsertLogCommand InsertLog()
        {
            return _insertLogCommand ?? (_insertLogCommand = new InsertLogCommand(new LogDAL()));
        }

        public static GetLogsCommand GetLogs()
        {
            return _getLogsCommand ?? (_getLogsCommand = new GetLogsCommand(new LogDAL()));
        }

    }
}

//patron template
//https://refactoring.guru/es/design-patterns/template-method/csharp/example
