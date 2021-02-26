using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UFP
{
	/// <summary>
	/// clase fachada de patente, utiliza dal de patente, patente adapter y patenete collection adapter
	/// </summary>
	public class PatenteFacade
	{
		/// <summary>
		/// retorna las patentes
		/// </summary>
		/// <returns>list patente</returns>
		public static List<Entities.UFP.Patente> GetAllAdapted()
		{
			try
			{
				Adapters.PatenteCollectionAdapter adapter = new Adapters.PatenteCollectionAdapter(SelectAll());
				List<Entities.UFP.Patente> collection = new List<Entities.UFP.Patente>();
				adapter.Fill(collection);
				return collection;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// retorna uns patente
		/// </summary>
		/// <param name="IdFamiliaElement"></param>
		/// <returns>patente</returns>
		public static Entities.UFP.Patente GetAdapted(System.String IdFamiliaElement)
		{
			try
			{
				DataRow dr = Select(IdFamiliaElement);

				Adapters.PatenteAdapter adapter = new Adapters.PatenteAdapter(dr);

				//Instancio un objeto patente
				Entities.UFP.Patente _object = new Entities.UFP.Patente();

				adapter.Fill(_object);

				return _object;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// inserta una patente
		/// </summary>
		/// <param name="_object">patente</param>
		public static void Insert(Entities.UFP.Patente _object)
		{
			try
			{
				Patente.Insert(_object);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// actualiza una patente
		/// </summary>
		/// <param name="_object">patente</param>
		public static void Update(Entities.UFP.Patente _object)
		{
			try
			{
				Patente.Update(_object);
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
			try
			{
				Patente.Delete(_object);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static DataRow Select(System.String IdFamiliaElement)
		{
			try
			{
				return Patente.Select(IdFamiliaElement).Tables[0].Rows[0];
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static DataTable SelectAll()
		{
			try
			{
				return Patente.SelectAll().Tables[0];
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
