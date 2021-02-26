using Services.Cache;
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
	/// Dal Usuario
	/// </summary>
	internal static class Usuario
	{	
		/// <summary>
		/// slecciona todos los usuarios
		/// </summary>
		/// <returns>dataSet</returns>
		public static DataSet SelectAll()
		{
			try
			{
				using (SqlConnection conn = ConnectionBD.Instance().Conect())
				{
					using (SqlCommand cmd = new SqlCommand("Usuario_SelectAll", conn))
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
				//DbCommand myCommand = myDatabase.GetStoredProcCommand("Usuario_SelectAll");
				//return myDatabase.ExecuteDataSet(myCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// selecciona un usuario
		/// </summary>
		/// <param name="IdUsuario">string</param>
		/// <returns>data set</returns>
		public static DataSet Select(System.String IdUsuario)
		{
			try
			{
				using (SqlConnection conn = ConnectionBD.Instance().Conect())
				{
					using (SqlCommand cmd = new SqlCommand("Usuario_Select @IdUsuario", conn))
					{
						cmd.CommandType = CommandType.Text;
						cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

						conn.Open();

						SqlDataAdapter da = new SqlDataAdapter(cmd);
						DataSet ds = new DataSet();
						da.Fill(ds);
						da.Dispose();

						return ds;
					}
				}
				//Database myDatabase = DatabaseFactory.CreateDatabase();
				//DbCommand myCommand = myDatabase.GetStoredProcCommand("Usuario_Select");
				//myDatabase.AddInParameter(myCommand, "@IdUsuario", DbType.String, IdUsuario);

				//return myDatabase.ExecuteDataSet(myCommand);
			}
			catch (Exception ex)
			{				
				throw ex;
			}
		}

		/// <summary>
		/// elimina un usuario
		/// </summary>
		/// <param name="_object">usuario</param>
		public static void Delete(Entities.UFP.Usuario _object)
		{
			if (_object.Permisos != null)
			{
				DeleteFamilias(_object);
				DeletePatentes(_object);
			}

			using (SqlConnection conn = ConnectionBD.Instance().Conect())
			{
				using (SqlCommand cmd = new SqlCommand("Usuario_Delete @IdUsuario", conn))
				{
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@IdUsuario", _object.IdUsuario);

					conn.Open();
					cmd.ExecuteNonQuery();
				}
			}
			//Database myDatabase = DatabaseFactory.CreateDatabase();
			//DbCommand myCommand = myDatabase.GetStoredProcCommand("Usuario_Delete");
			//myDatabase.AddInParameter(myCommand, "@IdUsuario", DbType.String, _object.IdUsuario);

			//myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// actualiza un usuario
		/// </summary>
		/// <param name="_object">usuario</param>
		public static void Update(Entities.UFP.Usuario _object)
		{
			using (SqlConnection conn = ConnectionBD.Instance().Conect())
			{
				using (SqlCommand cmd = new SqlCommand("Usuario_Update @IdUsuario, @Nombre, @Pass", conn))
				{
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@IdUsuario", _object.IdUsuario);
					cmd.Parameters.AddWithValue("@Nombre", _object.Nombre);
					cmd.Parameters.AddWithValue("@Pass", _object.Pass);

					conn.Open();
					cmd.ExecuteNonQuery();
				}
			}
			//Database myDatabase = DatabaseFactory.CreateDatabase();
			//DbCommand myCommand = myDatabase.GetStoredProcCommand("Usuario_Update");
			//myDatabase.AddInParameter(myCommand, "@IdUsuario", DbType.String, _object.IdUsuario);
			//myDatabase.AddInParameter(myCommand, "@Nombre", DbType.String, _object.Nombre);
			//myDatabase.ExecuteNonQuery(myCommand);

			if (_object.Permisos != null)
			{
				DeleteFamilias(_object);
				DeletePatentes(_object);

				foreach (Entities.UFP.FamiliaElement _tipo in _object.Permisos)
				{
					if (_tipo.GetType().Name == "Familia")
					{
						using (SqlConnection conn = ConnectionBD.Instance().Conect())
						{
							using (SqlCommand cmd = new SqlCommand("Usuario_Familia_Insert @IdUsuario, @IdFamilia", conn))
							{
								cmd.CommandType = CommandType.Text;
								cmd.Parameters.AddWithValue("@IdUsuario", _object.IdUsuario);
								cmd.Parameters.AddWithValue("@IdFamilia", _tipo.IdFamiliaElement);

								conn.Open();
								cmd.ExecuteNonQuery();
							}
						}

						//DbCommand myCommandAccesos = myDatabase.GetStoredProcCommand("Usuario_Familia_Insert");
						//myDatabase.AddInParameter(myCommandAccesos, "@IdUsuario", DbType.String, _object.IdUsuario);
						//myDatabase.AddInParameter(myCommandAccesos, "@IdFamilia", DbType.String, _tipo.IdFamiliaElement);
						//myDatabase.ExecuteNonQuery(myCommandAccesos);
					}
					else
					{
						using (SqlConnection conn = ConnectionBD.Instance().Conect())
						{
							using (SqlCommand cmd = new SqlCommand("Usuario_Patente_Insert @IdUsuario, @IdPatente", conn))
							{
								cmd.CommandType = CommandType.Text;
								cmd.Parameters.AddWithValue("@IdUsuario", _object.IdUsuario);
								cmd.Parameters.AddWithValue("@IdPatente", _tipo.IdFamiliaElement);

								conn.Open();
								cmd.ExecuteNonQuery();
							}
						}


						//DbCommand myCommandAccesos = myDatabase.GetStoredProcCommand("Usuario_Patente_Insert");
						//myDatabase.AddInParameter(myCommandAccesos, "@IdUsuario", DbType.String, _object.IdUsuario);
						//myDatabase.AddInParameter(myCommandAccesos, "@IdPatente", DbType.String, _tipo.IdFamiliaElement);
						//myDatabase.ExecuteNonQuery(myCommandAccesos);
					}
				}

			}
		}

		/// <summary>
		/// inserta un nuevo usuario
		/// </summary>
		/// <param name="_object">usuario</param>
		public static void Insert(Entities.UFP.Usuario _object)
		{
			using (SqlConnection conn = ConnectionBD.Instance().Conect())
			{
				using (SqlCommand cmd = new SqlCommand("Usuario_Insert @IdUsuario, @Nombre, @Pass", conn))
				{
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@IdUsuario", _object.IdUsuario);
					cmd.Parameters.AddWithValue("@Nombre", _object.Nombre);
					cmd.Parameters.AddWithValue("@Pass", _object.Pass);

					conn.Open();
					cmd.ExecuteNonQuery();
				}
			}
			//Database myDatabase = DatabaseFactory.CreateDatabase();
			//DbCommand myCommand = myDatabase.GetStoredProcCommand("Usuario_Insert");
			//myDatabase.AddInParameter(myCommand, "@IdUsuario", DbType.String, _object.IdUsuario);
			//myDatabase.AddInParameter(myCommand, "@Nombre", DbType.String, _object.Nombre);
			//myDatabase.ExecuteNonQuery(myCommand);

			if (_object.Permisos != null)
			{
				DeleteFamilias(_object);
				DeletePatentes(_object);

				foreach (Entities.UFP.FamiliaElement _tipo in _object.Permisos)
				{
					if (_tipo.GetType().Name == "Familia")
					{
						using (SqlConnection conn = ConnectionBD.Instance().Conect())
						{
							using (SqlCommand cmd = new SqlCommand("Usuario_Familia_Insert @IdUsuario, @IdFamilia", conn))
							{
								cmd.CommandType = CommandType.Text;
								cmd.Parameters.AddWithValue("@IdUsuario", _object.IdUsuario);
								cmd.Parameters.AddWithValue("@IdFamilia", _tipo.IdFamiliaElement);

								conn.Open();
								cmd.ExecuteNonQuery();
							}
						}
						//DbCommand myCommandAccesos = myDatabase.GetStoredProcCommand("Usuario_Familia_Insert");
						//myDatabase.AddInParameter(myCommandAccesos, "@IdUsuario", DbType.String, _object.IdUsuario);
						//myDatabase.AddInParameter(myCommandAccesos, "@IdFamilia", DbType.String, _tipo.IdFamiliaElement);
						//myDatabase.ExecuteNonQuery(myCommandAccesos);
					}
					else
					{
						using (SqlConnection conn = ConnectionBD.Instance().Conect())
						{
							using (SqlCommand cmd = new SqlCommand("Usuario_Patente_Insert @IdUsuario, @IdPatente", conn))
							{
								cmd.CommandType = CommandType.Text;
								cmd.Parameters.AddWithValue("@IdUsuario", _object.IdUsuario);
								cmd.Parameters.AddWithValue("@IdPatente", _tipo.IdFamiliaElement);

								conn.Open();
								cmd.ExecuteNonQuery();
							}
						}
						//DbCommand myCommandAccesos = myDatabase.GetStoredProcCommand("Usuario_Patente_Insert");
						//myDatabase.AddInParameter(myCommandAccesos, "@IdUsuario", DbType.String, _object.IdUsuario);
						//myDatabase.AddInParameter(myCommandAccesos, "@IdPatente", DbType.String, _tipo.IdFamiliaElement);
						//myDatabase.ExecuteNonQuery(myCommandAccesos);
					}
				}

			}
		}

		//=================================================================
		/// <summary>
		/// devuelve las familias de un usuario
		/// </summary>
		/// <param name="IdUsuario">string</param>
		/// <returns>data table</returns>
		public static DataTable GetFamilias(System.String IdUsuario)
		{
			using (SqlConnection conn = ConnectionBD.Instance().Conect())
			{
				using (SqlCommand cmd = new SqlCommand("Usuario_Familia_SelectParticular @IdUsuario", conn))
				{
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

					conn.Open();

					SqlDataAdapter da = new SqlDataAdapter(cmd);
					DataTable dt = new DataTable();
					da.Fill(dt);
					da.Dispose();

					return dt;
				}
			}
			//Database myDatabase = DatabaseFactory.CreateDatabase();
			//DbCommand myCommand = myDatabase.GetStoredProcCommand("Usuario_Familia_SelectParticular");
			//myDatabase.AddInParameter(myCommand, "@IdUsuario", DbType.String, IdUsuario);

			//return myDatabase.ExecuteDataSet(myCommand).Tables[0];
		}

		/// <summary>
		/// elimina las familias de un usuario
		/// </summary>
		/// <param name="_object"></param>
		public static void DeleteFamilias(Entities.UFP.Usuario _object)
		{
			using (SqlConnection conn = ConnectionBD.Instance().Conect())
			{
				using (SqlCommand cmd = new SqlCommand("Usuario_Familia_DeleteParticular @IdUsuario", conn))
				{
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@IdUsuario", _object.IdUsuario);

					conn.Open();
					cmd.ExecuteNonQuery();
				}
			}
			//Database myDatabase = DatabaseFactory.CreateDatabase();
			//DbCommand myCommand = myDatabase.GetStoredProcCommand("Usuario_Familia_DeleteParticular");
			//myDatabase.AddInParameter(myCommand, "@IdUsuario", DbType.String, _object.IdUsuario);

			//myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// devuelve las patentes de un usuario
		/// </summary>
		/// <param name="IdUsuario">string</param>
		/// <returns>datatable</returns>
		public static DataTable GetPatentes(System.String IdUsuario)
		{
			using (SqlConnection conn = ConnectionBD.Instance().Conect())
			{
				using (SqlCommand cmd = new SqlCommand("Usuario_Patente_SelectParticular @IdUsuario", conn))
				{
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

					conn.Open();

					SqlDataAdapter da = new SqlDataAdapter(cmd);
					DataTable dt = new DataTable();
					da.Fill(dt);
					da.Dispose();

					return dt;
				}
			}
			//Database myDatabase = DatabaseFactory.CreateDatabase();
			//DbCommand myCommand = myDatabase.GetStoredProcCommand("Usuario_Patente_SelectParticular");
			//myDatabase.AddInParameter(myCommand, "@IdUsuario", DbType.String, IdUsuario);

			//return myDatabase.ExecuteDataSet(myCommand).Tables[0];
		}

		/// <summary>
		/// elimina las patentes de un usuario
		/// </summary>
		/// <param name="_object"></param>
		public static void DeletePatentes(Entities.UFP.Usuario _object)
		{
			using (SqlConnection conn = ConnectionBD.Instance().Conect())
			{
				using (SqlCommand cmd = new SqlCommand("Usuario_Patente_DeleteParticular @IdUsuario", conn))
				{
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@IdUsuario", _object.IdUsuario);

					conn.Open();
					cmd.ExecuteNonQuery();
				}
			}
			//Database myDatabase = DatabaseFactory.CreateDatabase();
			//DbCommand myCommand = myDatabase.GetStoredProcCommand("Usuario_Patente_DeleteParticular");
			//myDatabase.AddInParameter(myCommand, "@IdUsuario", DbType.String, _object.IdUsuario);

			//myDatabase.ExecuteNonQuery(myCommand);
		}

		//=================================================================
		/// <summary>
		/// valida si un usuario puede loggearse
		/// </summary>
		/// <param name="entity">usuario</param>
		/// <returns>bool, string (idusuario)</returns>
		public static (bool,string) Login(Entities.UFP.Usuario entity)
		{
			string idUser = null;
			try
			{
				using (SqlConnection conn = ConnectionBD.Instance().Conect())
				{
					using (SqlCommand cmd = new SqlCommand("sp_login @nombre, @pass", conn))
					{
						cmd.CommandType = CommandType.Text;
						cmd.Parameters.AddWithValue("@nombre", entity.Nombre);
						cmd.Parameters.AddWithValue("@pass", entity.Pass);
						conn.Open();

						SqlDataReader reader = cmd.ExecuteReader();

						if (reader.HasRows)
						{
							while (reader.Read())
							{
								idUser = reader.GetString(0);
							}
							return (true,idUser);
						}
						else
							return (false, idUser);
					}

				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}

