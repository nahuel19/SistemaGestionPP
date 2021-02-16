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
    /// Clase de acceso a datos para manejar la tabla Tipo_documento
    /// </summary>
    public class Tipo_documentoDAL : IDAL<Tipo_documento>
    {
        /// <summary>
        /// Inserta registros en la tabla Tipo_documento
        /// </summary>
        /// <param name="entity">Entidad Tipo_documento</param>
        /// <returns>Entidad Tipo_documento</returns>
        public Tipo_documento Insert(Tipo_documento entity)
        {

            string SqlString = "INSERT INTO [dbo].[Tipo_documento] " +
                                           "([tipo_documento] " +
                                           ",[letra] " +
                                           ",[sucursal] " +
                                           ",[numero]) "+
                                     "VALUES "+
                                           "(@tipo_documento, " +
                                           ",@letra " +
                                           ",@sucursal " +
                                           ",@numero) ;SELECT SCOPE_IDENTITY()";

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@tipo_documento", entity.tipo_documento);
                        cmd.Parameters.AddWithValue("@letra", entity.letra);
                        cmd.Parameters.AddWithValue("@sucursal", entity.sucursal);
                        cmd.Parameters.AddWithValue("@numero", entity.numero);

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
        /// Actualiza registros en la tabla Tipo_documento
        /// </summary>
        /// <param name="entity">Entidad Tipo_documento</param>
        public void Update(Tipo_documento entity)
        {
            string SqlString = "UPDATE [dbo].[Tipo_documento] " +
                                  "SET [tipo_documento] = @tipo_documento " +
                                      ",[letra] = @letra " +
                                      ",[sucursal] = @sucursal " +
                                      ",[numero] = @numero " +
                              "WHERE id = @id ";

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", entity.id);
                        cmd.Parameters.AddWithValue("@tipo_documento", entity.tipo_documento);
                        cmd.Parameters.AddWithValue("@letra", entity.letra);
                        cmd.Parameters.AddWithValue("@sucursal", entity.sucursal);
                        cmd.Parameters.AddWithValue("@numero", entity.numero);

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
        /// Elimina registros de la tabla Tipo_documento
        /// </summary>
        /// <param name="id">int del id a eliminar</param>
        public void Delete(int id)
        {
            string SqlString = "DELETE FROM [dbo].[Tipo_documento] " +
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
        /// Selecciona registros de la tabla Tipo_documento
        /// </summary>
        /// <returns>Lista Tipo_documento</returns>
        public List<Tipo_documento> List()
        {
            string SqlString = "SELECT [id] " +
                                      ",[tipo_documento] " +
                                      ",[letra] " +
                                      ",[sucursal] " +
                                      ",[numero] " +
                                      ",[venta] " +
                                 "FROM [dbo].[Tipo_documento] ";

            List <Tipo_documento> result = new List<Tipo_documento>();

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
                                Tipo_documento entity = LoadEntity(dr);
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
        /// Selecciona un registro de la tabla Tipo_documento
        /// </summary>
        /// <param name="id">int del registro a seleccionar</param>
        /// <returns>Tipo_documento</returns>
        public Tipo_documento GetById(int id)
        {
            string SqlString = "SELECT [id] "+
                                      ",[tipo_documento] "+
                                      ",[letra] "+
                                      ",[sucursal] "+
                                      ",[numero] "+
                                      ",[venta] " +
                                 "FROM [dbo].[Tipo_documento] " +
                                "WHERE id = @id";

            Tipo_documento entity = null;
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
        /// Carga una entidad de Tipo_documento a partir de un DataReader
        /// </summary>
        /// <param name="dr">IDataReader </param>
        /// <returns>Tipo_documento</returns>
        private Tipo_documento LoadEntity(IDataReader dr)
        {
            Tipo_documento entity = new Tipo_documento()
            {
                id = dr.GetByNameInt("id"),
                tipo_documento = dr.GetByNameString("tipo_documento"),
                letra = dr.GetByNameString("letra"),
                sucursal = dr.GetByNameInt("sucursal"),
                numero = dr.GetByNameInt("numero"),
                venta = dr.GetByNameBool("venta")
            };

            return entity;
        }
    }
}
