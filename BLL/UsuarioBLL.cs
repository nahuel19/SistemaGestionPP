
using DAL.UFP;
using Entities;
using Services;
using Services.Encriptación;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL
    {
        //UsuarioDAL dal = new UsuarioDAL();

        ///// <summary>
        ///// Llama a método GetById de DAL para buscar un Usuario por id
        ///// </summary>
        ///// <param name="id">inta</param>
        ///// <returns>Usuario</returns>
        //public Usuario GetById(int id)
        //{
        //    Usuario entity = dal.GetById(id);
            
        //    return entity;
        //}

        ///// <summary>
        ///// Llama a método List de UsuarioDAL para listar los Usuarios
        ///// </summary>
        ///// <returns>List Usuario</returns>
        //public List<Usuario> List()
        //{
        //    List<Usuario> list = dal.List();

        //    return list;
        //}

        ///// <summary>
        ///// Llama a método Insert de UsuarioDAL y le pasa una entidad para insertarla en la base
        ///// </summary>
        ///// <param name="entity">Usuario</param>
        ///// <returns>Usuario</returns>
        //public Usuario Insert(Usuario entity)
        //{
            
        //    int errorExiste = 0;

        //    try
        //    {
        //        entity.pass = new CryptoSeguridad().Encrypt(entity.passSinEncriptar);
        //        entity = dal.Insert(entity);
        //        return entity;
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Data.SqlClient.SqlException sqlException = ex as System.Data.SqlClient.SqlException;
        //        errorExiste = sqlException.Number;

        //        if (errorExiste == Convert.ToInt32(ConfigurationManager.AppSettings["existe"]))
        //            throw new Exception(EValidaciones.existe);
        //        else
        //            throw ex;
        //    }

        //}

        ///// <summary>
        ///// Llama a método Update de UsuarioDAL y le pasa una entidad para actualizarla en la base
        ///// </summary>
        ///// <param name="entity">Usuario</param>
        //public void Update(Usuario entity)
        //{
        //    int errorExiste = 0;

        //    try
        //    {
        //        entity.pass = new CryptoSeguridad().Encrypt(entity.passSinEncriptar);
        //        dal.Update(entity);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Data.SqlClient.SqlException sqlException = ex as System.Data.SqlClient.SqlException;
        //        errorExiste = sqlException.Number;

        //        if (errorExiste == Convert.ToInt32(ConfigurationManager.AppSettings["existe"]))
        //            throw new Exception(EValidaciones.existe);
        //        else
        //            throw ex;
        //    }
        //}

        ///// <summary>
        ///// Llama a método Delete de UsuarioDAL y le pasa un id para eliminar una Usuario en la base
        ///// </summary>
        ///// <param name="id">int</param>
        //public void Delete(int id)
        //{
        //    dal.Delete(id);
        //}

        ///// <summary>
        ///// Llama al método Lista y lo filtra según el parámetro recibido
        ///// </summary>
        ///// <param name="filter">string</param>
        ///// <returns>List Usuario</returns>
        //public List<Usuario> FindBy(string filter)
        //{
        //    return List().FindAll(x => x.nombre.StartWithIgnoreMM(filter));
        //}

        //public bool Login (Usuario entity)
        //{
        //    entity.pass = new CryptoSeguridad().Encrypt(entity.passSinEncriptar);
        //    return dal.Login(entity);
        //}

        
    }
}
