using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Precio : EntityBase
    {
        public override int Id { get; set; }
        public int Fk_id_producto { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public double Costo { get; set; }
        public double Precio { get; set; }
    }
}
