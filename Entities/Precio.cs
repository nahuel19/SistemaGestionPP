using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Entidad Precio
    /// </summary>
    public class Precio : IEntityBase
    {
        public int id { get; set; }
        public int fk_id_producto { get; set; }
        public DateTime desde { get; set; }
        public DateTime hasta { get; set; }
        public double costo { get; set; }
        public double precio { get; set; }
    }
}
