using Entities;
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
    /// Clase de acceso a datos para manejar la tabla Doc_cabecera_ingreso
    /// </summary>
    public class Doc_cabecera_ingresoDAL : IDAL<Doc_cabecera_ingreso>
    {
        /// <summary>
        /// Inserta registros en la tabla Doc_cabecera_ingreso
        /// </summary>
        /// <param name="entity">Entidad Doc_cabecera_ingreso</param>
        /// <returns>Entidad Doc_cabecera_ingreso</returns>
        public Doc_cabecera_ingreso Insert(Doc_cabecera_ingreso entity)
        {           
            #region query cabcera
            string SqlStringCabecera = "INSERT INTO [dbo].[Doc_cabecera_ingreso] " +
                               "([fk_id_tipo_doc] " +
                               ",[fk_id_proveedor] " +
                               ",[letra] " +
                               ",[sucursal] " +
                               ",[numero] " +
                               ",[fecha] " +
                               ",[fk_id_usuario]) " +
                         "VALUES " +
                               "(@fk_id_tipo_doc " +
                               ", @fk_id_proveedor " +
                               ", @letra " +
                               ", @sucursal " +
                               ", @numero " +
                               ", @fecha " +
                               ", @fk_id_usuario) ;SELECT SCOPE_IDENTITY()";
            #endregion

            #region query detalle 
            string SqlStringDetalle = "INSERT INTO [dbo].[Doc_detalle_ingreso] " +
                              "([fk_id_doc_cabecera_ingreso] " +
                              ",[fk_id_producto] " +
                              ",[cantidad] " +
                              ",[costo] " +
                              ",[fk_id_precio] " +
                              ",[precio_venta]) " +
                        "VALUES " +
                              "(@fk_id_doc_cabecera_ingreso " +
                              ",@fk_id_producto " +
                              ",@cantidad " +
                              ",@costo " +
                              ",@fk_id_precio " +
                              ",@precio) ;SELECT SCOPE_IDENTITY()";
            #endregion

            using (SqlConnection conn = ConnectionBD.Instance().Conect())
            {
                conn.Open();
                SqlTransaction transaction;
                transaction = conn.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand(SqlStringCabecera, conn, transaction))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@fk_id_tipo_doc", entity.fk_id_tipo_doc);
                        cmd.Parameters.AddWithValue("@fk_id_proveedor", entity.fk_id_proveedor);
                        cmd.Parameters.AddWithValue("@letra", entity.letra);
                        cmd.Parameters.AddWithValue("@sucursal", entity.sucursal);
                        cmd.Parameters.AddWithValue("@numero", entity.numero);
                        cmd.Parameters.AddWithValue("@fecha", entity.fecha);
                        cmd.Parameters.AddWithValue("@fk_id_usuario", entity.fk_id_usuario);

                        entity.id = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    foreach(var d in entity.listDetalle)
                    {

                        using (SqlCommand cmd = new SqlCommand("sp_actualizar_precio_by_id_prod @id_prod, @costo, @precio ;SELECT SCOPE_IDENTITY()", conn, transaction))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@id_prod", d.fk_id_producto);
                            cmd.Parameters.AddWithValue("@costo", d.costo);
                            cmd.Parameters.AddWithValue("@precio", d.precio);
                           
                            d.fk_id_precio = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        using (SqlCommand cmd = new SqlCommand(SqlStringDetalle, conn, transaction))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@fk_id_doc_cabecera_ingreso", entity.id);
                            cmd.Parameters.AddWithValue("@fk_id_producto", d.fk_id_producto);
                            cmd.Parameters.AddWithValue("@cantidad", d.cantidad);
                            cmd.Parameters.AddWithValue("@costo", d.costo);
                            cmd.Parameters.AddWithValue("@fk_id_precio", d.fk_id_precio);
                            cmd.Parameters.AddWithValue("@precio", d.precio);

                            d.id = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        using (SqlCommand cmd = new SqlCommand("sp_update_stock_mov_prod_ingresos @id_prod, @cant, @tipo_mov, @extra ;SELECT SCOPE_IDENTITY()", conn, transaction))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@id_prod", d.fk_id_producto);
                            cmd.Parameters.AddWithValue("@cant", d.cantidad);
                            cmd.Parameters.AddWithValue("@tipo_mov", ConfigurationManager.AppSettings["ingresoStock"]);
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
        /// Actualiza registros en la tabla Doc_cabecera_ingreso
        /// </summary>
        /// <param name="entity">Entidad Doc_cabecera_ingreso</param>
        public void Update(Doc_cabecera_ingreso entity)
        {
            throw new NotImplementedException();

            #region posible update
            //string SqlString = "UPDATE [dbo].[Doc_cabecera_ingreso] " +
            //                   "SET [fk_id_tipo_doc] = @fk_id_tipo_doc " +
            //                      ",[fk_id_proveedor] = @fk_id_proveedor " +
            //                      ",[letra] = @letra " +
            //                      ",[sucursal] = @sucursal " +
            //                      ",[numero] = @numero " +
            //                      ",[fecha] = @fecha " +
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
            //            cmd.Parameters.AddWithValue("@fk_id_proveedor", entity.fk_id_proveedor);
            //            cmd.Parameters.AddWithValue("@letra", entity.letra);
            //            cmd.Parameters.AddWithValue("@sucursal", entity.sucursal);
            //            cmd.Parameters.AddWithValue("@numero", entity.numero);
            //            cmd.Parameters.AddWithValue("@fecha", entity.fecha);

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
        /// Anula registros de la tabla Doc_cabecera_ingreso
        /// </summary>
        /// <param name="id">int del id a eliminar</param>
        public void Delete(int id)
        {
            string SqlString = "UPDATE [dbo].[Doc_cabecera_ingreso] " +
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
        /// Selecciona registros de la tabla Doc_cabecera_ingreso
        /// </summary>
        /// <returns>Lista Doc_cabecera_ingreso</returns>
        public List<Doc_cabecera_ingreso> List()
        {            
            List<Doc_cabecera_ingreso> result = new List<Doc_cabecera_ingreso>();

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_list_facturas_compras", conn))
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Doc_cabecera_ingreso entity = LoadEntity(dr);
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
        /// Selecciona un registro de la tabla Doc_cabecera_ingreso
        /// </summary>
        /// <param name="id">int del registro a seleccionar</param>
        /// <returns>Doc_cabecera_ingreso</returns>
        public Doc_cabecera_ingreso GetById(int id)
        {
            Doc_cabecera_ingreso entity = null;
            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_get_factura_compra_by_id @id", conn))
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
            catch (Exception ex) {
                throw ex;
            }

            return entity;
        }



        /// <summary>
        /// Carga una entidad de Doc_cabecera_ingreso a partir de un DataReader
        /// </summary>
        /// <param name="dr">IDataReader </param>
        /// <returns>Doc_cabecera_ingreso</returns>
        private Doc_cabecera_ingreso LoadEntity(IDataReader dr)
        {
            Doc_cabecera_ingreso entity = new Doc_cabecera_ingreso()
            {
                id = dr.GetByNameInt("id"),
                fk_id_tipo_doc = dr.GetByNameInt("fk_id_tipo_doc"),
                fk_id_proveedor = dr.GetByNameInt("fk_id_proveedor"),
                letra = dr.GetByNameString("letra"),
                sucursal = dr.GetByNameInt("sucursal"),
                numero = dr.GetByNameInt("numero"),
                fecha = dr.GetByNameDT("fecha"),
                fk_id_usuario = dr.GetByNameInt("fk_id_usuario"),
                factura = dr.GetByNameString("factura"),
                //nombre_usuario = dr.GetByNameString("usuario"),
                nombre_proveedor=dr.GetByNameString("proveedor"),
                tipo_documento = dr.GetByNameString("tipo_documento"),
                cancelada = dr.GetByNameBool("cancelada")
                
            };

            return entity;
        }
    }
}
