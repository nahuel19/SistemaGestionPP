using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Familia : IEntityBase
    {
        public int id { get; set; }
        public string nombre { get; set; }

       
        public virtual ICollection<Patente> Patente { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
