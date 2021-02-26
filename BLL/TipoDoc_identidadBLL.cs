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
    /// Clase de negocio relacionada a TipoDoc_identidad
    /// </summary>
    public class TipoDoc_identidadBLL
    {
        TipoDoc_identidadDAL tipoDoc_identDAL = new TipoDoc_identidadDAL();

        /// <summary>
        /// Llama a método GetById de DAL para buscar un tipo de documento de identidad por id
        /// </summary>
        /// <param name="id">inta</param>
        /// <returns>TipoDoc_identidad</returns>
        public TipoDoc_identidad GetById(int id)
        {
            try
            {
                return tipoDoc_identDAL.GetById(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Llama a método List de TipoDoc_identidadDAL para listar los TipoDoc_identidad
        /// </summary>
        /// <returns>List TipoDoc_identidad</returns>
        public List<TipoDoc_identidad> List()
        {
            try
            {
                return tipoDoc_identDAL.List();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Llama a método Insert de TipoDoc_identidadDAL y le pasa una entidad para insertarla en la base
        /// </summary>
        /// <param name="entity">TipoDoc_identidad</param>
        /// <returns>TipoDoc_identidad</returns>
        public void Insert(TipoDoc_identidad entity)
        {
            try
            {
                tipoDoc_identDAL.Insert(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Llama a método Update de TipoDoc_identidadDAL y le pasa una entidad para actualizarla en la base
        /// </summary>
        /// <param name="entity">TipoDoc_identidad</param>
        public void Update(TipoDoc_identidad entity)
        {
            try
            {
                tipoDoc_identDAL.Update(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Llama a método Delete de TipoDoc_identidadDAL y le pasa un id para eliminar un TipoDoc_identidad en la base
        /// </summary>
        /// <param name="id">int</param>
        public void Delete(int id)
        {
            try
            {
                tipoDoc_identDAL.Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
