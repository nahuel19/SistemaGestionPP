using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UFP
{
	public class FamiliaFacade
	{
		public static List<Entities.UFP.Familia> GetAllAdapted()
		{
			try
			{
				Adapters.FamiliaCollectionAdapter adapter = new Adapters.FamiliaCollectionAdapter(SelectAll());
				List<Entities.UFP.Familia> collection = new List<Entities.UFP.Familia>();
				adapter.Fill(collection);
				return collection;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static Entities.UFP.Familia GetAdapted(System.String IdFamiliaElement)
		{
			try
			{
				Adapters.FamiliaAdapter adapter = new Adapters.FamiliaAdapter(Select(IdFamiliaElement));
				Entities.UFP.Familia _object = new Entities.UFP.Familia();
				adapter.Fill(_object);
				return _object;
			}
			catch (Exception ex)
			{				
				throw ex;
			}
		}

		public static void Insert(Entities.UFP.Familia _object)
		{
			try
			{
				Familia.Insert(_object);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static void Update(Entities.UFP.Familia _object)
		{
			try
			{
				Familia.Update(_object);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static void Delete(Entities.UFP.Familia _object)
		{
			try
			{
				Familia.Delete(_object);
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
				return Familia.Select(IdFamiliaElement).Tables[0].Rows[0];
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
				return Familia.SelectAll().Tables[0];
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static void DeleteAccesos(Entities.UFP.Familia _object)
		{
			try
			{
				Familia.DeleteAccesos(_object);
			}
			catch (Exception ex)
			{				
				throw ex;
			}
		}
	}
}
