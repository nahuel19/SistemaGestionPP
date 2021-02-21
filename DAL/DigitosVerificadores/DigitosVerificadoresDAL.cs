//using Entities;

using DAL.Model;
using Entities.EntidadesDigitoVerificador;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DigitosVerificadores
{
    /// <summary>
    /// Acceso a base para manejar los digitos verificadores
    /// </summary>
    public class DigitosVerificadoresDAL
    {
        
        DBGestion db = new DBGestion();

        #region digitos horizontales
        /// <summary>
        /// Update genérico para ejecutar stores de de DVH 
        /// </summary>
        /// <param name="entity">IEntityDV</param>
        /// <param name="tabla">string</param>
        public void Update(IEntityDV entity, string tabla)
        {
            string sp = "sp_updateDVH_" + tabla + " @DVH, @id";
            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sp, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", entity.id);
                        cmd.Parameters.AddWithValue("@DVH", entity.DVH);

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
        /// Lista los productos, incluyendo el campo de DVH
        /// </summary>
        /// <returns>List<Producto></returns>
        public List<Producto> ListProductosDV()
        {
            return db.Producto.ToList() ?? new List<Producto>();
        }
        #endregion


        #region digitos verticales
        /// <summary>
        /// Lista la tabla que contiene la info de los dígitos verificadores verticales
        /// </summary>
        /// <returns>List<DVV></returns>
        public List<DVV> ListDVV()
        {
            return db.DVV.ToList() ?? new List<DVV>();
        }

        /// <summary>
        /// Update de tabla DVV (contiene info de digítos verificadores verticales)
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateDVV(DVV entity)
        {
            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_insert_updateDVV @tabla, @columna, @DV", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@tabla", entity.tabla);
                        cmd.Parameters.AddWithValue("@columna", entity.columna);
                        cmd.Parameters.AddWithValue("@DV", entity.DV);

                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

    }
}
