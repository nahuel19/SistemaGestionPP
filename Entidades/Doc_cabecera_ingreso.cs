using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Doc_cabecera_ingreso : EntityBase
    {
        public override int Id { get; set; }
        public int Fk_id_tipo_doc { get; set; }
        public int Fk_id_proveedor { get; set; }
        public char Letra { get; set; }
        public int Sucursal { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
    }
}
