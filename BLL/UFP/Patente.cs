using DAL.UFP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UFP
{
	/// <summary>
	/// bll patente
	/// </summary>
	public class Patente
	{
		/// <summary>
		/// retorna lista de todas las patentes
		/// </summary>
		/// <returns>List patente</returns>
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

		/// <summary>
		/// retorna una entidad de patente
		/// </summary>
		/// <param name="IdFamiliaElement">string</param>
		/// <returns>Patente</returns>
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

		/// <summary>
		/// llama a dal para insertar una patentes
		/// </summary>
		/// <param name="_object">patente</param>
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

		/// <summary>
		/// llama a dal par acturalizar una patente
		/// </summary>
		/// <param name="_object">patente</param>
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

		/// <summary>
		/// llama a dal para eliminar una patente
		/// </summary>
		/// <param name="_object">patente</param>
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
