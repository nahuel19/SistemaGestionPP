using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Entidad Tipo Documento de Indentidad
    /// </summary>
    public class TipoDoc_identidad : IEntityBase
    {
        public int id { get; set; }
        public string doc_identidad { get; set; }
    }
}
