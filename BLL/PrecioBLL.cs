using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Clase de negocio relacionada a Precio
    /// </summary>
    public class PrecioBLL
    {
        
        PrecioDAL precioDAL = new PrecioDAL();

        /// <summary>
        /// Llama a método GetById de DAL para buscar un precio por id
        /// </summary>
        /// <param name="id">inta</param>
        /// <returns>Precio</returns>
        public Precio GetById(int id)
        {
            return precioDAL.GetById(id);
        }

        /// <summary>
        /// Llama a método List de PrecioDAL para listar los Precios
        /// </summary>
        /// <returns>List Precio</returns>
        public List<Precio> List()
        {
            return precioDAL.List();
        }

        /// <summary>
        /// Llama a método Insert de PrecioDAL y le pasa una entidad para insertarla en la base
        /// </summary>
        /// <param name="entity">Precio</param>
        /// <returns>Precio</returns>
        public void Insert(Precio entity)
        {
            precioDAL.Insert(entity);

        }

        /// <summary>
        /// Llama a método Update de PrecioDAL y le pasa una entidad para actualizarla en la base
        /// </summary>
        /// <param name="entity">Precio</param>
        public void Update(Precio entity)
        {
            precioDAL.Update(entity);
        }

        /// <summary>
        /// Llama a método Delete de PrecioDAL y le pasa un id para eliminar un Precio en la base
        /// </summary>
        /// <param name="id">int</param>
        public void Delete(int id)
        {
            precioDAL.Delete(id);
        }

    }
}
