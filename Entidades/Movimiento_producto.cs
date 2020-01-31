using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Movimiento_producto : EntityBase
    {
        public override int Id { get; set; }
        public int Fk_id_producto { get; set; }
        public int Antes { get; set; }
        public int Movimiento { get; set; }
        public int Despues { get; set; }
        public int Fk_id_tipo_mov_prod { get; set; }
        public DateTime Fecha { get; set; }
    }
}
