using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Movimiento_productoDAL
    {
        dbGestionPP context = new dbGestionPP();

        public Movimiento_producto GetById(int id)
        {
            return context.Movimiento_producto.Find(id);
        }

        public IEnumerable<Movimiento_producto> List()
        {
            return context.Movimiento_producto.ToList();
        }

        public void Insert(Movimiento_producto entity)
        {
            context.Movimiento_producto.Add(entity);
            context.SaveChanges();
        }

        public void Update(Movimiento_producto entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Movimiento_producto movimiento_producto = context.Movimiento_producto.Find(id);
            context.Movimiento_producto.Remove(movimiento_producto);
            context.SaveChanges();
        }
    }
}
