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
    /// Clase de acceso a datos para manejar la tabla Proveedor
    /// </summary>
    public class ProveedorDAL : IDAL<Proveedor>
    {
        /// <summary>
        /// Inserta registros en la tabla Proveedor
        /// </summary>
        /// <param name="entity">Entidad Proveedor</param>
        /// <returns>Entidad Proveedor</returns>
        public Proveedor Insert(Proveedor entity)
        {

            string SqlString = "INSERT INTO [dbo].[Proveedor] " +
                                       "([nombre] " +
                                       ",[fk_id_tipo_doc_identidad] " +
                                       ",[num_documento] " +
                                       ",[direccion] " +
                                       ",[telefono] " +
                                       ",[mail] " +
                                       ",[url]) " +
                                 "VALUES " +
                                       "(@nombre " +
                                       ",@fk_id_tipo_doc_identidad " +
                                       ",@num_documento " +
                                       ",@direccion " +
                                       ",@telefono " +
                                       ",@mail " +
                                       ",@url) ;SELECT SCOPE_IDENTITY()";


            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@nombre", entity.nombre);
                        cmd.Parameters.AddWithValue("@fk_id_tipo_doc_identidad", entity.fk_id_tipo_doc_identidad);
                        cmd.Parameters.AddWithValue("@num_documento", entity.num_documento);
                        cmd.Parameters.AddWithValue("@direccion", entity.direccion);
                        cmd.Parameters.AddWithValue("@telefono", entity.telefono);
                        cmd.Parameters.AddWithValue("@mail", entity.mail);
                        cmd.Parameters.AddWithValue("@url", entity.url);
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
        /// Actualiza registros en la tabla Proveedor
        /// </summary>
        /// <param name="entity">Entidad Proveedor</param>
        public void Update(Proveedor entity)
        {
            string SqlString = "UPDATE [dbo].[Proveedor] " +
                               "SET [nombre] = @nombre " +
                                  ",[fk_id_tipo_doc_identidad] = @fk_id_tipo_doc_identidad " +
                                  ",[num_documento] = @num_documento " +
                                  ",[direccion] = @direccion " +
                                  ",[telefono] = @telefono " +
                                  ",[mail] = @mail " +
                                  ",[url] = @url " +
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
                        cmd.Parameters.AddWithValue("@fk_id_tipo_doc_identidad", entity.fk_id_tipo_doc_identidad);
                        cmd.Parameters.AddWithValue("@num_documento", entity.num_documento);
                        cmd.Parameters.AddWithValue("@direccion", entity.direccion);
                        cmd.Parameters.AddWithValue("@telefono", entity.telefono);
                        cmd.Parameters.AddWithValue("@mail", entity.mail);
                        cmd.Parameters.AddWithValue("@url", entity.url);
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
        /// Elimina registros de la tabla Proveedor
        /// </summary>
        /// <param name="id">int del id a eliminar</param>
        public void Delete(int id)
        {
            string SqlString = "DELETE FROM [dbo].[Proveedor] " +
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
        /// Selecciona registros de la tabla Proveedor
        /// </summary>
        /// <returns>Lista Proveedor</returns>
        public List<Proveedor> List()
        {

            List <Proveedor> result = new List<Proveedor>();


            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_list_suppliers", conn))
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Proveedor entity = LoadEntity(dr);
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
        /// Selecciona un registro de la tabla Proveedor
        /// </summary>
        /// <param name="id">int del registro a seleccionar</param>
        /// <returns>Proveedor</returns>
        public Proveedor GetById(int id)
        {
            Proveedor entity = null;

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_get_supplier_by_id @id", conn))
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
        /// Carga una entidad de Proveedor a partir de un DataReader
        /// </summary>
        /// <param name="dr">IDataReader </param>
        /// <returns>Proveedor</returns>
        private Proveedor LoadEntity(IDataReader dr)
        {
            Proveedor entity = new Proveedor()
            {
                id = dr.GetByNameInt("id"),
                nombre = dr.GetByNameString("nombre"),
                fk_id_tipo_doc_identidad = dr.GetByNameInt("fk_id_tipo_doc_identidad"),
                num_documento = dr.GetByNameString("num_documento"),
                direccion = dr.GetByNameString("direccion"),
                telefono = dr.GetByNameString("telefono"),
                mail = dr.GetByNameString("mail"),
                url = dr.GetByNameString("url"),
                doc_identidad = dr.GetByNameString("doc_identidad")
            };

            return entity;
        }
    }
}
