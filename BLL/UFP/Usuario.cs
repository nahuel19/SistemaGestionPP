using DAL.UFP;
using Entities.UFP;
using Services.Cache;
using Services.Encriptación;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UFP
{
	/// <summary>
	/// bll usuario
	/// </summary>
    public class Usuario
    {
		/// <summary>
		/// retorna lista de usuarios
		/// </summary>
		/// <returns>list usuario</returns>
		public static List<Entities.UFP.Usuario> GetAllAdapted()
		{
			try
			{
				return UsuarioFacade.GetAllAdapted();
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
			}
		}

		/// <summary>
		/// retorna un usuario
		/// </summary>
		/// <param name="IdUsuario">string</param>
		/// <returns>usuario</returns>
		public static Entities.UFP.Usuario GetAdapted(System.String IdUsuario)
		{
			try
			{
				return UsuarioFacade.GetAdapted(IdUsuario);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// llama a dal para insertar un usuario
		/// </summary>
		/// <param name="_object">usuario</param>
		public static void Insert(Entities.UFP.Usuario _object)
		{
			try
			{
				_object.Pass = Convert.ToBase64String(new CryptoSeguridad().Encrypt(_object.Pass));
				UsuarioFacade.Insert(_object);
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
			}
		}

		/// <summary>
		/// llama a dal para actualizar un usuario
		/// </summary>
		/// <param name="_object">usuario</param>
		public static void Update(Entities.UFP.Usuario _object)
		{
			try
			{
				UsuarioFacade.Update(_object);
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
			}
		}

		/// <summary>
		/// llama a dal para eliminar un usuario
		/// </summary>
		/// <param name="_object">usuario</param>
		public static void Delete(Entities.UFP.Usuario _object)
		{
			try
			{
				UsuarioFacade.Delete(_object);
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
			}
		}

		public static DataRow Select(System.String IdUsuario)
		{
			try
			{
				return UsuarioFacade.Select(IdUsuario);
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
			}
		}

		public static DataTable SelectAll()
		{
			try
			{
				return UsuarioFacade.SelectAll();
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
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
				UsuarioFacade.DeleteFamilias(_object);
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
			}
		}

		/// <summary>
		/// eliminar patentes de un usuario
		/// </summary>
		/// <param name="_object">usuario</param>
		public static void DeletePatentes(Entities.UFP.Usuario _object)
		{
			try
			{
				UsuarioFacade.DeletePatentes(_object);
			}
			catch (Exception ex)
			{
				//GestorErrores.Execute(ex);
				throw;
			}
		}

		//===================================================================
		/// <summary>
		/// chequea la validez de un usuario, para ver si puede iniciar sesión
		/// </summary>
		/// <param name="_object">usuario</param>
		/// <returns>bool, string(idUsuario)</returns>
		public static (bool,string) Login(Entities.UFP.Usuario _object)
		{
			_object.Pass = Convert.ToBase64String(new CryptoSeguridad().Encrypt(_object.Pass));
			var valid = UsuarioFacade.Login(_object);

			if (valid.Item1)
            {
				Entities.UFP.Usuario user = GetAdapted(valid.Item2);
				LoginCache.idUser = user.IdUsuario;
				LoginCache.nombreUser = user.Nombre;
				LoginCache.permisos = user.Permisos;
			}

			return valid;
		}

		/// <summary>
		/// Dada una lista de familiaElement y un tipo de permiso, valida si el permiso se encuentra en la lista
		/// </summary>
		/// <param name="familia">list familiaElement</param>
		/// <param name="tipoPermiso">tipoPermiso</param>
		/// <returns></returns>
		public static bool ValidarPermiso(List<FamiliaElement> familia, TipoPermiso tipoPermiso)
		{
			bool existe = false;
			foreach (FamiliaElement element in familia)
			{
				if (element.Nombre == tipoPermiso.ToString())
					return true;
				
				if (element.ChildrenCount > 0)
                {
					bool existeEnHijo = false;
					existeEnHijo = ValidarPermiso((element as Entities.UFP.Familia).Accesos, tipoPermiso);


					if (existeEnHijo)
						return true;
				}
			}
			return existe;
		}

		/// <summary>
		/// Devuelve un string con la estructura de permisos, separados con -
		/// </summary>
		/// <param name="familia">lista familiaElement</param>
		/// <param name="nivel">string</param>
		/// <returns>string</returns>
        public static string MostrarEstructura(List<FamiliaElement> familia, String nivel = "-")
        {
            String siguienteNivel = String.Format("{0}-", nivel);
			string estructura = "";

            foreach (FamiliaElement element in familia)
            {
				estructura += nivel + element.GetType().Name +" "+ element.Nombre + "\n";
				//Console.WriteLine(String.Format("{0}{1}: {2}", nivel, element.GetType().Name, element.Nombre));

				if (element.ChildrenCount > 0)
                {
					estructura += MostrarEstructura((element as Entities.UFP.Familia).Accesos, siguienteNivel); 
				}
                    

            }
			return estructura;
        }

        
    }
}
