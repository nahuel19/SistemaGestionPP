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
    /// Clase de negocio relacionada a Doc_detalle_ingreso
    /// </summary>
    public class Doc_detalle_ingresoBLL
    {
        
        Doc_detalle_ingresoDAL doc_det_ingrDAL = new Doc_detalle_ingresoDAL();

        /// <summary>
        /// Llama a método GetById de DAL para buscar un detalle ingreso por id
        /// </summary>
        /// <param name="id">inta</param>
        /// <returns>Doc_detalle_ingreso</returns>
        public Doc_detalle_ingreso GetById(int id)
        {
            return doc_det_ingrDAL.GetById(id);
        }

        /// <summary>
        /// Llama a método List de Doc_detalle_ingresoDAL para listar los Doc_detalle_ingreso
        /// </summary>
        /// <returns>List Doc_detalle_ingreso</returns>
        public List<Doc_detalle_ingreso> List()
        {
            return doc_det_ingrDAL.List();
        }

        /// <summary>
        /// Llama a método Insert de Doc_detalle_ingresoDAL y le pasa una entidad para insertarla en la base
        /// </summary>
        /// <param name="entity">Doc_detalle_ingreso</param>
        /// <returns>Doc_detalle_ingreso</returns>
        public void Insert(Doc_detalle_ingreso entity)
        {
            doc_det_ingrDAL.Insert(entity);

        }

        /// <summary>
        /// Llama a método Update de Doc_detalle_ingresoDAL y le pasa una entidad para actualizarla en la base
        /// </summary>
        /// <param name="entity">Doc_detalle_ingreso</param>
        public void Update(Doc_detalle_ingreso entity)
        {
            doc_det_ingrDAL.Update(entity);
        }

        /// <summary>
        /// Llama a método UpdateFKprecio de Doc_detalle_ingresoDAL y le pasa una entidad para actualizar el precio en la base
        /// </summary>
        public void UpdateFKprecio(Doc_detalle_ingreso entity)
        {
            doc_det_ingrDAL.UpdateFKprecio(entity);
        }

        /// <summary>
        /// Llama a método Delete de ClienteDAL y le pasa un id para eliminar un Doc_detalle_ingreso en la base
        /// </summary>
        /// <param name="id">int</param>
        public void Delete(int id)
        {
            doc_det_ingrDAL.Delete(id);
        }


        /// <summary>
        /// Llama a método ListDetallesByCabecera de DAL para listar los detalles ingreso de una cabecera en específico
        /// </summary>
        /// <param name="id">inta</param>
        /// <returns>Lit Doc_detalle_ingreso</returns>
        public List<Doc_detalle_ingreso> ListDetallesByCabecera(int id_cab)
        {
            return doc_det_ingrDAL.ListDetallesByCabecera(id_cab);
        }

    }
}
