using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Entidad Documento Detalle Egreso
    /// </summary>
    public class Doc_detalle_egreso : IEntityBase
    {
        public int id { get; set; }
        public int fk_id_doc_cabecera_egreso { get; set; }
        public int fk_id_producto { get; set; }
        public string nombre_producto { get; set; }        
        public double precio { get; set; }
        public int cantidad { get; set; }


    }
}
