using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Doc_detalle_ingresoDAL : IDAL<Doc_detalle_ingreso>
    {
        dbGestionPP context = dbGestionPP.Instance();

        public Doc_detalle_ingreso GetById(int id)
        {
            return context.Doc_detalle_ingreso.Find(id);
        }

        public IEnumerable<Doc_detalle_ingreso> List()
        {
            return context.Doc_detalle_ingreso.ToList();
        }

        public void Insert(Doc_detalle_ingreso entity)
        {
            context.Doc_detalle_ingreso.Add(entity);
            context.SaveChanges();
        }

        public void Update(Doc_detalle_ingreso entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Doc_detalle_ingreso doc_detalle_ingreso = context.Doc_detalle_ingreso.Find(id);
            context.Doc_detalle_ingreso.Remove(doc_detalle_ingreso);
            context.SaveChanges();
        }
    }
}
