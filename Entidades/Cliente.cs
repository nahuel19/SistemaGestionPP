using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente : EntityBase
    {
        public override int Id { get; set;}
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Fk_id_tipo_doc_identidad { get; set; }
        public int Num_documento { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
    }
}
