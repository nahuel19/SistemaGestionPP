using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        
        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string apellido { get; set; }
        public string nombreCompleto { get; set; }

        [Required]
        public int fk_id_tipo_doc_identidad { get; set; }
        public string doc_identidad { get; set; }

        //^[0-9+-,]*$
        [Required]
        [StringLength(30)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El nro. de documento debe contener solo números. Puede tener ','.")]
        public string num_documento { get; set; }

        [Required]
        public System.DateTime fecha_nacimiento { get; set; }
        public int edad { get; set; }

        [StringLength(50)]
        public string direccion { get; set; }

        [StringLength(50)]
        [Phone]
        public string telefono { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string mail { get; set; }
        
        
                    
            
        



    }
}
