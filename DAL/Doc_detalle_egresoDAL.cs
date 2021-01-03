using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Doc_detalle_egresoDAL : IDAL<Doc_detalle_egreso>
    {
        dbGestionPP context = dbGestionPP.Instance();

        public Doc_detalle_egreso GetById(int id)
        {
            return context.Doc_detalle_egreso.Find(id);
        }

        public IEnumerable<Doc_detalle_egreso> List()
        {
            return context.Doc_detalle_egreso.ToList();
        }

        public void Insert(Doc_detalle_egreso entity)
        {
            context.Doc_detalle_egreso.Add(entity);
            context.SaveChanges();
        }

        public void Update(Doc_detalle_egreso entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Doc_detalle_egreso doc_detalle_egreso = context.Doc_detalle_egreso.Find(id);
            context.Doc_detalle_egreso.Remove(doc_detalle_egreso);
            context.SaveChanges();
        }
    }
}
