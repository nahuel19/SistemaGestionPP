using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UFP.Adapters
{
	internal class UsuarioAdapter
	{

		private DataRow row;

		public UsuarioAdapter(DataRow row)
		{
			this.row = row;
		}

		public void Fill(Entities.UFP.Usuario _object)
		{
			_object.IdUsuario = String.IsNullOrEmpty(row["IdUsuario"].ToString()) ? null : row["IdUsuario"].ToString();
			_object.Nombre = String.IsNullOrEmpty(row["Nombre"].ToString()) ? null : row["Nombre"].ToString();
			_object.Pass = String.IsNullOrEmpty(row["Pass"].ToString()) ? null : row["Pass"].ToString();

			DataTable relacionesFamilia = Usuario.GetFamilias(_object.IdUsuario);

			foreach (DataRow rowPermisos in relacionesFamilia.Rows)
			{
				Entities.UFP.FamiliaElement Permisos = FamiliaFacade.GetAdapted((System.String)rowPermisos["IdFamilia"]);
				_object.Permisos.Add(Permisos);
			}

			DataTable relacionesPatente = Usuario.GetPatentes(_object.IdUsuario);

			foreach (DataRow rowPermisos in relacionesPatente.Rows)
			{
				Entities.UFP.FamiliaElement Permisos = PatenteFacade.GetAdapted((System.String)rowPermisos["IdPatente"]);
				_object.Permisos.Add(Permisos);
			}

		}
	}
}
