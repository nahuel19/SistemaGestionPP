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
    /// Clase de acceso a datos para manejar la tabla Movimiento_prodcuto
    /// </summary>
    public class Movimiento_productoDAL : IDAL<Movimiento_producto>
    {
        /// <summary>
        /// Inserta registros en la tabla Movimiento_producto
        /// </summary>
        /// <param name="entity">Entidad Movimiento_producto</param>
        /// <returns>Entidad Movimiento_producto</returns>
        public Movimiento_producto Insert(Movimiento_producto entity)
        {

            string SqlString = "INSERT INTO [dbo].[Movimiento_producto] " +
                               "([fk_id_producto] " +
                               ",[antes] " +
                               ",[movimiento] " +
                               ",[despues] " +
                               ",[fk_id_tipo_mov_prod] " +              
                               ",[extra]) " +
                         "VALUES " +
                               "(@fk_id_producto " +
                               ",@antes " +
                               ",@movimiento " +
                               ",@despues " +
                               ",@fk_id_tipo_mov_prod " +                      
                               ",@extra) ;SELECT SCOPE_IDENTITY() ";

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@fk_id_producto", entity.fk_id_producto);
                        cmd.Parameters.AddWithValue("@antes", entity.antes);
                        cmd.Parameters.AddWithValue("@movimiento", entity.movimiento);
                        cmd.Parameters.AddWithValue("@despues", entity.despues);
                        cmd.Parameters.AddWithValue("@fk_id_tipo_mov_prod", entity.fk_id_tipo_mov_prod);               
                        cmd.Parameters.AddWithValue("@extra", entity.extra);
                        conn.Open();

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
        /// Actualiza registros en la tabla Movimiento_producto
        /// </summary>
        /// <param name="entity">Entidad Movimiento_producto</param>
        public void Update(Movimiento_producto entity)
        {
            string SqlString = "UPDATE [dbo].[Movimiento_producto] " +
                               "SET [fk_id_producto] = @fk_id_producto " +
                                  ",[antes] = @antes " +
                                  ",[movimiento] = @movimiento " +
                                  ",[despues] = @despues " +
                                  ",[fk_id_tipo_mov_prod] = @fk_id_tipo_mov_prod " +                          
                                  ",[extra] = @extra " +
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
                        cmd.Parameters.AddWithValue("@antes", entity.antes);
                        cmd.Parameters.AddWithValue("@movimiento", entity.movimiento);
                        cmd.Parameters.AddWithValue("@despues", entity.despues);
                        cmd.Parameters.AddWithValue("@fk_id_tipo_mov_prod", entity.fk_id_tipo_mov_prod);
                        cmd.Parameters.AddWithValue("@extra", entity.extra);

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
        /// Elimina registros de la tabla Movimiento_producto
        /// </summary>
        /// <param name="id">int del id a eliminar</param>
        public void Delete(int id)
        {
            string SqlString = "DELETE FROM [dbo].[Movimiento_producto] " +
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
        /// Selecciona registros de la tabla Movimiento_producto
        /// </summary>
        /// <returns>Lista Movimiento_producto</returns>
        public List<Movimiento_producto> List()
        {
            string SqlString = "SELECT [id] " +
                              ",[fk_id_producto] " +
                              ",[antes] " +
                              ",[movimiento] " +
                              ",[despues] " +
                              ",[fk_id_tipo_mov_prod] " +
                              ",[fecha] " +
                              ",[extra] " +
                          "FROM [dbo].[Movimiento_producto] " ;

            List<Movimiento_producto> result = new List<Movimiento_producto>();

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
                                Movimiento_producto entity = LoadEntity(dr);
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
        /// Selecciona un registro de la tabla Movimiento_producto
        /// </summary>
        /// <param name="id">int del registro a seleccionar</param>
        /// <returns>Movimiento_producto</returns>
        public Movimiento_producto GetById(int id)
        {
            string SqlString = "SELECT [id] " +
                              ",[fk_id_producto] " +
                              ",[antes] " +
                              ",[movimiento] " +
                              ",[despues] " +
                              ",[fk_id_tipo_mov_prod] " +
                              ",[fecha] " +
                              ",[extra] " +
                          "FROM [dbo].[Movimiento_producto] " +
                               "WHERE id = @id";

            Movimiento_producto entity = null;
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
        /// Carga una entidad de Movimiento_producto a partir de un DataReader
        /// </summary>
        /// <param name="dr">IDataReader </param>
        /// <returns>Movimiento_producto</returns>
        private Movimiento_producto LoadEntity(IDataReader dr)
        {
            Movimiento_producto entity = new Movimiento_producto()
            {
                id = dr.GetByNameInt("id"),
                fk_id_producto = dr.GetByNameInt("fk_id_producto"),
                antes = dr.GetByNameDouble("antes"),
                movimiento = dr.GetByNameDouble("movimiento"),
                despues = dr.GetByNameDouble("despues"),
                fk_id_tipo_mov_prod = dr.GetByNameInt("fk_id_tipo_mov_prod"),
                fecha = dr.GetByNameDT("fecha"),
                extra = dr.GetByNameString("extra")
            };

            return entity;
        }
    }
}
