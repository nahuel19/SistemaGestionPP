using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProveedorDAL : IDAL<Proveedor>
    {
        dbGestionPP context = dbGestionPP.Instance();

        public Proveedor GetById(int id)
        {
            return context.Proveedor.Find(id);
        }

        public IEnumerable<Proveedor> List()
        {
            return context.Proveedor.ToList();
        }

        public void Insert(Proveedor entity)
        {
            context.Proveedor.Add(entity);
            context.SaveChanges();
        }

        public void Update(Proveedor entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Proveedor proveedor = context.Proveedor.Find(id);
            context.Proveedor.Remove(proveedor);
            context.SaveChanges();
        }
    }
}
