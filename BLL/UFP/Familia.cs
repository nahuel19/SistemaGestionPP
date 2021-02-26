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
	/// BLL familia
	/// </summary>
	public class Familia
	{

		/// <summary>
		/// Lista todas las familias
		/// </summary>
		/// <returns>list familias</returns>
		public static List<Entities.UFP.Familia> GetAllAdapted()
		{
			try
			{
				return FamiliaFacade.GetAllAdapted();
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
			}
		}

		/// <summary>
		/// Retorna una familia
		/// </summary>
		/// <param name="IdFamiliaElement">string</param>
		/// <returns>familia</returns>
		public static Entities.UFP.Familia GetAdapted(System.String IdFamiliaElement)
		{
			try
			{
				return FamiliaFacade.GetAdapted(IdFamiliaElement);
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
			}
		}

		/// <summary>
		/// llama a dal para insertar una familia
		/// </summary>
		/// <param name="_object">familia</param>
		public static void Insert(Entities.UFP.Familia _object)
		{
			try
			{
				FamiliaFacade.Insert(_object);
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
			}
		}

		/// <summary>
		/// llama a dal para actualizar una familia
		/// </summary>
		/// <param name="_object">familia</param>
		public static void Update(Entities.UFP.Familia _object)
		{
			try
			{
				FamiliaFacade.Update(_object);
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
			}
		}

		/// <summary>
		/// llama a dal para eliminar una familia
		/// </summary>
		/// <param name="_object"></param>
		public static void Delete(Entities.UFP.Familia _object)
		{
			try
			{
				FamiliaFacade.Delete(_object);
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
				return FamiliaFacade.Select(IdFamiliaElement);
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
				return FamiliaFacade.SelectAll();
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
			}
		}

		/// <summary>
		/// elimina los accesos de una familia
		/// </summary>
		/// <param name="_object">familia</param>
		public static void DeleteAccesos(Entities.UFP.Familia _object)
		{
			try
			{
				FamiliaFacade.DeleteAccesos(_object);
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
			}
		}
	}
}
