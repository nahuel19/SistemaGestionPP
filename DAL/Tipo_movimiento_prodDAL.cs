using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Tipo_movimiento_prodDAL : IDAL<Tipo_movimiento_prod>
    {
        dbGestionPP context = dbGestionPP.Instance();

        public Tipo_movimiento_prod GetById(int id)
        {
            return context.Tipo_movimiento_prod.Find(id);
        }

        public IEnumerable<Tipo_movimiento_prod> List()
        {
            return context.Tipo_movimiento_prod.ToList();
        }

        public void Insert(Tipo_movimiento_prod entity)
        {
            context.Tipo_movimiento_prod.Add(entity);
            context.SaveChanges();
        }

        public void Update(Tipo_movimiento_prod entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Tipo_movimiento_prod tipo_movimiento_prod = context.Tipo_movimiento_prod.Find(id);
            context.Tipo_movimiento_prod.Remove(tipo_movimiento_prod);
            context.SaveChanges();
        }
    }
}
