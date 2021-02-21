using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UFP
{
	public class UsuarioFacade
	{

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
