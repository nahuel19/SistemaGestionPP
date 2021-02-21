using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UFP.Adapters
{
	internal class FamiliaCollectionAdapter
	{

		private DataTable datosDT;

		public FamiliaCollectionAdapter(DataTable datosDT)
		{
			this.datosDT = datosDT;
		}

		public void Fill(List<Entities.UFP.Familia> collection)
		{
			foreach (DataRow row in datosDT.Rows)
			{
				Entities.UFP.Familia _object = new Entities.UFP.Familia();
				FamiliaAdapter adapter = new FamiliaAdapter(row);
				adapter.Fill(_object);
				collection.Add(_object);
			}
		}
	}
}
