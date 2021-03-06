﻿using DAL;
using Entities;
using Services;
using Services.Documents;
using Services.Excepciones;
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
    /// Clase de negocio relacionada a Doc_cabecera_egreso
    /// </summary>
    public class Doc_cabecera_egresoBLL
    {      
        Doc_cabecera_egresoDAL doc_cab_egrDAL = new Doc_cabecera_egresoDAL();

        Doc_detalle_egresoDAL detalleDAL = new Doc_detalle_egresoDAL();

        /// <summary>
        /// Llama a método GetById de Doc_cabecera_egresoDAL para buscar una cabecera egreso por id
        /// </summary>
        /// <param name="id">inta</param>
        /// <returns>Doc_cabecera_egreso</returns>
        public Doc_cabecera_egreso GetById(int id)
        {
            try
            {
                return doc_cab_egrDAL.GetById(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Llama a método List Doc_cabecera_egresoDAL para listar los Clientes
        /// </summary>
        /// <returns>List Doc_cabecera_egreso</returns>
        public List<Doc_cabecera_egreso> List()
        {
            try
            {
                return doc_cab_egrDAL.List();
            }
            catch (Exception ex)
            {

                throw ex; 
            }
        }

        /// <summary>
        /// Llama a método Insert de Doc_cabecera_egresoDAL y le pasa una entidad para insertarla en la base
        /// </summary>
        /// <param name="entity">Doc_cabecera_egreso</param>
        /// <returns>Doc_cabecera_egreso</returns>
        public Doc_cabecera_egreso Insert(Doc_cabecera_egreso entity)
        {
            StockBLL stockBLL = new StockBLL();
            List<string> prodsSinStock = new List<string>();
            try
            {
                foreach (var p in entity.listDetalle)
                {
                    Stock stock = stockBLL.GetByIdProducto(p.fk_id_producto);

                    if (p.cantidad > stock.cantidad)
                        prodsSinStock.Add(p.nombre_producto);
                }

                if (prodsSinStock.Any())
                    throw new SinStockException(prodsSinStock);

                return doc_cab_egrDAL.Insert(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        ///// <summary>
        ///// Llama a método Update de Doc_cabecera_egresoDAL y le pasa una entidad para actualizarla en la base
        ///// </summary>
        ///// <param name="entity">Doc_cabecera_egreso</param>
        //public void Update(Doc_cabecera_egreso entity)
        //{
        //    doc_cab_egrDAL.Update(entity);
        //}

        /// <summary>
        /// Llama a método Delete de Doc_cabecera_egresoDAL y le pasa un id para eliminar una Doc_cabecera_ingreso en la base
        /// </summary>
        /// <param name="id">int</param>
        public void Delete(int id)
        {
            try
            {
                doc_cab_egrDAL.Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Anular(Doc_cabecera_egreso entity)
        {
            try
            {
                Delete(entity.id);

                StockDAL stockDAL = new StockDAL();
                Stock stock;

                foreach (var d in entity.listDetalle)
                {
                    stock = stockDAL.GetByIdProd(d.fk_id_producto);
                    stock.cantidad += d.cantidad;
                    stockDAL.Update(stock);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void GetFacturaPDF(int idCabecera)
        {
            try
            {
                Doc_cabecera_egreso doc = doc_cab_egrDAL.GetById(idCabecera);

                if (doc.cancelada)
                    throw new FacturaAnuladaException(doc.factura);

                doc.listDetalle = detalleDAL.ListDetallesByCabecera(idCabecera);

                DataTable dt = Methods.ConvertToDataTable(doc.listDetalle);
                dt.Columns.Remove("id");
                dt.Columns.Remove("fk_id_doc_cabecera_egreso");
                dt.Columns.Remove("fk_id_producto");

                Dictionary<string, string> titulos = new Dictionary<string, string>();
                titulos.Add("Documento", doc.factura);
                titulos.Add("Fecha", doc.fecha.ToString());
                titulos.Add("Cliente", doc.nombre_cliente);

                DocumentAbstract pdfDocument = new PdfDocument();
                pdfDocument.CreateFileTemplate(dt, ConfigurationManager.AppSettings["FolderFacturas"], doc.factura + ".pdf", titulos);
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
        /// <returns>List Doc_cabecera_egreso</returns>
        //public List<Doc_cabecera_egreso> FindBy(string filter)
        //{
        //    return List().FindAll(x => x..StartWithIgnoreMM(filter) || x.num_documento.StartWithIgnoreMM(filter));
        //}
    }
}
