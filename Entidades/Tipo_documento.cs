using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tipo_documento : EntityBase
    {
        public override int Id { get; set; }
        public string Tipo_docu { get; set; }
        public char Letra { get; set; }
        public int Sucursal { get; set; }
        public int Numero { get; set; }

    }
}
