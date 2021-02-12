using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Clase de negocio relacionada a Stock
    /// </summary>
    public class StockBLL
    {
        StockDAL stockDAL = new StockDAL();

        /// <summary>
        /// Llama a método GetById de DAL para buscar un stock de prod por id
        /// </summary>
        /// <param name="id">inta</param>
        /// <returns>Stock</returns>
        public Stock GetById(int id)
        {
            return stockDAL.GetById(id);
        }

        /// <summary>
        /// Llama a método List de StockDAL para listar los Stocks
        /// </summary>
        /// <returns>List Stock</returns>
        public List<Stock> List()
        {
            return stockDAL.List();
        }

        /// <summary>
        /// Llama a método Insert de StockDAL y le pasa una entidad para insertarla en la base
        /// </summary>
        /// <param name="entity">Stock</param>
        /// <returns>Stock</returns>
        public void Insert(Stock entity)
        {
            stockDAL.Insert(entity);

        }

        /// <summary>
        /// Llama a método Update de StockDAL y le pasa una entidad para actualizarla en la base
        /// </summary>
        /// <param name="entity">Stock</param>
        public void Update(Stock entity)
        {
            stockDAL.Update(entity);
        }

        /// <summary>
        /// Llama a método Delete de StockDAL y le pasa un id para eliminar un Stock en la base
        /// </summary>
        /// <param name="id">int</param>
        public void Delete(int id)
        {
            stockDAL.Delete(id);
        }
    }
}
