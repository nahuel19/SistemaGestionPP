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
    /// Clase de negocio relacionada a Tipo_movimiento_prod
    /// </summary>
    public class Tipo_movimiento_prodBLL
    {
        Tipo_movimiento_prodDAL tipo_mov_prodDAL = new Tipo_movimiento_prodDAL();

        /// <summary>
        /// Llama a método GetById de DAL para buscar un tipo de movimiento de prod por id
        /// </summary>
        /// <param name="id">inta</param>
        /// <returns>Tipo_movimiento_prod</returns>
        public Tipo_movimiento_prod GetById(int id)
        {
            try
            {
                return tipo_mov_prodDAL.GetById(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Llama a método List de Tipo_movimiento_prodDAL para listar los Tipo_movimiento_prod
        /// </summary>
        /// <returns>List Tipo_movimiento_prod</returns>
        public List<Tipo_movimiento_prod> List()
        {
            try
            {
                return tipo_mov_prodDAL.List();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Llama a método Insert de Tipo_movimiento_prodDAL y le pasa una entidad para insertarla en la base
        /// </summary>
        /// <param name="entity">Tipo_movimiento_prod</param>
        /// <returns>Tipo_movimiento_prod</returns>
        public void Insert(Tipo_movimiento_prod entity)
        {
            try
            {
                tipo_mov_prodDAL.Insert(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Llama a método Update de Tipo_movimiento_prodDAL y le pasa una entidad para actualizarla en la base
        /// </summary>
        /// <param name="entity">Tipo_movimiento_prod</param>
        public void Update(Tipo_movimiento_prod entity)
        {
            try
            {
                tipo_mov_prodDAL.Update(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Llama a método Delete de Tipo_movimiento_prodDAL y le pasa un id para eliminar un Tipo_movimiento_prod en la base
        /// </summary>
        /// <param name="id">int</param>
        public void Delete(int id)
        {
            try
            {
                tipo_mov_prodDAL.Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
