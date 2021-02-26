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
    /// Clase de negocio relacionada a Producto
    /// </summary>
    public class ProductoBLL
    {       

        ProductoDAL prodDAL = new ProductoDAL();

        /// <summary>
        /// Llama a método GetById de DAL para buscar un producto por id
        /// </summary>
        /// <param name="id">inta</param>
        /// <returns>Producto</returns>
        public Producto GetById(int id)
        {
            try
            {
                return prodDAL.GetById(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Llama a método List de ProductoDAL para listar los Productos
        /// </summary>
        /// <returns>List Producto</returns>
        public List<Producto> List()
        {
            try
            {
                return prodDAL.List();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Llama a método Insert de ProductoDAL y le pasa una entidad para insertarla en la base
        /// </summary>
        /// <param name="entity">Producto</param>
        /// <returns>Producto</returns>
        public Producto Insert(Producto entity)
        {
            int errorExiste = 0;
            StockDAL stockDAL = new StockDAL();

            try
            {
                entity = prodDAL.Insert(entity);

                Stock stock = new Stock();
                stock.fk_id_producto = entity.id;
                stock.cantidad = 0;
                stockDAL.Insert(stock);

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
        /// Llama a método Update de ProductoDAL y le pasa una entidad para actualizarla en la base
        /// </summary>
        /// <param name="entity">Producto</param>
        public void Update(Producto entity)
        {
            int errorExiste = 0;
            
            try
            {
                prodDAL.Update(entity);
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
        /// Llama a método Delete de ProductoDAL y le pasa un id para eliminar un Producto en la base
        /// </summary>
        /// <param name="id">int</param>
        public void Delete(int id)
        {
            prodDAL.Delete(id);
        }

        /// <summary>
        /// Llama al método Lista y lo filtra según el parámetro recibido
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>List Producto</returns>
        public List<Producto> FindBy(string filter)
        {
            return List().FindAll(x => x.nombre.StartWithIgnoreMM(filter) || x.codigo.StartWithIgnoreMM(filter));
        }

        
        /// <summary>
        /// Exporta el listado de Productos a un excel
        /// </summary>
        public void ExportPresupuestoExcel(List<Producto> list)
        {
            try
            {
                DataTable dt = Methods.ConvertToDataTable(list);
                dt.Columns.Remove("id");
                dt.Columns.Remove("fk_id_categoria");
                dt.Columns.Remove("categoria");
                dt.Columns.Add("subtotal");

                double tot = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["subtotal"] = Convert.ToDouble(dt.Rows[i]["cantidad"]) * Convert.ToDouble(dt.Rows[i]["precio"]);
                    tot += Convert.ToDouble(dt.Rows[i]["cantidad"]) * Convert.ToDouble(dt.Rows[i]["precio"]);
                }

                dt.Rows.Add("", "", "", "", "", "", "", "", "Total: $", tot.ToString());




                DocumentAbstract excelDocument = new ExcelDocument();
                excelDocument.CreateFileTemplate(dt, ConfigurationManager.AppSettings["FolderExcel"], ConfigurationManager.AppSettings["FileExcelPresupuesto"], new Dictionary<string, string>());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Exporta el listado de Productos a un PDF
        /// </summary>
        public void ExportPresupuestoPDF(List<Producto> list)
        {
            try
            {
                DataTable dt = Methods.ConvertToDataTable(list);
                dt.Columns.Remove("id");
                dt.Columns.Remove("fk_id_categoria");
                dt.Columns.Remove("categoria");
                dt.Columns.Remove("descripcion");
                dt.Columns.Add("subtotal");

                double tot = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["subtotal"] = Convert.ToDouble(dt.Rows[i]["cantidad"]) * Convert.ToDouble(dt.Rows[i]["precio"]);
                    tot += Convert.ToDouble(dt.Rows[i]["cantidad"]) * Convert.ToDouble(dt.Rows[i]["precio"]);
                }

                dt.Rows.Add("", "", "", "", "", "", "", "Total: $", tot.ToString());

                DocumentAbstract pdfDocument = new PdfDocument();
                pdfDocument.CreateFileTemplate(dt, ConfigurationManager.AppSettings["FolderPDF"], ConfigurationManager.AppSettings["FilePdfPresupuesto"], new Dictionary<string, string>());
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
