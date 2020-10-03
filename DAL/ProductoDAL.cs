using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductoDAL
    {
        dbGestionPP context = new dbGestionPP();

        public Producto GetById(int? id)
        {
            return context.Producto.Find(id);
        }

        public IEnumerable<Producto> List()
        {
            return context.Producto.ToList();
        }

        public void Insert(Producto entity)
        {
            context.Producto.Add(entity);
            context.SaveChanges();
        }

        public void Update(Producto entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int? id)
        {
            Producto producto = context.Producto.Find(id);
            context.Producto.Remove(producto);
            context.SaveChanges();
        }
    }
}
