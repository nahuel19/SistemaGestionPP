using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UFP
{
	/// <summary>
	/// clase facade de familia_patente
	/// </summary>
	public class FamiliaPatenteFacade
	{
		/// <summary>
		/// busca la primer row del datatable de familia patente cuando se selecciona una familia_patente
		/// </summary>
		/// <param name="IdFamiliaElement">string</param>
		/// <returns>data row</returns>
		public static DataRow Select(System.String IdFamiliaElement)
		{
			try
			{
				return Familia_Patente.Select(IdFamiliaElement).Tables[0].Rows[0];
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
