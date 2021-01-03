using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Entidad Tipo Movimiento Producto
    /// </summary>
    public class Tipo_movimiento_prod : IEntityBase
    {
        public int id { get; set; }
        public string tipo_mov_prod { get; set; }
    }
}
