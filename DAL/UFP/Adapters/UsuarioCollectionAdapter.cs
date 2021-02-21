using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UFP.Adapters
{
	internal class UsuarioCollectionAdapter
	{

		private DataTable datosDT;

		public UsuarioCollectionAdapter(DataTable datosDT)
		{
			this.datosDT = datosDT;
		}

		public void Fill(List<Entities.UFP.Usuario> collection)
		{
			foreach (DataRow row in datosDT.Rows)
			{
				Entities.UFP.Usuario _object = new Entities.UFP.Usuario();
				UsuarioAdapter adapter = new UsuarioAdapter(row);
				adapter.Fill(_object);
				collection.Add(_object);
			}
		}
	}
}
