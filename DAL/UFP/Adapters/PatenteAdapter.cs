using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UFP.Adapters
{
	internal class PatenteAdapter
	{

		private DataRow row;

		public PatenteAdapter(DataRow row)
		{
			this.row = row;
		}

		public void Fill(Entities.UFP.Patente _object)
		{
			_object.IdFamiliaElement = (System.String)row["IdPatente"];

			_object.Nombre = (System.String)row["Nombre"];

		}
	}
}
