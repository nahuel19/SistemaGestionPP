using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UFP.Adapters
{
	/// <summary>
	/// familia collection adapter
	/// </summary>
	internal class FamiliaCollectionAdapter
	{

		private DataTable datosDT;

		public FamiliaCollectionAdapter(DataTable datosDT)
		{
			this.datosDT = datosDT;
		}

		/// <summary>
		/// llena las familias de una lista de familias, con los componentes que le correspondan
		/// </summary>
		/// <param name="collection"></param>
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
