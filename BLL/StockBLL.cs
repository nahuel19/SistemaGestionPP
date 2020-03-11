using DAL;
using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StockBLL
    {
        StockDAL stockDAL = new StockDAL();

        public Stock GetById(int id)
        {
            return stockDAL.GetById(id);
        }

        public IEnumerable<Stock> List()
        {
            return stockDAL.List();
        }

        public void Insert(Stock entity)
        {
            stockDAL.Insert(entity);

        }

        public void Update(Stock entity)
        {
            stockDAL.Update(entity);
        }

        public void Delete(int id)
        {
            stockDAL.Delete(id);
        }
    }
}
