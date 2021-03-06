﻿using Entities;
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
    /// Clase de acceso a datos para manejar la tabla Stock
    /// </summary>
    public class StockDAL : IDAL<Stock>
    {
        /// <summary>
        /// Inserta registros en la tabla Stock
        /// </summary>
        /// <param name="entity">Entidad Stock</param>
        /// <returns>Entidad Stock</returns>
        public Stock Insert(Stock entity)
        {
            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_create_stock_0 @fk_id_producto", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@fk_id_producto", entity.fk_id_producto);                        
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
        /// Actualiza registros en la tabla Stock
        /// </summary>
        /// <param name="entity">Entidad Stock</param>
        public void Update(Stock entity)
        {
            string SqlString = "UPDATE [dbo].[Stock] " +
                               "SET [cantidad] = @cantidad " +
                              "WHERE [fk_id_producto] = @fk_id_producto ";

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;                        
                        cmd.Parameters.AddWithValue("@fk_id_producto", entity.fk_id_producto);
                        cmd.Parameters.AddWithValue("@cantidad", entity.cantidad);

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
        /// Elimina registros de la tabla Stock
        /// </summary>
        /// <param name="id">int del id a eliminar</param>
        public void Delete(int id)
        {
            string SqlString = "DELETE FROM [dbo].[Stock] " +
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
        /// Selecciona registros de la tabla Stock
        /// </summary>
        /// <returns>Lista Stock</returns>
        public List<Stock> List()
        {
            string SqlString = "SELECT [id] " +
                                     ",[fk_id_producto] " +
                                     ",[cantidad] " +
                                 "FROM [dbo].[Stock] ";

            List <Stock> result = new List<Stock>();


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
                                Stock entity = LoadEntity(dr);
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
        /// Selecciona un registro de la tabla Stock
        /// </summary>
        /// <param name="id">int del registro a seleccionar</param>
        /// <returns>Stock</returns>
        public Stock GetById(int id)
        {
            string SqlString = "SELECT [id] " +
                                     ",[fk_id_producto] " +
                                     ",[cantidad] " +
                                 "FROM [dbo].[Stock] " +
                                "WHERE id = @id";

            Stock entity = null;

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
        /// Selecciona un registro de la tabla Stock por el id de producto
        /// </summary>
        /// <param name="id_prod">int del registro a seleccionar</param>
        /// <returns>Stock</returns>
        public Stock GetByIdProducto(int id_prod)
        {
            string SqlString = "SELECT [id] " +
                                     ",[fk_id_producto] " +
                                     ",[cantidad] " +
                                 "FROM [dbo].[Stock] " +
                                "WHERE fk_id_producto = @id_prod";

            Stock entity = null;

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
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
        /// Selecciona un registro de la tabla Stock buscandolo por id de producto
        /// </summary>
        /// <param name="id">int del registro a seleccionar</param>
        /// <returns>Stock</returns>
        public Stock GetByIdProd(int id)
        {
            string SqlString = "SELECT [id] " +
                                     ",[fk_id_producto] " +
                                     ",[cantidad] " +
                                 "FROM [dbo].[Stock] " +
                                "WHERE fk_id_producto = @id";

            Stock entity = null;

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
        /// Carga una entidad de Stock a partir de un DataReader
        /// </summary>
        /// <param name="dr">IDataReader </param>
        /// <returns>Stock</returns>
        private Stock LoadEntity(IDataReader dr)
        {
            Stock entity = new Stock()
            {
                id = dr.GetByNameInt("id"),
                fk_id_producto = dr.GetByNameInt("fk_id_producto"),
                cantidad = dr.GetByNameInt("cantidad")
            };

            return entity;
        }
    }
}
