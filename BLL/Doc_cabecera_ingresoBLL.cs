using DAL;
using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Doc_cabecera_ingresoBLL
    {       
        Doc_cabecera_ingresoDAL doc_cab_ingrDAL = new Doc_cabecera_ingresoDAL();

        public Doc_cabecera_ingreso GetById(int id)
        {
            return doc_cab_ingrDAL.GetById(id);
        }

        public IEnumerable<Doc_cabecera_ingreso> List()
        {
            return doc_cab_ingrDAL.List();
        }

        public void Insert(Doc_cabecera_ingreso entity)
        {
            doc_cab_ingrDAL.Insert(entity);

        }

        public void Update(Doc_cabecera_ingreso entity)
        {
            doc_cab_ingrDAL.Update(entity);
        }

        public void Delete(int id)
        {
            doc_cab_ingrDAL.Delete(id);
        }

    }
}
