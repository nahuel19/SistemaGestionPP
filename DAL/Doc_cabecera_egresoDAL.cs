using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Doc_cabecera_egresoDAL : IDAL<Doc_cabecera_egreso>
    {
        dbGestionPP context = dbGestionPP.Instance();

        public Doc_cabecera_egreso GetById(int id)
        {
            return context.Doc_cabecera_egreso.Find(id);
        }

        public IEnumerable<Doc_cabecera_egreso> List()
        {
            return context.Doc_cabecera_egreso.ToList();
        }

        public void Insert(Doc_cabecera_egreso entity)
        {
            context.Doc_cabecera_egreso.Add(entity);
            context.SaveChanges();
        }

        public void Update(Doc_cabecera_egreso entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Doc_cabecera_egreso doc_cabecera_egreso = context.Doc_cabecera_egreso.Find(id);
            context.Doc_cabecera_egreso.Remove(doc_cabecera_egreso);
            context.SaveChanges();
        }
    }
}
