using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Tipo_log : IEntityBase
    {
        public int id { get; set; }
        public string tipo_log { get; set; }
    }
}
