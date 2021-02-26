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
	/// dal familia_patente
	/// </summary>
	internal static class Familia_Patente
	{
		/// <summary>
		/// selecciona todo de la tabla familia_patente
		/// </summary>
		/// <returns>dataset</returns>
		public static DataSet SelectAll()
		{
			try
			{
				using (SqlConnection conn = ConnectionBD.Instance().Conect())
				{
					using (SqlCommand cmd = new SqlCommand("Familia_Patente_SelectAll", conn))
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
				//DbCommand myCommand = myDatabase.GetStoredProcCommand("Familia_Patente_SelectAll");
				//return myDatabase.ExecuteDataSet(myCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// selecciona las familia_patente por id de familia
		/// </summary>
		/// <param name="IdFamiliaElement">string</param>
		/// <returns>dataset</returns>
		public static DataSet Select(System.String IdFamiliaElement)
		{
			try
			{
				using (SqlConnection conn = ConnectionBD.Instance().Conect())
				{
					using (SqlCommand cmd = new SqlCommand("Familia_Patente_Select @IdFamilia", conn))
					{
						cmd.CommandType = CommandType.Text;
						cmd.Parameters.AddWithValue("@IdFamilia", IdFamiliaElement);

						conn.Open();

						SqlDataAdapter da = new SqlDataAdapter(cmd);
						DataSet ds = new DataSet();
						da.Fill(ds);
						da.Dispose();

						return ds;
					}
				}
				//	Database myDatabase = DatabaseFactory.CreateDatabase();
				//	DbCommand myCommand = myDatabase.GetStoredProcCommand("Familia_Patente_Select");
				//	myDatabase.AddInParameter(myCommand, "@IdFamilia", DbType.String, IdFamiliaElement);

				//	return myDatabase.ExecuteDataSet(myCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// elimina familia_patente por id de familia
		/// </summary>
		/// <param name="_object">familia element</param>
		public static void Delete(Entities.UFP.FamiliaElement _object)
		{
			using (SqlConnection conn = ConnectionBD.Instance().Conect())
			{
				using (SqlCommand cmd = new SqlCommand("Familia_Patente_Delete @IdFamilia", conn))
				{
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@IdFamilia", _object.IdFamiliaElement);

					conn.Open();
					cmd.ExecuteNonQuery();
				}
			}

			//Database myDatabase = DatabaseFactory.CreateDatabase();
			//DbCommand myCommand = myDatabase.GetStoredProcCommand("Familia_Patente_Delete");
			//myDatabase.AddInParameter(myCommand, "@IdFamilia", DbType.String, _object.IdFamiliaElement);

			//myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// actualiza familia_patente por id de familia
		/// </summary>
		/// <param name="_object">familia element</param>
		public static void Update(Entities.UFP.FamiliaElement _object)
		{
			using (SqlConnection conn = ConnectionBD.Instance().Conect())
			{
				using (SqlCommand cmd = new SqlCommand("Familia_Patente_Update @IdFamilia, @Nombre", conn))
				{
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@IdFamilia", _object.IdFamiliaElement);
					cmd.Parameters.AddWithValue("@Nombre", _object.Nombre);

					conn.Open();
					cmd.ExecuteNonQuery();
				}
			}
			//Database myDatabase = DatabaseFactory.CreateDatabase();
			//DbCommand myCommand = myDatabase.GetStoredProcCommand("Familia_Patente_Update");
			//myDatabase.AddInParameter(myCommand, "@IdFamilia", DbType.String, _object.IdFamiliaElement);
			//myDatabase.AddInParameter(myCommand, "@Nombre", DbType.String, _object.Nombre);
			//myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// inserta familia_patente
		/// </summary>
		/// <param name="_object"></param>
		public static void Insert(Entities.UFP.FamiliaElement _object)
		{
			using (SqlConnection conn = ConnectionBD.Instance().Conect())
			{
				using (SqlCommand cmd = new SqlCommand("Familia_Patente_Insert @IdFamilia, @Nombre", conn))
				{
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@IdFamilia", _object.IdFamiliaElement);
					cmd.Parameters.AddWithValue("@Nombre", _object.Nombre);

					conn.Open();
					cmd.ExecuteNonQuery();
				}
			}
			//Database myDatabase = DatabaseFactory.CreateDatabase();
			//DbCommand myCommand = myDatabase.GetStoredProcCommand("Familia_Patente_Insert");
			//myDatabase.AddInParameter(myCommand, "@IdFamilia", DbType.String, _object.IdFamiliaElement);
			//myDatabase.AddInParameter(myCommand, "@Nombre", DbType.String, _object.Nombre);
			//myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// obtiene los accesos
		/// </summary>
		/// <param name="IdFamiliaElement">string</param>
		/// <returns></returns>
		public static DataTable GetAccesos(System.String IdFamiliaElement)
		{
			try
			{
				using (SqlConnection conn = ConnectionBD.Instance().Conect())
				{
					using (SqlCommand cmd = new SqlCommand("Familia_Patente_Select @IdFamilia", conn))
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
				//DbCommand myCommand = myDatabase.GetStoredProcCommand("Familia_Patente_Select");
				//myDatabase.AddInParameter(myCommand, "@IdFamilia", DbType.String, IdFamiliaElement);

				//return myDatabase.ExecuteDataSet(myCommand).Tables[0];
			}
			catch (Exception ex)
			{				
				throw ex;
			}
		}

		/// <summary>
		/// elimina los accesos
		/// </summary>
		/// <param name="_object"></param>
		public static void DeleteAccesos(Entities.UFP.Familia _object)
		{
			using (SqlConnection conn = ConnectionBD.Instance().Conect())
			{
				using (SqlCommand cmd = new SqlCommand("Familia_Patente_Delete @IdFamilia", conn))
				{
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@IdFamilia", _object.IdFamiliaElement);

					conn.Open();
					cmd.ExecuteNonQuery();
				}
			}
			//Database myDatabase = DatabaseFactory.CreateDatabase();
			//DbCommand myCommand = myDatabase.GetStoredProcCommand("Familia_Patente_Delete");
			//myDatabase.AddInParameter(myCommand, "@IdFamilia", DbType.String, _object.IdFamiliaElement);

			//myDatabase.ExecuteNonQuery(myCommand);
		}

	}
}
