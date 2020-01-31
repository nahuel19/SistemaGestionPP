using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Proveedor : EntityBase
    {
        public override int Id { get; set; }
        public string Nombre { get; set; }
        public int Fk_id_tipo_doc_identidad { get; set; }
        public string Num_documento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public string Url { get; set; }
    }
}
