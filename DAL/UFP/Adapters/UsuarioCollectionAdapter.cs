using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UFP.Adapters
{
	/// <summary>
	/// usuario collection adapter
	/// </summary>
	internal class UsuarioCollectionAdapter
	{

		private DataTable datosDT;

		public UsuarioCollectionAdapter(DataTable datosDT)
		{
			this.datosDT = datosDT;
		}

		/// <summary>
		/// llena una lista de usuarios con sus datos y familias y patentes que tenga cada uno
		/// </summary>
		/// <param name="collection"></param>
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
