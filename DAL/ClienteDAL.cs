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
    /// Clase de acceso a datos para manejar la tabla Cliente
    /// </summary>
    public class ClienteDAL : IDAL<Cliente>
    {
        /// <summary>
        /// INserta registros en la tabla Cliente
        /// </summary>
        /// <param name="entity">Entidad Cliente</param>
        /// <returns>Entidad Cliente</returns>
        public Cliente Insert(Cliente entity)
        {
            string SqlString = "INSERT INTO [dbo].[Cliente] "+
                               "([nombre] " +
                               ",[apellido] " +
                               ",[fk_id_tipo_doc_identidad] " +
                               ",[num_documento] " +
                               ",[fecha_nacimiento] " +
                               ",[direccion] " +
                               ",[telefono] " +
                               ",[mail]) " +
                         "VALUES " +
                               "(@nombre, " +
                               "@apellido, " +
                               "@fk_id_tipo_doc_identidad, " +
                               "@num_documento, " +
                               "@fecha_nacimiento, " +
                               "@direccion, " +
                               "@telefono, " +
                               "@mail) ;SELECT SCOPE_IDENTITY()";

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@nombre", entity.nombre);
                        cmd.Parameters.AddWithValue("@apellido", entity.apellido);
                        cmd.Parameters.AddWithValue("@fk_id_tipo_doc_identidad", entity.fk_id_tipo_doc_identidad);
                        cmd.Parameters.AddWithValue("@num_documento", entity.num_documento);
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", entity.fecha_nacimiento);
                        cmd.Parameters.AddWithValue("@direccion", entity.direccion);
                        cmd.Parameters.AddWithValue("@telefono", entity.telefono);
                        cmd.Parameters.AddWithValue("@mail", entity.mail);
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
        /// Actualiza registros en la tabla Cliente
        /// </summary>
        /// <param name="entity">Entidad Cliente</param>
        public void Update(Cliente entity)
        {
            string SqlString = "UPDATE [dbo].[Cliente] " +
                              "SET [nombre] = @nombre " +
                              ",[apellido] = @apellido " +
                              ",[fk_id_tipo_doc_identidad] = @fk_id_tipo_doc_identidad " +
                              ",[num_documento] = @num_documento " +
                              ",[fecha_nacimiento] = @fecha_nacimiento " +
                              ",[direccion] = @direccion " +
                              ",[telefono] = @telefono " +
                              ",[mail] = @mail " +
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
                        cmd.Parameters.AddWithValue("@apellido", entity.apellido);
                        cmd.Parameters.AddWithValue("@fk_id_tipo_doc_identidad", entity.fk_id_tipo_doc_identidad);
                        cmd.Parameters.AddWithValue("@num_documento", entity.num_documento);
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", entity.fecha_nacimiento);
                        cmd.Parameters.AddWithValue("@direccion", entity.direccion);
                        cmd.Parameters.AddWithValue("@telefono", entity.telefono);
                        cmd.Parameters.AddWithValue("@mail", entity.mail);
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
        /// Elimina registros de la tabla Cliente
        /// </summary>
        /// <param name="id">int para eliminar un registro por id</param>
        public void Delete(int id)
        {
            string SqlString = "DELETE FROM [dbo].[Cliente] " +
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
        /// Selecciona todos los registros de la tabla Cliente
        /// </summary>
        /// <returns>Lista de Entidad Cliente</returns>
        public List<Cliente> List()
        {
            List<Cliente> result = new List<Cliente>();

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_list_clients", conn))
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Cliente entity = LoadEntity(dr);
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
        /// Selecciona un registro de la tabla Cliente
        /// </summary>
        /// <param name="id">int para buscar un gestro por id</param>
        /// <returns>Entidad Cliente</returns>
        public Cliente GetById(int id)
        {
            Cliente entity = null;
            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_get_client_by_id @id", conn))
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
        /// Carga una entidad cliente a partir de un DataReader
        /// </summary>
        /// <param name="dr">IdataReader con datos de cliente</param>
        /// <returns>Entidad Cliente</returns>
        private Cliente LoadEntity(IDataReader dr)
        {
            Cliente entity = new Cliente()
            {
                id = dr.GetByNameInt("id"),
                nombre = dr.GetByNameString("nombre"),
                apellido = dr.GetByNameString("apellido"),
                fk_id_tipo_doc_identidad = dr.GetByNameInt("fk_id_tipo_doc_identidad"),
                num_documento = dr.GetByNameString("num_documento"),
                fecha_nacimiento = dr.GetByNameDT("fecha_nacimiento"),
                direccion = dr.GetByNameString("direccion"),
                telefono= dr.GetByNameString("telefono"),
                mail = dr.GetByNameString("mail"),
                doc_identidad = dr.GetByNameString("doc_identidad")
            };

            return entity;
        }
    }
}
