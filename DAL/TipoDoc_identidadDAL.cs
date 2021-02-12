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
    /// Clase de acceso a datos para manejar la tabla TipoDoc_identidad
    /// </summary>
    public class TipoDoc_identidadDAL : IDAL<TipoDoc_identidad>
    {
        /// <summary>
        /// Inserta registros en la tabla TipoDoc_identidad
        /// </summary>
        /// <param name="entity">Entidad TipoDoc_identidad</param>
        /// <returns>Entidad TipoDoc_identidad</returns>
        public TipoDoc_identidad Insert(TipoDoc_identidad entity)
        {

            string SqlString = "INSERT INTO [dbo].[TipoDoc_identidad] " +
                                           "([doc_identidad]) " +
                                     "VALUES " +
                                           "(@doc_identidad) ;SELECT SCOPE_IDENTITY() ";

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@doc_identidad", entity.doc_identidad);
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
        /// Actualiza registros en la tabla TipoDoc_identidad
        /// </summary>
        /// <param name="entity">Entidad TipoDoc_identidad</param>
        public void Update(TipoDoc_identidad entity)
        {
            string SqlString = "UPDATE [dbo].[TipoDoc_identidad] " +
                                  "SET [doc_identidad] = @doc_identidad " +
                                "WHERE id = @id ";

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", entity.id);
                        cmd.Parameters.AddWithValue("@doc_identidad", entity.doc_identidad);

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
        /// Elimina registros de la tabla TipoDoc_identidad
        /// </summary>
        /// <param name="id">int del id a eliminar</param>
        public void Delete(int id)
        {
            string SqlString = "DELETE FROM [dbo].[TipoDoc_identidad] " +
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
        /// Selecciona registros de la tabla TipoDoc_identidad
        /// </summary>
        /// <returns>Lista TipoDoc_identidad</returns>
        public List<TipoDoc_identidad> List()
        {
            string SqlString = "SELECT [id] " +
                                     ",[doc_identidad] " +
                                 "FROM [dbo].[TipoDoc_identidad] ";

            List<TipoDoc_identidad> result = new List<TipoDoc_identidad>();

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
                                TipoDoc_identidad entity = LoadEntity(dr);
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
        /// Selecciona un registro de la tabla TipoDoc_identidad
        /// </summary>
        /// <param name="id">int del registro a seleccionar</param>
        /// <returns>TipoDoc_identidad</returns>
        public TipoDoc_identidad GetById(int id)
        {
            string SqlString = "SELECT [id] " +
                                     ",[doc_identidad] " +
                                 "FROM [dbo].[TipoDoc_identidad] " +
                                "WHERE id = @id";

            TipoDoc_identidad entity = null;
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
        /// Carga una entidad de TipoDoc_identidad a partir de un DataReader
        /// </summary>
        /// <param name="dr">IDataReader </param>
        /// <returns>TipoDoc_identidad</returns>
        private TipoDoc_identidad LoadEntity(IDataReader dr)
        {
            TipoDoc_identidad entity = new TipoDoc_identidad()
            {
                id = dr.GetByNameInt("id"),
                doc_identidad = dr.GetByNameString("doc_identidad")
            };

            return entity;
        }
    }
}
