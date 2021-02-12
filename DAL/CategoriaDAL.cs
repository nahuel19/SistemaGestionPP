using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using Entities;
using System.Data.SqlClient;
using System.Configuration;
using Services;

namespace DAL
{
    /// <summary>
    /// Clase de acceso a datos para manejar la tabla Categoría
    /// </summary>
    public class CategoriaDAL : IDAL<Categoria>
    {
        /// <summary>
        /// Inserta registros en la tabla Categoría
        /// </summary>
        /// <param name="entity">Entidad Categoría</param>
        /// <returns>Entidad Categoría a ser insertada</returns>
        public Categoria Insert(Categoria entity)
        {
            try
            {
                string SqlString = "INSERT INTO [dbo].[Categoria] " +
                                       "([categoria]) " +
                                       "VALUES " +
                                       "(@categoria) ;SELECT SCOPE_IDENTITY()";


                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@categoria", entity.categoria);
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
        /// Actualiza registro de la tabla Categoría
        /// </summary>
        /// <param name="entity">Entidad Categoría a ser actualizada</param>
        public void Update(Categoria entity)
        {
            try
            {
                string SqlString = "UPDATE [dbo].[Categoria] " +
                                       "SET [categoria] = @categoria " +
                                       "WHERE id = @id ";


                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", entity.id);
                        cmd.Parameters.AddWithValue("@categoria", entity.categoria);
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
        /// Elimina registros de la tabla Categoría
        /// </summary>
        /// <param name="id">int para eliminar Categoria por id</param>
        public void Delete(int id)
        {
            try
            {
                string SqlString = "DELETE FROM [dbo].[Categoria] " +
                                      "WHERE id = @id";


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
        /// Selecciona todos los registros de la tabla Categoría
        /// </summary>
        /// <returns>Lista Entidad Categoria</returns>
        public List<Categoria> List()
        {
            
                string SqlString = "SELECT [id], " +
                                       "[categoria] " +
                                       "FROM [dbo].[Categoria] ";

                List<Categoria> result = new List<Categoria>();

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Categoria entity = LoadEntity(dr);
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
        /// Selecciona un registro de la tabla Categoría
        /// </summary>
        /// <param name="id">int para buscar Categoria por id</param>
        /// <returns>Entidad Categoría</returns>
        public Categoria GetById(int id)
        {
            string SqlString = "SELECT [id], " +
                               "[categoria] " +
                               "FROM [dbo].[Categoria] "+
                               "WHERE id = @id";

            Categoria entity = null;

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
        /// A partir de un DataReader, carga una Entidad Categoría
        /// </summary>
        /// <param name="dr">IDataReader con datos obtenidos de Categoria</param>
        /// <returns>Entidad Categoría</returns>
        private Categoria LoadEntity(IDataReader dr)
        {
            Categoria entity = new Categoria()
            {
                id = dr.GetByNameInt("id"),
                categoria = dr.GetByNameString("categoria")
            };

            return entity;
        }        

    }
}
