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
    /// Clase de acceso a datos para manejar la tabla Tipo_movimiento_prod
    /// </summary>
    public class Tipo_movimiento_prodDAL : IDAL<Tipo_movimiento_prod>
    {
        /// <summary>
        /// Inserta registros en la tabla Tipo_movimiento_prod
        /// </summary>
        /// <param name="entity">Entidad Tipo_movimiento_prod</param>
        /// <returns>Entidad Tipo_movimiento_prod</returns>
        public Tipo_movimiento_prod Insert(Tipo_movimiento_prod entity)
        {

            string SqlString = "INSERT INTO [dbo].[Tipo_movimiento_prod] " +
                                           "([tipo_mov_prod]) " +
                                     "VALUES " +
                                           "(@tipo_mov_prod) ;SELECT SCOPE_IDENTITY()";

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@tipo_mov_prod", entity.tipo_mov_prod);
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
        /// Actualiza registros en la tabla Tipo_movimiento_prod
        /// </summary>
        /// <param name="entity">Entidad Tipo_movimiento_prod</param>
        public void Update(Tipo_movimiento_prod entity)
        {
            string SqlString = "UPDATE [dbo].[Tipo_movimiento_prod] " +
                                  "SET [tipo_mov_prod] = @tipo_mov_prod " +
                                "WHERE id = @id ";

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", entity.id);
                        cmd.Parameters.AddWithValue("@tipo_mov_prod", entity.tipo_mov_prod);
             
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
        /// Elimina registros de la tabla Tipo_movimiento_prod
        /// </summary>
        /// <param name="id">int del id a eliminar</param>
        public void Delete(int id)
        {
            string SqlString = "DELETE FROM [dbo].[Tipo_movimiento_prod] " +
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
        /// Selecciona registros de la tabla Tipo_movimiento_prod
        /// </summary>
        /// <returns>Lista Tipo_movimiento_prod</returns>
        public List<Tipo_movimiento_prod> List()
        {
            string SqlString = "SELECT [id] " +
                                     ",[tipo_mov_prod] " +
                                 "FROM [dbo].[Tipo_movimiento_prod] ";

            List<Tipo_movimiento_prod> result = new List<Tipo_movimiento_prod>();

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
                                Tipo_movimiento_prod entity = LoadEntity(dr);
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
        /// Selecciona un registro de la tabla Tipo_movimiento_prod
        /// </summary>
        /// <param name="id">int del registro a seleccionar</param>
        /// <returns>Tipo_movimiento_prod</returns>
        public Tipo_movimiento_prod GetById(int id)
        {
            string SqlString = "SELECT [id] "+
                                     ",[tipo_mov_prod] "+
                                 "FROM [dbo].[Tipo_movimiento_prod] " +
                                "WHERE id = @id";

            Tipo_movimiento_prod entity = null;
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
        /// Carga una entidad de Tipo_movimiento_prod a partir de un DataReader
        /// </summary>
        /// <param name="dr">IDataReader </param>
        /// <returns>Tipo_movimiento_prod</returns>
        private Tipo_movimiento_prod LoadEntity(IDataReader dr)
        {
            Tipo_movimiento_prod entity = new Tipo_movimiento_prod()
            {
                id = dr.GetByNameInt("id"),
                tipo_mov_prod = dr.GetByNameString("tipo_mov_prod")                
            };

            return entity;
        }
    }
}
