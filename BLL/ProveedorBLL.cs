using DAL;
using Entities;
using Services;
using Services.Documents;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Clase de negocio relacionada a Proveedor
    /// </summary>
    public class ProveedorBLL
    {
        ProveedorDAL proveedorDAL = new ProveedorDAL();

        /// <summary>
        /// Llama a método GetById de DAL para buscar un proveedor por id
        /// </summary>
        /// <param name="id">inta</param>
        /// <returns>Proveedor</returns>
        public Proveedor GetById(int id)
        {
            return proveedorDAL.GetById(id);
        }

        /// <summary>
        /// Llama a método List de ProveedorDAL para listar los Clientes
        /// </summary>
        /// <returns>List Proveedor</returns>
        public List<Proveedor> List()
        {
            return proveedorDAL.List();
        }

        /// <summary>
        /// Llama a método Insert de ProveedorDAL y le pasa una entidad para insertarla en la base
        /// </summary>
        /// <param name="entity">Proveedor</param>
        /// <returns>Proveedor</returns>
        public Proveedor Insert(Proveedor entity)
        {
            int errorExiste = 0;

            try
            {
                entity = proveedorDAL.Insert(entity);
                return entity;
            }
            catch (Exception ex)
            {
                System.Data.SqlClient.SqlException sqlException = ex as System.Data.SqlClient.SqlException;
                errorExiste = sqlException.Number;

                if (errorExiste == Convert.ToInt32(ConfigurationManager.AppSettings["existe"]))
                    throw new Exception(EValidaciones.existe);
                else
                    throw ex;
            }
        }

        /// <summary>
        /// Llama a método Update de ProveedorDAL y le pasa una entidad para actualizarla en la base
        /// </summary>
        /// <param name="entity">Proveedor</param>
        public void Update(Proveedor entity)
        {
            int errorExiste = 0;

            try
            {
                proveedorDAL.Update(entity);
            }
            catch (Exception ex)
            {
                System.Data.SqlClient.SqlException sqlException = ex as System.Data.SqlClient.SqlException;
                errorExiste = sqlException.Number;

                if (errorExiste == Convert.ToInt32(ConfigurationManager.AppSettings["existe"]))
                    throw new Exception(EValidaciones.existe);
                else
                    throw ex;
            }

        }

        /// <summary>
        /// Llama a método Delete de ProveedorDAL y le pasa un id para eliminar un Proveedor en la base
        /// </summary>
        /// <param name="id">int</param>
        public void Delete(int id)
        {
            proveedorDAL.Delete(id);
        }

        /// <summary>
        /// Llama al método Lista y lo filtra según el parámetro recibido
        /// </summary>
        /// <param name="filter">string</param>
        /// <returns>List Proveedor</returns>
        public List<Proveedor> FindBy(string filter)
        {
            return List().FindAll(x => x.nombre.StartWithIgnoreMM(filter) || x.num_documento.StartWithIgnoreMM(filter));
        }

        /// <summary>
        /// Exporta el listado de Proveedores a un excel
        /// </summary>
        public void ExportProveedoresExcel()
        {
            List<Proveedor> list = List();
            DataTable dt = Methods.ConvertToDataTable(list);
            dt.Columns.Remove("id");
            dt.Columns.Remove("fk_id_tipo_doc_identidad");
            dt.Columns[1].ColumnName = "doc";
            dt.Columns[2].ColumnName = "número";

            DocumentAbstract excelDocument = new ExcelDocument();
            excelDocument.CreateFileTemplate(dt, ConfigurationManager.AppSettings["FolderExcel"], ConfigurationManager.AppSettings["FileExcelProveedores"], "");                        
        }

        /// <summary>
        /// Exporta el listado de Proveedores a un PDF
        /// </summary>
        public void ExportProveedoresPDF()
        {
            List<Proveedor> list = List();
            DataTable dt = Methods.ConvertToDataTable(list);
            dt.Columns.Remove("id");
            dt.Columns.Remove("fk_id_tipo_doc_identidad");
            dt.Columns[1].ColumnName = "doc";
            dt.Columns[2].ColumnName = "número";

            DocumentAbstract pdfDocument = new PdfDocument();
            pdfDocument.CreateFileTemplate(dt, ConfigurationManager.AppSettings["FolderPDF"], ConfigurationManager.AppSettings["FilePdfProveedores"], "Listado Proveedores");

        }

    }
}
