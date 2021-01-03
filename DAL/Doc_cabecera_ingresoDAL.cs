using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Doc_cabecera_ingresoDAL : IDAL<Doc_cabecera_ingreso>
    {
        dbGestionPP context = dbGestionPP.Instance();

        public Doc_cabecera_ingreso GetById(int id)
        {
            return context.Doc_cabecera_ingreso.Find(id);
        }

        public IEnumerable<Doc_cabecera_ingreso> List()
        {
            return context.Doc_cabecera_ingreso.ToList();
        }

        public void Insert(Doc_cabecera_ingreso entity)
        {
            context.Doc_cabecera_ingreso.Add(entity);
            context.SaveChanges();
        }

        public void Update(Doc_cabecera_ingreso entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Doc_cabecera_ingreso doc_cabecera_ingreso = context.Doc_cabecera_ingreso.Find(id);
            context.Doc_cabecera_ingreso.Remove(doc_cabecera_ingreso);
            context.SaveChanges();
        }
    }
}
