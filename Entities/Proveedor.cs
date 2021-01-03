using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Entidad Proveedor
    /// </summary>
    public class Proveedor : IEntityBase
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int fk_id_tipo_doc_identidad { get; set; }
        public string num_documento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string mail { get; set; }
        public string url { get; set; }
    }
}
