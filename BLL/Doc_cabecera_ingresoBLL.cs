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
    /// Clase de negocio relacionada a Doc_cabecera_ingreso
    /// </summary>
    public class Doc_cabecera_ingresoBLL
    {       
        Doc_cabecera_ingresoDAL doc_cab_ingrDAL = new Doc_cabecera_ingresoDAL();

        /// <summary>
        /// Llama a método GetById de Doc_cabecera_ingresoDAL para buscar una cabecera de ingreso por id
        /// </summary>
        /// <param name="id">inta</param>
        /// <returns>Doc_cabecera_ingreso</returns>
        public Doc_cabecera_ingreso GetById(int id)
        {
            try
            {
                return doc_cab_ingrDAL.GetById(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Llama a método List de Doc_cabecera_ingresoDAL para listar los Doc_cabecera_ingreso
        /// </summary>
        /// <returns>List Doc_cabecera_ingreso</returns>
        public List<Doc_cabecera_ingreso> List()
        {
            try
            {
                return doc_cab_ingrDAL.List();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Llama a método Insert de Doc_cabecera_ingresoDAL y le pasa una entidad para insertarla en la base
        /// </summary>
        /// <param name="entity">Doc_cabecera_ingreso</param>
        /// <returns>Doc_cabecera_ingreso</returns>
        public Doc_cabecera_ingreso Insert(Doc_cabecera_ingreso entity)
        {
            try
            {
                return doc_cab_ingrDAL.Insert(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        ///// <summary>
        ///// Llama a método Update de Doc_cabecera_ingresoDAL y le pasa una entidad para actualizarla en la base
        ///// </summary>
        ///// <param name="entity">Doc_cabecera_ingreso</param>
        //public void Update(Doc_cabecera_ingreso entity)
        //{
        //    try
        //    {
        //        doc_cab_ingrDAL.Update(entity);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Llama a método Delete de Doc_cabecera_ingresoDAL y le pasa un id para eliminar un Doc_cabecera_ingreso en la base
        /// </summary>
        /// <param name="id">int</param>
        public void Delete(int id)
        {
            try
            {
                doc_cab_ingrDAL.Delete(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Anular(Doc_cabecera_ingreso entity)
        {
            try
            {
                Delete(entity.id);

                PrecioDAL precioDAL = new PrecioDAL();
                StockDAL stockDAL = new StockDAL();
                Stock stock;

                foreach (var d in entity.listDetalle)
                {
                    stock = stockDAL.GetByIdProd(d.fk_id_producto);
                    stock.cantidad -= d.cantidad;
                    stockDAL.Update(stock);

                    precioDAL.Delete(d.fk_id_precio);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        /// <summary>
        /// Llama al método Lista y lo filtra según el parámetro recibido
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>List Doc_cabecera_ingreso</returns>
        //public List<Doc_cabecera_ingreso> FindBy(string filter)
        //{
        //    return List().FindAll(x => x.nombreCompleto.StartWithIgnoreMM(filter) || x.num_documento.StartWithIgnoreMM(filter));
        //}

    }
}
