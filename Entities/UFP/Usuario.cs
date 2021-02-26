using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.UFP
{
	/// <summary>
	/// entidad usuario
	/// </summary>
	public class Usuario
	{
		private System.String _idUsuario;
		private System.String _nombre;
		private System.String _pass;
		private List<FamiliaElement> _permisos = new List<FamiliaElement>();

		/// <summary>
		/// constructor
		/// </summary>
		public Usuario()
		{
			_idUsuario = Guid.NewGuid().ToString();
		}

		public System.String IdUsuario
		{
			get
			{
				return _idUsuario;
			}
			set
			{
				_idUsuario = value;
			}
		}
		
		public System.String Nombre
		{
			get
			{
				return _nombre;
			}
			set
			{
				_nombre = value;
			}
		}

		public System.String Pass
		{
			get
			{
				return _pass;
			}
			set
			{
				_pass = value;
			}
		}

		/// <summary>
		/// list de permisos (FamiliaElement)
		/// </summary>
		public List<FamiliaElement> Permisos
		{
			get
			{
				return _permisos;
			}
			set
			{
				_permisos = value;
			}
		}

	}
}
