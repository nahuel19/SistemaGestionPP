using DAL;
using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Clase de negocio relacionada a Categoría
    /// </summary>
    public class CategoriaBLL
    {
        CategoriaDAL catDAL = new CategoriaDAL();

        /// <summary>
        /// Llama a método GetById de CategoriaDAL para buscar una Categoria por id
        /// </summary>
        /// <param name="id">inta</param>
        /// <returns>Categoria</returns>
        public Categoria GetById(int id)
        {
            try
            {
                return catDAL.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Llama a método List de CategoriaDAL para listar las Categorias
        /// </summary>
        /// <returns>List Categoria</returns>
        public List<Categoria> List()
        {
            try
            {
                return catDAL.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Llama a método Insert de CategoríaDAL y le pasa una entidad para insertarla en la base
        /// </summary>
        /// <param name="entity">Categoria</param>
        /// <returns>Categoria</returns>
        public Categoria Insert(Categoria entity)
        {
            int errorExiste = 0;

            try
            {
                entity = catDAL.Insert(entity); ;
                return entity;
            }
            catch (Exception ex)
            {
                System.Data.SqlClient.SqlException sqlException = ex as System.Data.SqlClient.SqlException;
                errorExiste = sqlException.Number;

                if (errorExiste == Convert.ToInt32(ConfigurationManager.AppSettings["existe"]))
                    throw new Exception(EValidaciones.existe);
                else
                    throw ex;
            }
        }

        /// <summary>
        /// Llama a método Update de CategoríaDAL y le pasa una entidad para actualizarla en la base
        /// </summary>
        /// <param name="entity">Categoria</param>
        public void Update(Categoria entity)
        {
            int errorExiste = 0;

            try
            {
                catDAL.Update(entity);
            }
            catch (Exception ex)
            {
                System.Data.SqlClient.SqlException sqlException = ex as System.Data.SqlClient.SqlException;
                errorExiste = sqlException.Number;

                if (errorExiste == Convert.ToInt32(ConfigurationManager.AppSettings["existe"]))
                    throw new Exception(EValidaciones.existe);
                else
                    throw ex;
            }
        }

        /// <summary>
        /// Llama a método Delete de CategoríaDAL y le pasa un id para eliminar una categoria en la base
        /// </summary>
        /// <param name="id">int</param>
        public void Delete(int id)
        {
            try
            {
                catDAL.Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }  
        }

        /// <summary>
        /// Llama al método Lista y lo filtra según el parámetro recibido
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>List Categoria </returns>
        public List<Categoria> FindBy(string filter)
        {
            try
            {
                return List().FindAll(x => x.categoria.StartWithIgnoreMM(filter));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
