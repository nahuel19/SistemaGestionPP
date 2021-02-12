using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
            #region anterior
            //string SqlString = "INSERT INTO [dbo].[Doc_cabecera_ingreso] " +
            //                   "([fk_id_tipo_doc] " +
            //                   ",[fk_id_proveedor] " +
            //                   ",[letra] " +
            //                   ",[sucursal] " +
            //                   ",[numero] " +
            //                   ",[fecha] " +
            //                    ",[fk_id_usuario]) " +
            //             "VALUES " +
            //                   "(@fk_id_tipo_doc " +
            //                   ", @fk_id_proveedor " +
            //                   ", @letra " +
            //                   ", @sucursal " +
            //                   ", @numero " +
            //                   ", @fecha" +
            //                   ", @fk_id_usuario) ;SELECT SCOPE_IDENTITY()";

            //try
            //{
            //    using (SqlConnection conn = ConnectionBD.Instance().Conect())
            //    {
            //        using (SqlCommand cmd = new SqlCommand(SqlString, conn))
            //        {
            //            cmd.CommandType = CommandType.Text;
            //            cmd.Parameters.AddWithValue("@fk_id_tipo_doc", entity.fk_id_tipo_doc);
            //            cmd.Parameters.AddWithValue("@fk_id_proveedor", entity.fk_id_proveedor);
            //            cmd.Parameters.AddWithValue("@letra", entity.letra);
            //            cmd.Parameters.AddWithValue("@sucursal", entity.sucursal);
            //            cmd.Parameters.AddWithValue("@numero", entity.numero);
            //            cmd.Parameters.AddWithValue("@fecha", entity.fecha);
            //            conn.Open();

            //            //cmd.ExecuteNonQuery();
            //            entity.id = Convert.ToInt32(cmd.ExecuteScalar());
            //        }

            //    }

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            //return entity;
            #endregion

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
                               ", @fecha" +
                               ", @fk_id_usuario) ;SELECT SCOPE_IDENTITY()";

            string SqlStringDetalle = "INSERT INTO [dbo].[Doc_detalle_ingreso] " +
                              "([fk_id_doc_cabecera_ingreso] " +
                              ",[fk_id_producto] " +
                              ",[cantidad] " +
                              ",[costo]) " +
                        "VALUES " +
                              "(@fk_id_doc_cabecera_ingreso " +
                              ",@fk_id_producto " +
                              ",@cantidad " +
                              ",@costo) ;SELECT SCOPE_IDENTITY()";

            using (SqlConnection conn = ConnectionBD.Instance().Conect())
            {
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
                        conn.Open();
                                                
                        entity.id = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    foreach(var d in entity.listDetalle)
                    {
                        using (SqlCommand cmd = new SqlCommand(SqlStringDetalle, conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@fk_id_doc_cabecera_ingreso", d.fk_id_doc_cabecera_ingreso);
                            cmd.Parameters.AddWithValue("@fk_id_producto", d.fk_id_producto);
                            cmd.Parameters.AddWithValue("@cantidad", d.cantidad);
                            cmd.Parameters.AddWithValue("@costo", d.costo);
                            conn.Open();

                            d.id = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }

                    transaction.Commit();

                }
                catch (SqlException sqlError)
                {
                    transaction.Rollback();
                    throw sqlError;
                }               

            }

            return entity;
        }

        //------------
        //        

        //       
        //transaction = sqlConnection.BeginTransaction();    
        //try     
        //{    
        //   new SqlCommand("INSERT Qwery1", sqlConnection, transaction)
        //      .ExecuteNonQuery();
        //        new SqlCommand("INSERT Qwery2 ", sqlConnection, transaction)
        //      .ExecuteNonQuery();
        //        new SqlCommand("INSERT Qwery3 ", sqlConnection, transaction)
        //      .ExecuteNonQuery();
        //        transaction.Commit();    
        //}     
        //catch (SqlException sqlError)     
        //{    
        //   transaction.Rollback();    
        //}






        /// <summary>
        /// Actualiza registros en la tabla Doc_cabecera_ingreso
        /// </summary>
        /// <param name="entity">Entidad Doc_cabecera_ingreso</param>
        public void Update(Doc_cabecera_ingreso entity)
        {
            string SqlString = "UPDATE [dbo].[Doc_cabecera_ingreso] " +
                               "SET [fk_id_tipo_doc] = @fk_id_tipo_doc " +
                                  ",[fk_id_proveedor] = @fk_id_proveedor " +
                                  ",[letra] = @letra " +
                                  ",[sucursal] = @sucursal " +
                                  ",[numero] = @numero " +
                                  ",[fecha] = @fecha " +
                              "WHERE id = @id ";

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", entity.id);
                        cmd.Parameters.AddWithValue("@fk_id_tipo_doc", entity.fk_id_tipo_doc);
                        cmd.Parameters.AddWithValue("@fk_id_proveedor", entity.fk_id_proveedor);
                        cmd.Parameters.AddWithValue("@letra", entity.letra);
                        cmd.Parameters.AddWithValue("@sucursal", entity.sucursal);
                        cmd.Parameters.AddWithValue("@numero", entity.numero);
                        cmd.Parameters.AddWithValue("@fecha", entity.fecha);

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
            //string SqlString = "SELECT [id] " +
            //                  ",[fk_id_tipo_doc] " +
            //                  ",[fk_id_proveedor] " +
            //                  ",[letra] " +
            //                  ",[sucursal] " +
            //                  ",[numero] " +
            //                  ",[fecha] " +
            //                  "FROM[dbo].[Doc_cabecera_ingreso]";

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
            string SqlString = "SELECT [id] " +
                              ",[fk_id_tipo_doc] " +
                              ",[fk_id_proveedor] " +
                              ",[letra] " +
                              ",[sucursal] " +
                              ",[numero] " +
                              ",[fecha] " +
                              "FROM[dbo].[Doc_cabecera_ingreso] " +
                              "WHERE id = @id";

            Doc_cabecera_ingreso entity = null;
            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
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
                nombre_usuario = dr.GetByNameString("usuario"),
                nombre_proveedor=dr.GetByNameString("proveedor"),
                tipo_documento = dr.GetByNameString("tipo_documento")
                
            };

            return entity;
        }
    }
}
