using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UFP.Adapters
{
	/// <summary>
	/// patente collection adapter
	/// </summary>
	internal class PatenteCollectionAdapter
	{

		private DataTable datosDT;

		public PatenteCollectionAdapter(DataTable datosDT)
		{
			this.datosDT = datosDT;
		}

		/// <summary>
		/// llena una lista de patentes, con sus datos, a partir de una datatable
		/// </summary>
		/// <param name="collection">lis patentes</param>
		public void Fill(List<Entities.UFP.Patente> collection)
		{
			foreach (DataRow row in datosDT.Rows)
			{
				Entities.UFP.Patente _object = new Entities.UFP.Patente();
				PatenteAdapter adapter = new PatenteAdapter(row);
				adapter.Fill(_object);
				collection.Add(_object);
			}
		}
	}
}
