using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Entidad Cliente
    /// </summary>
    public class Cliente : IEntityBase
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Nullable<int> fk_id_tipo_doc_identidad { get; set; }
        public Nullable<int> num_documento { get; set; }
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string mail { get; set; }
    }
}
