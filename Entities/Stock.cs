using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Entidad Stock
    /// </summary>
    public class Stock : IEntityBase
    {
        public int id { get; set; }
        public int fk_id_producto { get; set; }
        public int cantidad { get; set; }
    }
}
