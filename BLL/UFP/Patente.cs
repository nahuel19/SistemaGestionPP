using DAL.UFP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UFP
{
	public class Patente
	{

		public static List<Entities.UFP.Patente> GetAllAdapted()
		{
			try
			{
				return PatenteFacade.GetAllAdapted();
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
			}
		}

		public static Entities.UFP.Patente GetAdapted(System.String IdFamiliaElement)
		{
			try
			{
				return PatenteFacade.GetAdapted(IdFamiliaElement);
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
			}
		}

		public static void Insert(Entities.UFP.Patente _object)
		{
			try
			{
				PatenteFacade.Insert(_object);
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
			}
		}

		public static void Update(Entities.UFP.Patente _object)
		{
			try
			{
				PatenteFacade.Update(_object);
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
			}
		}

		public static void Delete(Entities.UFP.Patente _object)
		{
			try
			{
				PatenteFacade.Delete(_object);
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
			}
		}

		public static DataRow Select(System.String IdFamiliaElement)
		{
			try
			{
				return PatenteFacade.Select(IdFamiliaElement);
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
			}
		}

		public static DataTable SelectAll()
		{
			try
			{
				return PatenteFacade.SelectAll();
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
			}
		}
	}
}
