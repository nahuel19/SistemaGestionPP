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
    /// Clase de negocio relacionada a Doc_cabecera_egreso
    /// </summary>
    public class Doc_cabecera_egresoBLL
    {      
        Doc_cabecera_egresoDAL doc_cab_egrDAL = new Doc_cabecera_egresoDAL();

        /// <summary>
        /// Llama a método GetById de Doc_cabecera_egresoDAL para buscar una cabecera egreso por id
        /// </summary>
        /// <param name="id">inta</param>
        /// <returns>Doc_cabecera_egreso</returns>
        public Doc_cabecera_egreso GetById(int id)
        {
            return doc_cab_egrDAL.GetById(id);
        }

        /// <summary>
        /// Llama a método List Doc_cabecera_egresoDAL para listar los Clientes
        /// </summary>
        /// <returns>List Doc_cabecera_egreso</returns>
        public List<Doc_cabecera_egreso> List()
        {
            return doc_cab_egrDAL.List();
        }

        /// <summary>
        /// Llama a método Insert de Doc_cabecera_egresoDAL y le pasa una entidad para insertarla en la base
        /// </summary>
        /// <param name="entity">Doc_cabecera_egreso</param>
        /// <returns>Doc_cabecera_egreso</returns>
        public void Insert(Doc_cabecera_egreso entity)
        {
            doc_cab_egrDAL.Insert(entity);

        }

        /// <summary>
        /// Llama a método Update de Doc_cabecera_egresoDAL y le pasa una entidad para actualizarla en la base
        /// </summary>
        /// <param name="entity">Doc_cabecera_egreso</param>
        public void Update(Doc_cabecera_egreso entity)
        {
            doc_cab_egrDAL.Update(entity);
        }

        /// <summary>
        /// Llama a método Delete de Doc_cabecera_egresoDAL y le pasa un id para eliminar una Doc_cabecera_ingreso en la base
        /// </summary>
        /// <param name="id">int</param>
        public void Delete(int id)
        {
            doc_cab_egrDAL.Delete(id);
        }

        /// <summary>
        /// Llama al método Lista y lo filtra según el parámetro recibido
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>List Doc_cabecera_egreso</returns>
        //public List<Doc_cabecera_egreso> FindBy(string filter)
        //{
        //    return List().FindAll(x => x..StartWithIgnoreMM(filter) || x.num_documento.StartWithIgnoreMM(filter));
        //}
    }
}
