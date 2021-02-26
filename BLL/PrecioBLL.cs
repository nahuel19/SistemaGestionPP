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
            try
            {
                return precioDAL.GetById(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Llama a método List de PrecioDAL para listar los Precios
        /// </summary>
        /// <returns>List Precio</returns>
        public List<Precio> List()
        {
            try
            {
                return precioDAL.List();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Llama a método Insert de PrecioDAL y le pasa una entidad para insertarla en la base
        /// </summary>
        /// <param name="entity">Precio</param>
        /// <returns>Precio</returns>
        public void Insert(Precio entity)
        {
            try
            {
                precioDAL.Insert(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Llama a método Update de PrecioDAL y le pasa una entidad para actualizarla en la base
        /// </summary>
        /// <param name="entity">Precio</param>
        public void Update(Precio entity)
        {
            try
            {
                precioDAL.Update(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Llama a método Delete de PrecioDAL y le pasa un id para eliminar un Precio en la base
        /// </summary>
        /// <param name="id">int</param>
        public void Delete(int id)
        {
            try
            {
                precioDAL.Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdatePrecioCategoria(int idCat, double porcentaje, string motivo)
        {
            try
            {
                precioDAL.UpdateByCategoria(idCat, porcentaje, motivo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
