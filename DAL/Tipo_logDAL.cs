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
    /// Clase de acceso a datos para manejar la tabla Tipo_log
    /// </summary>
    public class Tipo_logDAL : IDAL<Tipo_log>
    {
        /// <summary>
        /// Inserta registros en la tabla Tipo_log
        /// </summary>
        /// <param name="entity">Entidad Tipo_log</param>
        /// <returns>Entidad Tipo_log</returns>
        public Tipo_log Insert(Tipo_log entity)
        {

            string SqlString = "INSERT INTO [dbo].[Tipo_log] " +
                                           "([tipo_log]) " +
                                     "VALUES " +
                                           "(@tipo_log) ";

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@tipo_log", entity.tipo_log);
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
        /// Actualiza registros en la tabla Tipo_log
        /// </summary>
        /// <param name="entity">Entidad Tipo_log</param>
        public void Update(Tipo_log entity)
        {
            string SqlString = "UPDATE [dbo].[Tipo_log] " +
                                  "SET [tipo_log] = @tipo_log " +
                                "WHERE id = @id ";

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", entity.id);
                        cmd.Parameters.AddWithValue("@tipo_log", entity.tipo_log);

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
        /// Elimina registros de la tabla Tipo_log
        /// </summary>
        /// <param name="id">int del id a eliminar</param>
        public void Delete(int id)
        {
            string SqlString = "DELETE FROM [dbo].[Tipo_log] " +
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
        /// Selecciona registros de la tabla Tipo_log
        /// </summary>
        /// <returns>Lista Tipo_log</returns>
        public List<Tipo_log> List()
        {
            string SqlString = "SELECT [id] " +
                                     ",[tipo_log] " +
                                 "FROM [dbo].[Tipo_log] ";

            List<Tipo_log> result = new List<Tipo_log>();

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
                                Tipo_log entity = LoadEntity(dr);
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
        /// Selecciona un registro de la tabla Tipo_log
        /// </summary>
        /// <param name="id">int del registro a seleccionar</param>
        /// <returns>Tipo_log</returns>
        public Tipo_log GetById(int id)
        {
            string SqlString = "SELECT [id] " +
                                     ",[tipo_log] " +
                                 "FROM [dbo].[Tipo_log] " +
                                "WHERE id = @id";

            Tipo_log entity = null;
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
        /// Carga una entidad de Tipo_log a partir de un DataReader
        /// </summary>
        /// <param name="dr">IDataReader </param>
        /// <returns>Tipo_log</returns>
        private Tipo_log LoadEntity(IDataReader dr)
        {
            Tipo_log entity = new Tipo_log()
            {
                id = dr.GetByNameInt("id"),
                tipo_log = dr.GetByNameString("tipo_log")
            };

            return entity;
        }
    }
}
