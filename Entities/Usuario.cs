using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Usuario : IEntityBase
    {
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        public byte[] pass { get; set; }

        [Required]
        public string passSinEncriptar { get; set; }
    }
}
