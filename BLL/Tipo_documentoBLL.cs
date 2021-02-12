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
    /// Clase de negocio relacionada a Tipo_documento
    /// </summary>
    public class Tipo_documentoBLL
    {
        Tipo_documentoDAL tipo_docDAL = new Tipo_documentoDAL();

        /// <summary>
        /// Llama a método GetById de DAL para buscar un tipo de documento comercial por id
        /// </summary>
        /// <param name="id">inta</param>
        /// <returns>Tipo_documento</returns>
        public Tipo_documento GetById(int id)
        {
            return tipo_docDAL.GetById(id);
        }

        /// <summary>
        /// Llama a método List de Tipo_documentoDAL para listar los Tipo_documento
        /// </summary>
        /// <returns>List Tipo_documento</returns>
        public List<Tipo_documento> List()
        {
            return tipo_docDAL.List();
        }

        /// <summary>
        /// Llama a método Insert de Tipo_documentoDAL y le pasa una entidad para insertarla en la base
        /// </summary>
        /// <param name="entity">Tipo_documento</param>
        /// <returns>Tipo_documento</returns>
        public void Insert(Tipo_documento entity)
        {
            tipo_docDAL.Insert(entity);

        }

        /// <summary>
        /// Llama a método Update de Tipo_documentoDAL y le pasa una entidad para actualizarla en la base
        /// </summary>
        /// <param name="entity">Tipo_documento</param>
        public void Update(Tipo_documento entity)
        {
            tipo_docDAL.Update(entity);
        }

        /// <summary>
        /// Llama a método Delete de Tipo_documentoDAL y le pasa un id para eliminar un Tipo_documento en la base
        /// </summary>
        /// <param name="id">int</param>
        public void Delete(int id)
        {
            tipo_docDAL.Delete(id);
        }
    }
}
