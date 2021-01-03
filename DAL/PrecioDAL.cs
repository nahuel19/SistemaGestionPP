using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PrecioDAL : IDAL<Precio>
    {
        
        #region db access methods
        dbGestionPP context = dbGestionPP.Instance();

        public Precio GetById(int id)
        {
            return context.Precio.Find(id);
            
        }

        public IEnumerable<Precio> List()
        {
            return context.Precio.ToList();
        }

        public void Insert(Precio entity)
        {
            context.Precio.Add(entity);
            context.SaveChanges();
        }

        public void Update(Precio entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Precio precio = context.Precio.Find(id);
            context.Precio.Remove(precio);
            context.SaveChanges();
        }
        #endregion
    }
}
