using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto : EntityBase
    {
        public override int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Fk_id_categoria { get; set; }
    }
}
