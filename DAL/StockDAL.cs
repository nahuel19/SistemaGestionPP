using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StockDAL
    {
        dbGestionPP context = new dbGestionPP();

        public Stock GetById(int id)
        {
            return context.Stock.Find(id);
        }

        public IEnumerable<Stock> List()
        {
            return context.Stock.ToList();
        }

        public void Insert(Stock entity)
        {
            context.Stock.Add(entity);
            context.SaveChanges();
        }

        public void Update(Stock entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Stock stock = context.Stock.Find(id);
            context.Stock.Remove(stock);
            context.SaveChanges();
        }
    }
}
