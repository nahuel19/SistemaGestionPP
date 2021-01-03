using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Entidad Categoria
    /// </summary>
    public class Categoria : IEntityBase
    {
        public int id { get; set; }
        public string categoria { get; set; }
    }
}
