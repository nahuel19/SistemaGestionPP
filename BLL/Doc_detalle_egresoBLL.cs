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
    /// Clase de negocio relacionada a Doc_detalle_egreso
    /// </summary>
    public class Doc_detalle_egresoBLL
    {        
        Doc_detalle_egresoDAL doc_det_egrDAL = new Doc_detalle_egresoDAL();

        /// <summary>
        /// Llama a método GetById de Doc_detalle_egresoDAL para buscar un detalle egreso por id
        /// </summary>
        /// <param name="id">inta</param>
        /// <returns>Doc_detalle_egreso</returns>
        public Doc_detalle_egreso GetById(int id)
        {
            return doc_det_egrDAL.GetById(id);
        }

        /// <summary>
        /// Llama a método List de Doc_detalle_egresoDAL para listar los Doc_detalle_egreso
        /// </summary>
        /// <returns>List Doc_detalle_egreso</returns>
        public List<Doc_detalle_egreso> List()
        {
            return doc_det_egrDAL.List();
        }

        /// <summary>
        /// Llama a método Insert de Doc_detalle_egresoDAL y le pasa una entidad para insertarla en la base
        /// </summary>
        /// <param name="entity">Doc_detalle_egreso</param>
        /// <returns>Doc_detalle_egreso</returns>
        public void Insert(Doc_detalle_egreso entity)
        {
            doc_det_egrDAL.Insert(entity);

        }

        /// <summary>
        /// Llama a método Update de Doc_detalle_egresoDAL y le pasa una entidad para actualizarla en la base
        /// </summary>
        /// <param name="entity">Doc_detalle_egreso</param>
        public void Update(Doc_detalle_egreso entity)
        {
            doc_det_egrDAL.Update(entity);
        }

        /// <summary>
        /// Llama a método Delete de Doc_detalle_egresoDAL y le pasa un id para eliminar un Doc_detalle_egreso en la base
        /// </summary>
        /// <param name="id">int</param>
        public void Delete(int id)
        {
            doc_det_egrDAL.Delete(id);
        }

        /// <summary>
        /// Llama al método Lista y lo filtra según el parámetro recibido
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>List Doc_detalle_egreso</returns>
        //public List<Doc_detalle_egreso> FindBy(string filter)
        //{
        //    return List().FindAll(x => x.nombreCompleto.StartWithIgnoreMM(filter) || x.num_documento.StartWithIgnoreMM(filter));
        //}

    }
}
