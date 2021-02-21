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
    /// Clase de acceso a datos para manejar la tabla Log
    /// </summary>
    public class LogDAL
    {
        /// <summary>
        /// Inserta registros en la tabla Log
        /// </summary>
        /// <param name="entity">Entidad Log</param>
        /// <returns>Entidad Log a ser insertada</returns>
        public Log Insert(Log entity)
        {

            string SqlString = "INSERT INTO [dbo].[Log] " +
                                           "([tipo_log] " +
                                           ",[usuario] " +
                                           ",[fecha] " +
                                           ",[clase] " +
                                           ",[metodo] " +
                                           ",[stack_trace]  " +
                                           ",[mensaje] " +
                                           ",[info_operacion]) " +
                                     "VALUES " +
                                           "(@tipo_log " +
                                           ",@usuario " +
                                           ",@fecha " +
                                           ",@clase " +
                                           ",@metodo " +
                                           ",@stack_trace " +
                                           ",@mensaje " +
                                           ",@info_operacion) ";

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", entity.id);
                        cmd.Parameters.AddWithValue("@tipo_log", entity.tipo_log);                        
                        cmd.Parameters.AddWithValue("@usuario", entity.usuario);
                        cmd.Parameters.AddWithValue("@fecha", entity.fecha);
                        cmd.Parameters.AddWithValue("@clase", entity.clase);
                        cmd.Parameters.AddWithValue("@metodo", entity.metodo);
                        cmd.Parameters.AddWithValue("@stack_trace", entity.stack_trace);
                        cmd.Parameters.AddWithValue("@mensaje", entity.mensaje);
                        cmd.Parameters.AddWithValue("@info_operacion", entity.info_operacion);

                        conn.Open();

                        cmd.ExecuteNonQuery();
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
        /// Selecciona todos los registros de la tabla Log
        /// </summary>
        /// <returns>Lista Logs</returns>
        public List<Log> List()
        {           
            List<Log> result = new List<Log>();

            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_get_logs", conn))
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Log entity = LoadEntity(dr);
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
        /// Selecciona un registro de la tabla Log
        /// </summary>
        /// <param name="id">int para buscar Log por id</param>
        /// <returns>Entidad Log</returns>
        public Log GetById(int id)
        {
            Log entity = null;
            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_get_log_by_id @id", conn))
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
        /// A partir de un DataReader, carga una Entidad Log
        /// </summary>
        /// <param name="dr">IDataReader con datos obtenidos de Log</param>
        /// <returns>Entidad Log</returns>
        private Log LoadEntity(IDataReader dr)
        {
            Log entity = new Log()
            {
                id = dr.GetByNameInt("id"),
                tipo_log = dr.GetByNameInt("tipo_log"),
                usuario = dr.GetByNameInt("usuario"),
                fecha = dr.GetByNameDT("fecha"),
                clase = dr.GetByNameString("clase"),
                metodo = dr.GetByNameString("metodo"),
                stack_trace = dr.GetByNameString("stack_trace"),
                mensaje = dr.GetByNameString("mensaje"),
                info_operacion = dr.GetByNameString("info_operacion"),
                tipo_log_nombre = dr.GetByNameString("tipo_log_nombre")
            };

            return entity;
        }

    }
}
