using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Entidad Movimiento Producto
    /// </summary>
    public class Movimiento_producto :IEntityBase
    {
        public int id { get; set; }
        public int fk_id_producto { get; set; }
        public double antes { get; set; }
        public double movimiento { get; set; }
        public double despues { get; set; }
        public int fk_id_tipo_mov_prod { get; set; }
        public DateTime fecha { get; set; }
        public string extra { get; set; }
    }
}
