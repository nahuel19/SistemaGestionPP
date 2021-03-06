﻿using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Clase de acceso a datos para manejar la tabla Doc_cabecera_egreso
    /// </summary>
    public class Doc_cabecera_egresoDAL : IDAL<Doc_cabecera_egreso>
    {
        /// <summary>
        /// Inserta registros en la tabla Doc_cabecera_egreso
        /// </summary>
        /// <param name="entity">Entidad Doc_cabecera_egreso</param>
        /// <returns>Entidad Doc_cabecera_egreso</returns>
        public Doc_cabecera_egreso Insert(Doc_cabecera_egreso entity)
        {
            #region query detalle
            string queryDetalle = "INSERT INTO [dbo].[Doc_detalle_egreso] " +
                               "([fk_id_doc_cabecera_egreso] " +
                               ",[fk_id_producto] " +
                               ",[cantidad] " +
                               ",[precio]) " +
                         "VALUES " +
                               "(@fk_id_doc_cabecera_egreso " +
                               ",@fk_id_producto " +
                               ",@cantidad " +
                               ",@precio) ;SELECT SCOPE_IDENTITY()";
            #endregion
            using (SqlConnection conn = ConnectionBD.Instance().Conect())
            {
                conn.Open();
                SqlTransaction transaction;
                transaction = conn.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_sig_documento_venta @id_tipo_doc, @id_cliente, @id_usuario", conn, transaction))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id_tipo_doc", entity.fk_id_tipo_doc);
                        cmd.Parameters.AddWithValue("@id_cliente", entity.fk_id_cliente);
                        cmd.Parameters.AddWithValue("@id_usuario", entity.fk_id_usuario);
                      
                        entity.id = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    foreach(var d in entity.listDetalle)
                    {
                        using (SqlCommand cmd = new SqlCommand(queryDetalle, conn, transaction))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@fk_id_doc_cabecera_egreso", entity.id);
                            cmd.Parameters.AddWithValue("@fk_id_producto", d.fk_id_producto);
                            cmd.Parameters.AddWithValue("@cantidad", d.cantidad);
                            cmd.Parameters.AddWithValue("@precio", d.precio);
                       
                            entity.id = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        using (SqlCommand cmd = new SqlCommand("sp_update_stock_mov_prod_egresos @id_prod, @cant, @tipo_mov, @extra ;SELECT SCOPE_IDENTITY()", conn, transaction))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@id_prod", d.fk_id_producto);
                            cmd.Parameters.AddWithValue("@cant", d.cantidad);
                            cmd.Parameters.AddWithValue("@tipo_mov", ConfigurationManager.AppSettings["egresoStock"]);
                            cmd.Parameters.AddWithValue("@extra", entity.letra + entity.sucursal.ToString() + entity.numero.ToString());

                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
                catch (SqlException sqlError)
                {
                    transaction.Rollback();
                    throw sqlError;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }







            return entity;
        }

        /// <summary>
        /// Actualiza registros en la tabla Doc_cabecera_egreso
        /// </summary>
        /// <param name="entity">Entidad Doc_cabecera_egreso</param>
        public void Update(Doc_cabecera_egreso entity)
        {
            throw new NotImplementedException();

            #region posible update
            //string SqlString = "UPDATE [dbo].[Doc_cabecera_egreso] " +
            //                   "SET [fk_id_tipo_doc] = @fk_id_tipo_doc " +
            //                      ",[fk_id_cliente] = @fk_id_cliente " +
            //                      ",[letra] = @letra " +
            //                      ",[sucursal] = @sucursal " +
            //                      ",[numero] = @numero " +
            //                      ",[fk_id_usuario] = @fk_id_usuario " +
            //                  "WHERE id = @id ";

            //try
            //{
            //    using (SqlConnection conn = ConnectionBD.Instance().Conect())
            //    {
            //        using (SqlCommand cmd = new SqlCommand(SqlString, conn))
            //        {
            //            cmd.CommandType = CommandType.Text;
            //            cmd.Parameters.AddWithValue("@id", entity.id);
            //            cmd.Parameters.AddWithValue("@fk_id_tipo_doc", entity.fk_id_tipo_doc);
            //            cmd.Parameters.AddWithValue("@fk_id_cliente", entity.fk_id_cliente);
            //            cmd.Parameters.AddWithValue("@letra", entity.letra);
            //            cmd.Parameters.AddWithValue("@sucursal", entity.sucursal);
            //            cmd.Parameters.AddWithValue("@numero", entity.numero);
            //            cmd.Parameters.AddWithValue("@fk_id_usuario", entity.fecha);

            //            conn.Open();

            //            cmd.ExecuteNonQuery();
            //        }

            //    }

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            #endregion
        }

        /// <summary>
        /// Anula registros de la tabla Doc_cabecera_egreso
        /// </summary>
        /// <param name="id">int del id a eliminar</param>
        public void Delete(int id)
        {
            string SqlString = "UPDATE [dbo].[Doc_cabecera_egreso] " +
                               "SET [cancelada] = 1 " +
                              "WHERE id = @id ";

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", id);
                        conn.Open();

                        cmd.ExecuteNonQuery();
                    }

                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Selecciona registros de la tabla Doc_cabecera_egreso
        /// </summary>
        /// <returns>Lista Doc_cabecera_egreso</returns>
        public List<Doc_cabecera_egreso> List()
        {
            List <Doc_cabecera_egreso> result = new List<Doc_cabecera_egreso>();

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_list_facturas_ventas", conn))
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Doc_cabecera_egreso entity = LoadEntity(dr);
                                result.Add(entity);
                            }
                        }
                    }
                }               
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// Selecciona un registro de la tabla Doc_cabecera_egreso
        /// </summary>
        /// <param name="id">int del registro a seleccionar</param>
        /// <returns>Doc_cabecera_egreso</returns>
        public Doc_cabecera_egreso GetById(int id)
        {
            Doc_cabecera_egreso entity = null;
            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_factura_venta_by_id @id", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", id);
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                entity = LoadEntity(dr);
                            }
                        }


                    }

                }
              
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }


        /// <summary>
        /// Carga una entidad de Doc_cabecera_egreso a partir de un DataReader
        /// </summary>
        /// <param name="dr">IDataReader </param>
        /// <returns>Doc_cabecera_egreso</returns>
        private Doc_cabecera_egreso LoadEntity(IDataReader dr)
        {
            Doc_cabecera_egreso entity = new Doc_cabecera_egreso()
            {
                id = dr.GetByNameInt("id"),
                fk_id_tipo_doc = dr.GetByNameInt("fk_id_tipo_doc"),
                fk_id_cliente = dr.GetByNameInt("fk_id_cliente"),
                letra = dr.GetByNameString("letra"),
                sucursal = dr.GetByNameInt("sucursal"),
                numero = dr.GetByNameInt("numero"),    
                fecha = dr.GetByNameDT("fecha"),   
                fk_id_usuario = dr.GetByNameInt("fk_id_usuario"),
                tipo_documento = dr.GetByNameString("tipo_documento"),
                cancelada = dr.GetByNameBool("cancelada"),
                factura = dr.GetByNameString("factura"),
                nombre_cliente = dr.GetByNameString("cliente")
            };

            return entity;
        }

    }
}
