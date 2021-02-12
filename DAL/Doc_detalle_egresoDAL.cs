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
    /// Clase de acceso a datos para manejar la tabla Doc_detalle_egreso
    /// </summary>
    public class Doc_detalle_egresoDAL : IDAL<Doc_detalle_egreso>
    {
        /// <summary>
        /// Inserta registros en la tabla Doc_detalle_egreso
        /// </summary>
        /// <param name="entity">Entidad Doc_detalle_egreso</param>
        /// <returns>Entidad Doc_detalle_egreso</returns>
        public Doc_detalle_egreso Insert(Doc_detalle_egreso entity)
        {

            string SqlString = "INSERT INTO [dbo].[Doc_detalle_egreso] " +
                               "([fk_id_doc_cabecera_egreso] " +
                               ",[fk_id_producto] " +
                               ",[cantidad] " +
                               ",[precio]) " +
                         "VALUES " +
                               "(@fk_id_doc_cabecera_egreso " +
                               ",@fk_id_producto " +
                               ",@cantidad " +
                               ",@precio) ;SELECT SCOPE_IDENTITY()";

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@fk_id_doc_cabecera_egreso", entity.fk_id_doc_cabecera_egreso);
                        cmd.Parameters.AddWithValue("@fk_id_producto", entity.fk_id_producto);
                        cmd.Parameters.AddWithValue("@cantidad", entity.cantidad);
                        cmd.Parameters.AddWithValue("@precio", entity.precio);
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
        /// Actualiza registros en la tabla Doc_detalle_egreso
        /// </summary>
        /// <param name="entity">Entidad Doc_detalle_egreso</param>
        public void Update(Doc_detalle_egreso entity)
        {
            string SqlString = "UPDATE [dbo].[Doc_detalle_egreso] "+
                               "SET [fk_id_producto] = @fk_id_producto " +
                                  ",[cantidad] = @cantidad " +
                                  ",[precio] = @precio " +
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
                        cmd.Parameters.AddWithValue("@precio", entity.precio);

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
        /// Elimina registros de la tabla Doc_detalle_egreso
        /// </summary>
        /// <param name="id">int del id a eliminar</param>
        public void Delete(int id)
        {
            string SqlString = "DELETE FROM [dbo].[Doc_detalle_egreso] " +
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
        /// Selecciona registros de la tabla Doc_detalle_egreso
        /// </summary>
        /// <returns>Lista Doc_detalle_egreso</returns>
        public List<Doc_detalle_egreso> List()
        {
            string SqlString = "SELECT [id] " +
                              ",[fk_id_doc_cabecera_egreso] " +
                              ",[fk_id_producto] " +
                              ",[cantidad] " +
                              ",[precio] " +
                              "FROM[dbo].[Doc_detalle_egreso] ";

            List<Doc_detalle_egreso> result = new List<Doc_detalle_egreso>();

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
                                Doc_detalle_egreso entity = LoadEntity(dr);
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
        /// Selecciona un registro de la tabla Doc_detalle_egreso
        /// </summary>
        /// <param name="id">int del registro a seleccionar</param>
        /// <returns>Doc_detalle_egreso</returns>
        public Doc_detalle_egreso GetById(int id)
        {
            string SqlString = "SELECT [id] " +
                              ",[fk_id_doc_cabecera_egreso] " +
                              ",[fk_id_producto] " +
                              ",[cantidad] " +
                              ",[precio] " +
                              "FROM[dbo].[Doc_detalle_egreso] "+
                              "WHERE id = @id";

            Doc_detalle_egreso entity = null;
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
        /// Carga una entidad de Doc_detalle_egreso a partir de un DataReader
        /// </summary>
        /// <param name="dr">IDataReader </param>
        /// <returns>Doc_detalle_egreso</returns>
        private Doc_detalle_egreso LoadEntity(IDataReader dr)
        {
            Doc_detalle_egreso entity = new Doc_detalle_egreso()
            {
                id = dr.GetByNameInt("id"),
                fk_id_doc_cabecera_egreso = dr.GetByNameInt("fk_id_doc_cabecera_egreso"),
                fk_id_producto = dr.GetByNameInt("fk_id_producto"),
                cantidad = dr.GetByNameInt("cantidad"),
                precio = dr.GetByNameDouble("precio")
            };

            return entity;
        }
    }
}
