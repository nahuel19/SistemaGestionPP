using Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LogBitacora
{
    /// <summary>
    /// Contiene método para lcrear un log
    /// </summary>
    public static class CreateLog
    {
        /// <summary>
        /// Llena una entidad de LOG con los parámetros recibidos y la devuelve.
        /// </summary>
        /// <param name="_tipo_log">int</param>
        /// <param name="_usuario">int</param>
        /// <param name="_clase">string</param>
        /// <param name="_metodo">string</param>
        /// <param name="_info_operacion">string</param>
        /// <param name="_stack_trace">string</param>
        /// <param name="_mensaje">string</param>
        /// <returns></returns>
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

        //public static Log Loadlog(int _tipo_log, int _usr, object obj, Exception ex, string _infoRelacionada = "")
        //{
        //    StackTrace stacktrace = new StackTrace();

        //    Log log = new Log
        //    {
        //        tipo_log = _tipo_log,
        //        usuario = _usr,
        //        fecha = DateTime.Now,
        //        clase = obj.GetType().FullName,
        //        metodo = stacktrace.GetFrame(1).GetMethod().Name,
        //        stack_trace = ex.StackTrace,
        //        mensaje = ex.Message,
        //        info_operacion = _infoRelacionada
        //    };

        //    return log;
        //}
    }
}
