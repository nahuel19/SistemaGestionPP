using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoDoc_identidad : EntityBase
    {
        public override int Id { get; set; }
        public string Doc_identidad { get; set; }
    }
}
