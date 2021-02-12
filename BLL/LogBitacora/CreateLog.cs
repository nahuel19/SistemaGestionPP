using Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LogBitacora
{
    public static class CreateLog
    {
        public static Log Clog(int _tipo_log, int _usuario, string _clase, string _metodo, string _info_operacion, string _stack_trace = "", string _mensaje = "")
        {
            Log log = new Log
            {
                tipo_log = _tipo_log,
                usuario = _usuario,
                fecha = DateTime.Now,
                clase = _clase,
                metodo = _metodo,
                stack_trace = _stack_trace,
                mensaje = _mensaje,       
                info_operacion = _info_operacion                
            };

            return log;
        }

        public static Log Loadlog(int _tipo_log, int _usr, object obj, Exception ex, string _infoRelacionada = "")
        {
            StackTrace stacktrace = new StackTrace();

            Log log = new Log
            {
                tipo_log = _tipo_log,
                usuario = _usr,
                fecha = DateTime.Now,
                clase = obj.GetType().FullName,
                metodo = stacktrace.GetFrame(1).GetMethod().Name,
                stack_trace = ex.StackTrace,
                mensaje = ex.Message,
                info_operacion = _infoRelacionada
            };

            return log;
        }
    }
}
