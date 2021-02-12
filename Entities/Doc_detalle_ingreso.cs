using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Entidad Documento Detalle Ingreso
    /// </summary>
    public class Doc_detalle_ingreso : IEntityBase
    {
        public int id { get; set; }
        public int fk_id_doc_cabecera_ingreso { get; set; }
        public int fk_id_producto { get; set; }
        public int cantidad { get; set; }
        public double costo { get; set; }
        public int fk_id_precio { get; set; }


        public string nombre_producto { get; set; }
        public double precio { get; set; }
    }
}
