using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UFP.Adapters
{
	/// <summary>
	/// familia adapter
	/// </summary>
	internal class FamiliaAdapter
	{

		private DataRow row;

		public FamiliaAdapter(DataRow row)
		{
			this.row = row;
		}

		/// <summary>
		/// llena una familia con los componentes que puea tener
		/// </summary>
		/// <param name="_object">familia</param>
		public void Fill(Entities.UFP.Familia _object)
		{
			_object.IdFamiliaElement = (System.String)row["IdFamilia"];

			_object.Nombre = (System.String)row["Nombre"];

			//Traigo accesos de familia
			DataTable relacionesFamilia = Familia.GetAccesos(_object.IdFamiliaElement);

			foreach (DataRow rowAccesos in relacionesFamilia.Rows)
			{
				_object.Add(FamiliaFacade.GetAdapted((System.String)rowAccesos["IdFamiliaHijo"]));
			}

			//Traigo accesos de patentes
			DataTable relacionesPatentes = Familia_Patente.GetAccesos(_object.IdFamiliaElement);

			foreach (DataRow rowAccesos in relacionesPatentes.Rows)
			{
				_object.Add(PatenteFacade.GetAdapted((System.String)rowAccesos["IdPatente"]));
			}

		}
	}
}
