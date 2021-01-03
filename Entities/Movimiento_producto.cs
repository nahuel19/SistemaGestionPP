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
        public int antes { get; set; }
        public int movimiento { get; set; }
        public int despues { get; set; }
        public int fk_id_tipo_mov_prod { get; set; }
        public DateTime fecha { get; set; }
    }
}
