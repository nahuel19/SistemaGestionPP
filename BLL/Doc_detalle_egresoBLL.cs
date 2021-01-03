using DAL;
using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Doc_detalle_egresoBLL
    {        
        Doc_detalle_egresoDAL doc_det_egrDAL = new Doc_detalle_egresoDAL();

        public Doc_detalle_egreso GetById(int id)
        {
            return doc_det_egrDAL.GetById(id);
        }

        public IEnumerable<Doc_detalle_egreso> List()
        {
            return doc_det_egrDAL.List();
        }

        public void Insert(Doc_detalle_egreso entity)
        {
            doc_det_egrDAL.Insert(entity);

        }

        public void Update(Doc_detalle_egreso entity)
        {
            doc_det_egrDAL.Update(entity);
        }

        public void Delete(int id)
        {
            doc_det_egrDAL.Delete(id);
        }

    }
}
