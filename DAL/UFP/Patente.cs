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
	/// dal patente
	/// </summary>
	internal static class Patente
	{
		/// <summary>
		/// selecciona todas las patentes
		/// </summary>
		/// <returns>data set</returns>
		public static DataSet SelectAll()
		{
			try
			{
				using (SqlConnection conn = ConnectionBD.Instance().Conect())
				{
					using (SqlCommand cmd = new SqlCommand("Patente_SelectAll", conn))
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
				//DbCommand myCommand = myDatabase.GetStoredProcCommand("Patente_SelectAll");
				//return myDatabase.ExecuteDataSet(myCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// selecciona una patente
		/// </summary>
		/// <param name="IdFamiliaElement">id</param>
		/// <returns>data set</returns>
		public static DataSet Select(System.String IdFamiliaElement)
		{
			try
			{
				using (SqlConnection conn = ConnectionBD.Instance().Conect())
				{
					using (SqlCommand cmd = new SqlCommand("Patente_Select @IdPatente", conn))
					{
						cmd.CommandType = CommandType.Text;
						cmd.Parameters.AddWithValue("@IdPatente", IdFamiliaElement);

						conn.Open();

						SqlDataAdapter da = new SqlDataAdapter(cmd);
						DataSet ds = new DataSet();
						da.Fill(ds);
						da.Dispose();

						return ds;
					}
				}
				//Database myDatabase = DatabaseFactory.CreateDatabase();
				//DbCommand myCommand = myDatabase.GetStoredProcCommand("Patente_Select");
				//myDatabase.AddInParameter(myCommand, "@IdPatente", DbType.String, IdFamiliaElement);

				//return myDatabase.ExecuteDataSet(myCommand);
			}
			catch (Exception ex)
			{				
				throw ex;
			}
		}

		/// <summary>
		/// elimina una patente
		/// </summary>
		/// <param name="_object">patente</param>
		public static void Delete(Entities.UFP.Patente _object)
		{
			using (SqlConnection conn = ConnectionBD.Instance().Conect())
			{
				using (SqlCommand cmd = new SqlCommand("Patente_Delete @IdPatente", conn))
				{
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@IdPatente", _object.IdFamiliaElement);

					conn.Open();
					cmd.ExecuteNonQuery();
				}
			}
			//Database myDatabase = DatabaseFactory.CreateDatabase();
			//DbCommand myCommand = myDatabase.GetStoredProcCommand("Patente_Delete");
			//myDatabase.AddInParameter(myCommand, "@IdPatente", DbType.String, _object.IdFamiliaElement);

			//myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// actualiza una patente
		/// </summary>
		/// <param name="_object">patente</param>
		public static void Update(Entities.UFP.Patente _object)
		{
			using (SqlConnection conn = ConnectionBD.Instance().Conect())
			{
				using (SqlCommand cmd = new SqlCommand("Patente_Update @IdPatente, @Nombre", conn))
				{
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@IdPatente", _object.IdFamiliaElement);
					cmd.Parameters.AddWithValue("@Nombre", _object.Nombre);

					conn.Open();
					cmd.ExecuteNonQuery();
				}
			}
			//Database myDatabase = DatabaseFactory.CreateDatabase();
			//DbCommand myCommand = myDatabase.GetStoredProcCommand("Patente_Update");
			//myDatabase.AddInParameter(myCommand, "@IdPatente", DbType.String, _object.IdFamiliaElement);
			//myDatabase.AddInParameter(myCommand, "@Nombre", DbType.String, _object.Nombre);
			//myDatabase.ExecuteNonQuery(myCommand);
		}

		/// <summary>
		/// inserta una patente
		/// </summary>
		/// <param name="_object">patente</param>
		public static void Insert(Entities.UFP.Patente _object)
		{
			using (SqlConnection conn = ConnectionBD.Instance().Conect())
			{
				using (SqlCommand cmd = new SqlCommand("Patente_Insert @IdPatente, @Nombre", conn))
				{
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@IdPatente", _object.IdFamiliaElement);
					cmd.Parameters.AddWithValue("@Nombre", _object.Nombre);

					conn.Open();
					cmd.ExecuteNonQuery();
				}
			}
			//Database myDatabase = DatabaseFactory.CreateDatabase();
			//DbCommand myCommand = myDatabase.GetStoredProcCommand("Patente_Insert");
			//myDatabase.AddInParameter(myCommand, "@IdPatente", DbType.String, _object.IdFamiliaElement);
			//myDatabase.AddInParameter(myCommand, "@Nombre", DbType.String, _object.Nombre);
			//myDatabase.ExecuteNonQuery(myCommand);
		}

	}
}
