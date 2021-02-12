using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Entidad Producto
    /// </summary>
    public class Producto : IEntityBase
    {
        public int id { get; set; }

        public string codigo { get; set; }
        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        
        [StringLength(100)]
        public string descripcion { get; set; }

        [Required]
        public int fk_id_categoria { get; set; }
        public string categoria { get; set; }

        [Range(0, short.MaxValue, ErrorMessage = "Debe ingresar un valor numérico.")]
        public double peso { get; set; }
        public double alto { get; set; }
        public double ancho { get; set; }
        public double profundidad { get; set; }

        

        public double precio { get; set; }
        public int cantidad { get; set; }
    }
}
