﻿using DAL;
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
    /// Clase de negocio relacionada a Cliente
    /// </summary>
    public class ClienteBLL
    {      
        ClienteDAL cliDAL = new ClienteDAL();

        /// <summary>
        /// Llama a método GetById de DAL para buscar un Cliente por id
        /// </summary>
        /// <param name="id">inta</param>
        /// <returns>Cliente</returns>
        public Cliente GetById(int id)
        {
            try
            {
                Cliente entity = cliDAL.GetById(id);

                entity.nombreCompleto = entity.apellido + " " + entity.nombre;
                entity.edad = Methods.CalculateAge(entity.fecha_nacimiento);

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Llama a método List de ClienteDAL para listar los Clientes
        /// </summary>
        /// <returns>List Cliente</returns>
        public List<Cliente> List()
        {
            try
            {
                List<Cliente> list = cliDAL.List();

                foreach (var entity in list)
                {
                    entity.nombreCompleto = entity.apellido + " " + entity.nombre;
                    entity.edad = Methods.CalculateAge(entity.fecha_nacimiento);
                }


                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Llama a método Insert de ClienteDAL y le pasa una entidad para insertarla en la base
        /// </summary>
        /// <param name="entity">Cliente</param>
        /// <returns>Cliente</returns>
        public Cliente Insert(Cliente entity)
        {
            int age = Methods.CalculateAge(entity.fecha_nacimiento);
            int errorExiste = 0;
            
            if (age >= 18)
            {
                try
                {
                    entity = cliDAL.Insert(entity);
                    return entity;
                }
                catch(Exception ex)
                {
                    System.Data.SqlClient.SqlException sqlException = ex as System.Data.SqlClient.SqlException;
                    errorExiste = sqlException.Number;

                    if (errorExiste == Convert.ToInt32(ConfigurationManager.AppSettings["existe"]))
                        throw new Exception(EValidaciones.existe);
                    else
                        throw ex;
                }
            }                   
            else throw new Exception(EValidaciones.menor);
            
        }

        /// <summary>
        /// Llama a método Update de ClienteDAL y le pasa una entidad para actualizarla en la base
        /// </summary>
        /// <param name="entity">Cliente</param>
        public void Update(Cliente entity)
        {
            int age = Methods.CalculateAge(entity.fecha_nacimiento);
            int errorExiste = 0;

            if (age >= 18)
            {
                try
                {
                    cliDAL.Update(entity);
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
            else throw new Exception(EValidaciones.menor);

        }

        /// <summary>
        /// Llama a método Delete de ClienteDAL y le pasa un id para eliminar una cliente en la base
        /// </summary>
        /// <param name="id">int</param>
        public void Delete(int id)
        {
            try
            {
                cliDAL.Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Llama al método Lista y lo filtra según el parámetro recibido
        /// </summary>
        /// <param name="filter">string</param>
        /// <returns>List Cliente</returns>
        public List<Cliente> FindBy(string filter)
        {
            try
            {
                return List().FindAll(x => x.nombreCompleto.StartWithIgnoreMM(filter) || x.num_documento.StartWithIgnoreMM(filter));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// Exporta el listado de Clientes a un excel
        /// </summary>
        public void ExportProductosExcel()
        {
            try
            {
                List<Cliente> list = List();
                DataTable dt = Methods.ConvertToDataTable(list);
                dt.Columns.Remove("id");
                dt.Columns.Remove("fk_id_tipo_doc_identidad");
                dt.Columns.Remove("nombre");
                dt.Columns.Remove("apellido");
                dt.Columns[0].ColumnName = "nombre";
                dt.Columns[1].ColumnName = "doc";
                dt.Columns[2].ColumnName = "número";


                DocumentAbstract excelDocument = new ExcelDocument();
                excelDocument.CreateFileTemplate(dt, ConfigurationManager.AppSettings["FileExcelClientes"], ConfigurationManager.AppSettings["FileExcelClientes"], new Dictionary<string, string>());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Exporta el listado de Clientes a un PDF
        /// </summary>
        public void ExportProductosPDF()
        {
            try
            {
                List<Cliente> list = List();
                DataTable dt = Methods.ConvertToDataTable(list);
                dt.Columns.Remove("id");
                dt.Columns.Remove("fk_id_tipo_doc_identidad");
                dt.Columns.Remove("nombre");
                dt.Columns.Remove("apellido");
                dt.Columns[0].ColumnName = "nombre";
                dt.Columns[1].ColumnName = "doc";
                dt.Columns[2].ColumnName = "número";

                DocumentAbstract pdfDocument = new PdfDocument();
                pdfDocument.CreateFileTemplate(dt, ConfigurationManager.AppSettings["FolderPDF"], ConfigurationManager.AppSettings["FilePdfClientes"], new Dictionary<string, string>());
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
