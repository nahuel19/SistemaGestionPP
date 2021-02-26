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
    /// Clase de negocio relacionada a Movimiento_producto
    /// </summary>
    public class Movimiento_productoBLL
    {
        
        Movimiento_productoDAL movimiento_productoDAL = new Movimiento_productoDAL();

        /// <summary>
        /// Llama a método GetById de DAL para buscar un mov de producto por id
        /// </summary>
        /// <param name="id">inta</param>
        /// <returns>Movimiento_producto</returns>
        public Movimiento_producto GetById(int id)
        {
            try
            {
                return movimiento_productoDAL.GetById(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Llama a método List de Movimiento_productoDAL para listar los Movimiento_producto
        /// </summary>
        /// <returns>List Movimiento_producto</returns>
        public List<Movimiento_producto> List()
        {
            try
            {
                return movimiento_productoDAL.List();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Llama a método Insert de Movimiento_productoDAL y le pasa una entidad para insertarla en la base
        /// </summary>
        /// <param name="entity">Movimiento_producto</param>
        /// <returns>Movimiento_producto</returns>
        public void Insert(Movimiento_producto entity)
        {
            try
            {
                movimiento_productoDAL.Insert(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Llama a método Update de Movimiento_productoDAL y le pasa una entidad para actualizarla en la base
        /// </summary>
        /// <param name="entity">Movimiento_producto</param>
        public void Update(Movimiento_producto entity)
        {
            try
            {
                movimiento_productoDAL.Update(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Llama a método Delete de Movimiento_productoDAL y le pasa un id para eliminar un Movimiento_producto en la base
        /// </summary>
        /// <param name="id">int</param>
        public void Delete(int id)
        {
            try
            {
                movimiento_productoDAL.Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
