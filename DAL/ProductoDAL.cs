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
    /// Clase de acceso a datos para manejar la tabla Producto
    /// </summary>
    public class ProductoDAL : IDAL<Producto>
    {
        /// <summary>
        /// Inserta registros en la tabla Producto
        /// </summary>
        /// <param name="entity">Entidad Producto</param>
        /// <returns>Entidad Producto</returns>
        public Producto Insert(Producto entity)
        {

            string SqlString = "INSERT INTO [dbo].[Producto] "+
                               "([nombre] " +
                               ",[descripcion] " +
                               ",[fk_id_categoria] " +
                               ",[peso] " +
                               ",[alto] " +
                               ",[ancho] " +
                               ",[profundidad]) " +
                         "VALUES " +
                               "(@nombre " +
                               ",@descripcion " +
                               ",@fk_id_categoria " +
                               ",@peso " +
                               ",@alto " +
                               ",@ancho " +
                               ",@profundidad) ;SELECT SCOPE_IDENTITY()";


            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@nombre", entity.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", entity.descripcion);
                        cmd.Parameters.AddWithValue("@fk_id_categoria", entity.fk_id_categoria);
                        cmd.Parameters.AddWithValue("@peso", entity.peso);
                        cmd.Parameters.AddWithValue("@alto", entity.alto);
                        cmd.Parameters.AddWithValue("@ancho", entity.ancho);
                        cmd.Parameters.AddWithValue("@profundidad", entity.profundidad);

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
        /// Actualiza registros en la tabla Producto
        /// </summary>
        /// <param name="entity">Entidad Producto</param>
        public void Update(Producto entity)
        {
            string SqlString = "UPDATE[dbo].[Producto] " +
                               "SET [nombre] = @nombre " +
                                  ",[descripcion] = @descripcion " +
                                  ",[fk_id_categoria] = @fk_id_categoria " +
                                  ",[peso] = @peso " +
                                  ",[alto] = @alto " +
                                  ",[ancho] = @ancho " +
                                  ",[profundidad] = @profundidad " +
                              "WHERE id = @id ";


            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", entity.id);
                        cmd.Parameters.AddWithValue("@nombre", entity.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", entity.descripcion);
                        cmd.Parameters.AddWithValue("@fk_id_categoria", entity.fk_id_categoria);
                        cmd.Parameters.AddWithValue("@peso", entity.peso);
                        cmd.Parameters.AddWithValue("@alto", entity.alto);
                        cmd.Parameters.AddWithValue("@ancho", entity.ancho);
                        cmd.Parameters.AddWithValue("@profundidad", entity.profundidad);
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
        /// Elimina registros de la tabla Producto
        /// </summary>
        /// <param name="id">int del id a eliminar</param>
        public void Delete(int id)
        {
            string SqlString = "DELETE FROM [dbo].[Producto] " +
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
        /// Selecciona registros de la tabla Producto
        /// </summary>
        /// <returns>Lista Producto</returns>
        public List<Producto> List()
        {
            List<Producto> result = new List<Producto>();


            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_list_products", conn))
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Producto entity = LoadEntity(dr);
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

        public List<Producto> ListByCategoria(int idCat)
        {
            List<Producto> result = new List<Producto>();

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_get_productos_by_categoria @id", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", idCat);
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Producto entity = LoadEntity(dr);
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
        /// Selecciona un registro de la tabla Producto
        /// </summary>
        /// <param name="id">int del registro a seleccionar</param>
        /// <returns>Producto</returns>
        public Producto GetById(int id)
        {
            Producto entity = null;

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_get_preduct_by_id @id", conn))
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
        /// Carga una entidad de Producto a partir de un DataReader
        /// </summary>
        /// <param name="dr">IDataReader </param>
        /// <returns>Producto</returns>
        private Producto LoadEntity(IDataReader dr)
        {
            Producto entity = new Producto()
            {
                id = dr.GetByNameInt("id"),
                nombre = dr.GetByNameString("nombre"),
                descripcion = dr.GetByNameString("descripcion"),
                fk_id_categoria = dr.GetByNameInt("fk_id_categoria"),
                peso = dr.GetByNameDouble("peso"),
                alto = dr.GetByNameDouble("alto"),
                ancho = dr.GetByNameDouble("ancho"),
                profundidad = dr.GetByNameDouble("profundidad"),
                codigo = dr.GetByNameString("codigo"),
                categoria = dr.GetByNameString("categoria"),
                precio = dr.GetByNameDouble("precio"),
                cantidad = dr.GetByNameInt("cantidad")     

            };

            return entity;
        }
    }
}
