using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UFP
{
	/// <summary>
	/// facade de usuario, utiliza dal de usuario, usuario adapter y usuario collection adapter
	/// </summary>
	public class UsuarioFacade
	{
		/// <summary>
		/// devuelve todos los usuarios con los permisos
		/// </summary>
		/// <returns>list usuario</returns>
		public static List<Entities.UFP.Usuario> GetAllAdapted()
		{
			try
			{
				Adapters.UsuarioCollectionAdapter adapter = new Adapters.UsuarioCollectionAdapter(SelectAll());
				List<Entities.UFP.Usuario> collection = new List<Entities.UFP.Usuario>();
				adapter.Fill(collection);
				return collection;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// devuelve un usuario con los permisos
		/// </summary>
		/// <param name="IdUsuario">string</param>
		/// <returns>usuario</returns>
		public static Entities.UFP.Usuario GetAdapted(System.String IdUsuario)
		{
			try
			{
				Adapters.UsuarioAdapter adapter = new Adapters.UsuarioAdapter(Select(IdUsuario));
				Entities.UFP.Usuario _object = new Entities.UFP.Usuario();
				adapter.Fill(_object);
				return _object;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// inserta un usuario
		/// </summary>
		/// <param name="_object">usuario</param>
		public static void Insert(Entities.UFP.Usuario _object)
		{
			try
			{
				Usuario.Insert(_object);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// actualiza un usuario
		/// </summary>
		/// <param name="_object">usuario</param>
		public static void Update(Entities.UFP.Usuario _object)
		{
			try
			{
				Usuario.Update(_object);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// elimina un usuario
		/// </summary>
		/// <param name="_object">usuario</param>
		public static void Delete(Entities.UFP.Usuario _object)
		{
			try
			{
				Usuario.Delete(_object);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static DataRow Select(System.String IdUsuario)
		{
			try
			{
				return Usuario.Select(IdUsuario).Tables[0].Rows[0];
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static DataTable SelectAll()
		{
			try
			{
				return Usuario.SelectAll().Tables[0];
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// elimina familias de un usuario
		/// </summary>
		/// <param name="_object">usuario</param>
		public static void DeleteFamilias(Entities.UFP.Usuario _object)
		{
			try
			{
				Usuario.DeleteFamilias(_object);
			}
			catch (Exception ex)
			{				
				throw ex;
			}
		}

		/// <summary>
		/// elimina patentes de un usuario
		/// </summary>
		/// <param name="_object">usuario</param>
		public static void DeletePatentes(Entities.UFP.Usuario _object)
		{
			try
			{
				Usuario.DeletePatentes(_object);
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw ex;
			}
		}


		/// <summary>
		/// valida ingreso de un usuario
		/// </summary>
		/// <param name="_object">usuario</param>
		/// <returns>bool, string idusuario</returns>
		public static (bool,string) Login(Entities.UFP.Usuario _object)
        {
			try
			{
				return Usuario.Login(_object);
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw ex;
			}
		}
	}
}
