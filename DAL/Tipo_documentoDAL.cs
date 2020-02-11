using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Tipo_documentoDAL
    {
        dbGestionPP context = new dbGestionPP();

        public Tipo_documento GetById(int id)
        {
            return context.Tipo_documento.Find(id);
        }

        public IEnumerable<Tipo_documento> List()
        {
            return context.Tipo_documento.ToList();
        }

        public void Insert(Tipo_documento entity)
        {
            context.Tipo_documento.Add(entity);
            context.SaveChanges();
        }

        public void Update(Tipo_documento entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Tipo_documento tipo_documento = context.Tipo_documento.Find(id);
            context.Tipo_documento.Remove(tipo_documento);
            context.SaveChanges();
        }
    }
}
