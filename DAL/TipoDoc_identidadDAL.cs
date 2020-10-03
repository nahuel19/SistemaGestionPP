using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TipoDoc_identidadDAL
    {
        dbGestionPP context = new dbGestionPP();

        public TipoDoc_identidad GetById(int? id)
        {
            return context.TipoDoc_identidad.Find(id);
        }

        public IEnumerable<TipoDoc_identidad> List()
        {
            return context.TipoDoc_identidad.ToList();
        }

        public void Insert(TipoDoc_identidad entity)
        {
            context.TipoDoc_identidad.Add(entity);
            context.SaveChanges();
        }

        public void Update(TipoDoc_identidad entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int? id)
        {
            TipoDoc_identidad tipoDoc_identidad = context.TipoDoc_identidad.Find(id);
            context.TipoDoc_identidad.Remove(tipoDoc_identidad);
            context.SaveChanges();
        }
    }
}
