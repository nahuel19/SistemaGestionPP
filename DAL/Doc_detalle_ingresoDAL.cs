using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Clase de acceso a datos para manejar la tabla Doc_detalle_ingreso
    /// </summary>
    public class Doc_detalle_ingresoDAL : IDAL<Doc_detalle_ingreso>
    {
        /// <summary>
        /// Inserta registros en la tabla Doc_detalle_ingreso
        /// </summary>
        /// <param name="entity">Entidad Doc_detalle_ingreso</param>
        /// <returns>Entidad Doc_detalle_ingreso</returns>
        public Doc_detalle_ingreso Insert(Doc_detalle_ingreso entity)
        {

            string SqlString = "INSERT INTO [dbo].[Doc_detalle_ingreso] " +
                               "([fk_id_doc_cabecera_ingreso] " +
                               ",[fk_id_producto] " +
                               ",[cantidad] " +
                               ",[costo]) " +
                         "VALUES " +
                               "(@fk_id_doc_cabecera_ingreso " +
                               ",@fk_id_producto " +
                               ",@cantidad " +
                               ",@costo) ;SELECT SCOPE_IDENTITY()";

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@fk_id_doc_cabecera_ingreso", entity.fk_id_doc_cabecera_ingreso);
                        cmd.Parameters.AddWithValue("@fk_id_producto", entity.fk_id_producto);
                        cmd.Parameters.AddWithValue("@cantidad", entity.cantidad);
                        cmd.Parameters.AddWithValue("@costo", entity.costo);
                        conn.Open();

                        //cmd.ExecuteNonQuery();
                        entity.id = Convert.ToInt32(cmd.ExecuteScalar());
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
        /// Actualiza registros en la tabla Doc_detalle_ingreso
        /// </summary>
        /// <param name="entity">Entidad Doc_detalle_ingreso</param>
        public void Update(Doc_detalle_ingreso entity)
        {
            string SqlString = "UPDATE [dbo].[Doc_detalle_ingreso] " +
                               "SET [fk_id_producto] = @fk_id_producto " +
                                  ",[cantidad] = @cantidad " +
                                  ",[costo] = @costo " +
                              "WHERE id = @id ";

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", entity.id);
                        cmd.Parameters.AddWithValue("@fk_id_producto", entity.fk_id_producto);
                        cmd.Parameters.AddWithValue("@cantidad", entity.cantidad);
                        cmd.Parameters.AddWithValue("@costo", entity.costo);

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
        /// Actualiza la columna fk_id_precio en la tabla Doc_detalle_ingreso
        /// </summary>
        /// <param name="entity">Entidad Doc_detalle_ingreso</param>
        public void UpdateFKprecio(Doc_detalle_ingreso entity)
        {
            string SqlString = "UPDATE [dbo].[Doc_detalle_ingreso] " +
                               "SET [fk_id_precio] = @fk_id_precio " +
                              "WHERE id = @id ";

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", entity.id);
                        cmd.Parameters.AddWithValue("@fk_id_precio", entity.fk_id_precio);

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
        /// Elimina registros de la tabla Doc_detalle_ingreso
        /// </summary>
        /// <param name="id">int del id a eliminar</param>
        public void Delete(int id)
        {
            string SqlString = "DELETE FROM [dbo].[Doc_detalle_ingreso] " +
                               "WHERE id = @id";

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
        /// Selecciona registros de la tabla Doc_detalle_ingreso
        /// </summary>
        /// <returns>Lista Doc_detalle_ingreso</returns>
        public List<Doc_detalle_ingreso> List()
        {
            string SqlString = "SELECT [id] " +
                              ",[fk_id_doc_cabecera_ingreso] " +
                              ",[fk_id_producto] " +
                              ",[cantidad] " +
                              ",[costo] " +
                              "FROM[dbo].[Doc_detalle_ingreso] ";

            List<Doc_detalle_ingreso> result = new List<Doc_detalle_ingreso>();

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Doc_detalle_ingreso entity = LoadEntity(dr);
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
        /// Selecciona un registro de la tabla Doc_detalle_ingreso
        /// </summary>
        /// <param name="id">int del registro a seleccionar</param>
        /// <returns>Doc_detalle_ingreso</returns>
        public Doc_detalle_ingreso GetById(int id)
        {
            string SqlString = "SELECT [id] " +
                              ",[fk_id_doc_cabecera_ingreso] " +
                              ",[fk_id_producto] " +
                              ",[cantidad] " +
                              ",[costo] " +
                              "FROM[dbo].[Doc_detalle_ingreso] " +
                              "WHERE id = @id";

            Doc_detalle_ingreso entity = null;
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
        /// Selecciona los detalles de ingreso de una cabecera en específico
        /// </summary>
        /// <param name="id_cab">int</param>
        /// <returns>List Doc_detalle_ingreso</returns>
        public List<Doc_detalle_ingreso> ListDetallesByCabecera(int id_cab)
        {
            List<Doc_detalle_ingreso> result = new List<Doc_detalle_ingreso>();

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_get_detalles_compras_by_id_cabecera @id_cab", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id_cab", id_cab);
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Doc_detalle_ingreso entity = LoadEntity(dr);
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
        /// Carga una entidad de Doc_detalle_ingreso a partir de un DataReader
        /// </summary>
        /// <param name="dr">IDataReader </param>
        /// <returns>Doc_detalle_ingreso</returns>
        private Doc_detalle_ingreso LoadEntity(IDataReader dr)
        {
            Doc_detalle_ingreso entity = new Doc_detalle_ingreso()
            {
                id = dr.GetByNameInt("id"),
                fk_id_doc_cabecera_ingreso = dr.GetByNameInt("fk_id_doc_cabecera_ingreso"),
                fk_id_producto = dr.GetByNameInt("fk_id_producto"),
                cantidad = dr.GetByNameInt("cantidad"),
                costo = dr.GetByNameDouble("costo"),
                fk_id_precio = dr.GetByNameInt("fk_id_precio"),
                precio = dr.GetByNameDouble("precio_venta"),
                nombre_producto = dr.GetByNameString("nombre_producto")
            };

            return entity;
        }
    }
}
