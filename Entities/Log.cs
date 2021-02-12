using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Log : IEntityBase
    {
        public int id { get; set; }
        public int tipo_log { get; set; }
        public int usuario { get; set; }
        public DateTime fecha { get; set; }
        public string clase { get; set; }
        public string metodo { get; set; }
        public string stack_trace { get; set; }
        public string mensaje { get; set; }
        public string info_operacion { get; set; }

    }
}

     
      
   
     