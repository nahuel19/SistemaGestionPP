using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Entidad Tipo Documento
    /// </summary>
    public class Tipo_documento : IEntityBase
    {
        public int id { get; set; }
        public string tipo_documento { get; set; }
        public string letra { get; set; }
        public int sucursal { get; set; }
        public int numero { get; set; }
    }
}
