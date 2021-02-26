using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UFP
{
    /// <summary>
    /// dal familia
    /// </summary>
    internal static class Familia
    {
        /// <summary>
        /// selecciona las faimilias
        /// </summary>
        /// <returns>data set</returns>
        public static DataSet SelectAll()
        {
            try
            {                
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand("Familia_SelectAll", conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        conn.Open();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        da.Dispose();

                        return ds;
                    }
                }
                //Database myDatabase = DatabaseFactory.CreateDatabase();
                //DbCommand myCommand = myDatabase.GetStoredProcCommand("Familia_SelectAll");
                //return myDatabase.ExecuteDataSet(myCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// selecciona una familia
        /// </summary>
        /// <param name="IdFamiliaElement">string</param>
        /// <returns>data set</returns>
        public static DataSet Select(System.String IdFamiliaElement)
        {
            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand("Familia_Select @IdFamiliaElement", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@IdFamiliaElement", IdFamiliaElement);

                        conn.Open();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        da.Dispose();

                        return ds;
                    }
                }

                //Database myDatabase = DatabaseFactory.CreateDatabase();
                //DbCommand myCommand = myDatabase.GetStoredProcCommand("Familia_Select");
                //myDatabase.AddInParameter(myCommand, "@IdFamilia", DbType.String, IdFamiliaElement);

                //return myDatabase.ExecuteDataSet(myCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// elimina una familia
        /// </summary>
        /// <param name="_object">familia</param>
        public static void Delete(Entities.UFP.Familia _object)
        {
            if (_object.Accesos != null)
                DeleteAccesos(_object);

            using (SqlConnection conn = ConnectionBD.Instance().Conect())
            {
                using (SqlCommand cmd = new SqlCommand("Familia_Delete @IdFamiliaElement", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdFamiliaElement", _object.IdFamiliaElement);

                    conn.Open();
                    cmd.ExecuteNonQuery();                    
                }
            }

            //Database myDatabase = DatabaseFactory.CreateDatabase();
            //DbCommand myCommand = myDatabase.GetStoredProcCommand("Familia_Delete");
            //myDatabase.AddInParameter(myCommand, "@IdFamilia", DbType.String, _object.IdFamiliaElement);

            //myDatabase.ExecuteNonQuery(myCommand);
        }

        /// <summary>
        /// actualiza una familia
        /// </summary>
        /// <param name="_object">familia</param>
        public static void Update(Entities.UFP.Familia _object)
        {
            using (SqlConnection conn = ConnectionBD.Instance().Conect())
            {
                using (SqlCommand cmd = new SqlCommand("Familia_Update @IdFamilia, @Nombre", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdFamilia", _object.IdFamiliaElement);
                    cmd.Parameters.AddWithValue("@Nombre", _object.Nombre);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            //Database myDatabase = DatabaseFactory.CreateDatabase();
            //DbCommand myCommand = myDatabase.GetStoredProcCommand("Familia_Update");
            //myDatabase.AddInParameter(myCommand, "@IdFamilia", DbType.String, _object.IdFamiliaElement);
            //myDatabase.AddInParameter(myCommand, "@Nombre", DbType.String, _object.Nombre);
            //myDatabase.ExecuteNonQuery(myCommand);

            if (_object.Accesos != null)
            {
                DeleteAccesos(_object);
                Familia_Patente.DeleteAccesos(_object);
                foreach (Entities.UFP.FamiliaElement _tipo in _object.Accesos)
                {
                    if (_tipo.GetType().Name == "Familia")
                    {
                        using (SqlConnection conn = ConnectionBD.Instance().Conect())
                        {
                            using (SqlCommand cmd = new SqlCommand("Familia_Familia_Insert @IdFamilia, @IdFamiliaHijo", conn))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@IdFamilia", _object.IdFamiliaElement);
                                cmd.Parameters.AddWithValue("@IdFamiliaHijo", _tipo.IdFamiliaElement);

                                conn.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                        //DbCommand myCommandAccesos = myDatabase.GetStoredProcCommand("Familia_Familia_Insert");
                        //myDatabase.AddInParameter(myCommandAccesos, "@IdFamilia", DbType.String, _object.IdFamiliaElement);
                        //myDatabase.AddInParameter(myCommandAccesos, "@IdFamiliaHijo", DbType.String, _tipo.IdFamiliaElement);
                        //myDatabase.ExecuteNonQuery(myCommandAccesos);
                    }
                    else
                    {
                        using (SqlConnection conn = ConnectionBD.Instance().Conect())
                        {
                            using (SqlCommand cmd = new SqlCommand("Familia_Patente_Insert @IdFamilia, @IdPatente", conn))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@IdFamilia", _object.IdFamiliaElement);
                                cmd.Parameters.AddWithValue("@IdPatente", _tipo.IdFamiliaElement);

                                conn.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                        //DbCommand myCommandAccesos = myDatabase.GetStoredProcCommand("Familia_Patente_Insert");
                        //myDatabase.AddInParameter(myCommandAccesos, "@IdFamilia", DbType.String, _object.IdFamiliaElement);
                        //myDatabase.AddInParameter(myCommandAccesos, "@IdPatente", DbType.String, _tipo.IdFamiliaElement);
                        //myDatabase.ExecuteNonQuery(myCommandAccesos);
                    }

                }
            }
        }

        /// <summary>
        /// inserta una familia
        /// </summary>
        /// <param name="_object">familia</param>
        public static void Insert(Entities.UFP.Familia _object)
        {
            using (SqlConnection conn = ConnectionBD.Instance().Conect())
            {
                using (SqlCommand cmd = new SqlCommand("Familia_Insert @IdFamilia, @Nombre", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdFamilia", _object.IdFamiliaElement);
                    cmd.Parameters.AddWithValue("@Nombre", _object.Nombre);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            //Database myDatabase = DatabaseFactory.CreateDatabase();
            //DbCommand myCommand = myDatabase.GetStoredProcCommand("Familia_Insert");
            //myDatabase.AddInParameter(myCommand, "@IdFamilia", DbType.String, _object.IdFamiliaElement);
            //myDatabase.AddInParameter(myCommand, "@Nombre", DbType.String, _object.Nombre);
            //myDatabase.ExecuteNonQuery(myCommand);

            if (_object.Accesos != null)
            {
                DeleteAccesos(_object);
                Familia_Patente.DeleteAccesos(_object);
                foreach (Entities.UFP.FamiliaElement _tipo in _object.Accesos)
                {
                    if (_tipo.GetType().Name == "Familia")
                    {
                        using (SqlConnection conn = ConnectionBD.Instance().Conect())
                        {
                            using (SqlCommand cmd = new SqlCommand("Familia_Familia_Insert @IdFamilia, @IdFamiliaHijo", conn))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@IdFamilia", _object.IdFamiliaElement);
                                cmd.Parameters.AddWithValue("@IdFamiliaHijo", _tipo.IdFamiliaElement);

                                conn.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }

                        //DbCommand myCommandAccesos = myDatabase.GetStoredProcCommand("Familia_Familia_Insert");
                        //myDatabase.AddInParameter(myCommandAccesos, "@IdFamilia", DbType.String, _object.IdFamiliaElement);
                        //myDatabase.AddInParameter(myCommandAccesos, "@IdFamiliaHijo", DbType.String, _tipo.IdFamiliaElement);
                        //myDatabase.ExecuteNonQuery(myCommandAccesos);
                    }
                    else
                    {
                        using (SqlConnection conn = ConnectionBD.Instance().Conect())
                        {
                            using (SqlCommand cmd = new SqlCommand("Familia_Patente_Insert @IdFamilia, @IdPatente", conn))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@IdFamilia", _object.IdFamiliaElement);
                                cmd.Parameters.AddWithValue("@IdPatente", _tipo.IdFamiliaElement);

                                conn.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                        //DbCommand myCommandAccesos = myDatabase.GetStoredProcCommand("Familia_Patente_Insert");
                        //myDatabase.AddInParameter(myCommandAccesos, "@IdFamilia", DbType.String, _object.IdFamiliaElement);
                        //myDatabase.AddInParameter(myCommandAccesos, "@IdPatente", DbType.String, _tipo.IdFamiliaElement);
                        //myDatabase.ExecuteNonQuery(myCommandAccesos);
                    }
                }
            }
        }

        /// <summary>
        /// selecciona los accesos de una familia
        /// </summary>
        /// <param name="IdFamiliaElement">strin</param>
        /// <returns>datatable</returns>
        public static DataTable GetAccesos(System.String IdFamiliaElement)
        {
            using (SqlConnection conn = ConnectionBD.Instance().Conect())
            {
                using (SqlCommand cmd = new SqlCommand("Familia_Familia_SelectParticular @IdFamilia", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdFamilia", IdFamiliaElement);

                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    da.Dispose();

                    return dt;
                }
            }
            //Database myDatabase = DatabaseFactory.CreateDatabase();
            //DbCommand myCommand = myDatabase.GetStoredProcCommand("Familia_Familia_SelectParticular");
            //myDatabase.AddInParameter(myCommand, "@IdFamilia", DbType.String, IdFamiliaElement);

            //return myDatabase.ExecuteDataSet(myCommand).Tables[0];
        }

        /// <summary>
        /// elimina los accesos
        /// </summary>
        /// <param name="_object">familia</param>
        public static void DeleteAccesos(Entities.UFP.Familia _object)
        {
            using (SqlConnection conn = ConnectionBD.Instance().Conect())
            {
                using (SqlCommand cmd = new SqlCommand("Familia_Familia_DeleteParticular @IdFamilia", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdFamilia", _object.IdFamiliaElement);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            //Database myDatabase = DatabaseFactory.CreateDatabase();
            //DbCommand myCommand = myDatabase.GetStoredProcCommand("Familia_Familia_DeleteParticular");
            //myDatabase.AddInParameter(myCommand, "@IdFamilia", DbType.String, _object.IdFamiliaElement);

            //myDatabase.ExecuteNonQuery(myCommand);
        }
    }
}
