using DAL;
using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Doc_cabecera_egresoBLL
    {      
        Doc_cabecera_egresoDAL doc_cab_egrDAL = new Doc_cabecera_egresoDAL();

        public Doc_cabecera_egreso GetById(int id)
        {
            return doc_cab_egrDAL.GetById(id);
        }

        public IEnumerable<Doc_cabecera_egreso> List()
        {
            return doc_cab_egrDAL.List();
        }

        public void Insert(Doc_cabecera_egreso entity)
        {
            doc_cab_egrDAL.Insert(entity);

        }

        public void Update(Doc_cabecera_egreso entity)
        {
            doc_cab_egrDAL.Update(entity);
        }

        public void Delete(int id)
        {
            doc_cab_egrDAL.Delete(id);
        }
    }
}
