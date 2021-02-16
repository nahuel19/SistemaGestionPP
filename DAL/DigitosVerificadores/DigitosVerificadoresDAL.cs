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
    public class DigitosVerificadoresDAL
    {
        
        DBGestion db = new DBGestion();

        #region digitos horizontales
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
                
        public List<Producto> ListProductosDV()
        {
            return db.Producto.ToList() ?? new List<Producto>();
        }
        #endregion


        #region digitos verticales
        public List<DVV> ListDVV()
        {
            return db.DVV.ToList() ?? new List<DVV>();
        }

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
