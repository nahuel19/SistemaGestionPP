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
    /// Clase de acceso a datos para manejar la tabla Precio
    /// </summary>
    public class PrecioDAL : IDAL<Precio>
    {
        /// <summary>
        /// Inserta registros en la tabla Precio
        /// </summary>
        /// <param name="entity">Entidad Precio</param>
        /// <returns>Entidad Precio</returns>
        public Precio Insert(Precio entity)
        {
            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_actualizar_precio_by_id_prod @id_prod, @costo, @precio ;SELECT SCOPE_IDENTITY()", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id_prod", entity.fk_id_producto);
                        cmd.Parameters.AddWithValue("@costo", entity.costo);
                        cmd.Parameters.AddWithValue("@precio", entity.precio);
                        conn.Open();
                        entity.id= Convert.ToInt32(cmd.ExecuteScalar());
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
        /// Actualiza registros en la tabla Precio
        /// </summary>
        /// <param name="entity">Entidad Precio</param>
        public void Update(Precio entity)
        {
            string SqlString = "UPDATE [dbo].[Precio] "+
                               "SET [fk_id_producto] = @fk_id_producto " +
                                  ",[desde] = @desde " +
                                  ",[hasta] = @hasta " +
                                  ",[costo] = @costo " +
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
                        cmd.Parameters.AddWithValue("@desde", entity.desde);
                        cmd.Parameters.AddWithValue("@hasta", entity.hasta);
                        cmd.Parameters.AddWithValue("@costo", entity.costo);
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
        /// Elimina registros de la tabla Precio
        /// </summary>
        /// <param name="id">int del id a eliminar</param>
        public void Delete(int id)
        {
            string SqlString = "DELETE FROM [dbo].[Precio] " +
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
        /// Selecciona registros de la tabla Precio
        /// </summary>
        /// <returns>Lista Precio</returns>
        public List<Precio> List()
        {
            string SqlString = "SELECT [id] " +
                              ",[fk_id_producto] " +
                              ",[desde] " +
                              ",[hasta] " +
                              ",[costo] " +
                              ",[precio] " +
                          "FROM [dbo].[Precio] ";

            List <Precio> result = new List<Precio>();

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
                                Precio entity = LoadEntity(dr);
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
        /// Selecciona un registro de la tabla Precio
        /// </summary>
        /// <param name="id_prod">int del registro a seleccionar</param>
        /// <returns>Precio</returns>
        public Precio GetById(int id_prod)
        {
            //string SqlString = "SELECT [id] "+
            //                  ",[fk_id_producto] "+
            //                  ",[desde] "+
            //                  ",[hasta] "+
            //                  ",[costo] "+
            //                  ",[precio] "+
            //              "FROM [dbo].[Precio] "+
            //              "WHERE id = @id";

            Precio entity = null;
            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_get_precio_by_id_prod @id_prod", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id_prod", id_prod);
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
        /// Carga una entidad de Precio a partir de un DataReader
        /// </summary>
        /// <param name="dr">IDataReader </param>
        /// <returns>Precio</returns>
        private Precio LoadEntity(IDataReader dr)
        {
            Precio entity = new Precio()
            {
                id = dr.GetByNameInt("id"),
                fk_id_producto = dr.GetByNameInt("fk_id_producto"),
                desde = dr.GetByNameDT("desde"),
                hasta = dr.GetByNameDT("hasta"),
                costo = dr.GetByNameDouble("costo"),
                precio = dr.GetByNameDouble("precio")
            };

            return entity;
        }

    }
}
