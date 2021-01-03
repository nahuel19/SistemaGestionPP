using DAL;
using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Doc_detalle_ingresoBLL
    {
        
        Doc_detalle_ingresoDAL doc_det_ingrDAL = new Doc_detalle_ingresoDAL();

        public Doc_detalle_ingreso GetById(int id)
        {
            return doc_det_ingrDAL.GetById(id);
        }

        public IEnumerable<Doc_detalle_ingreso> List()
        {
            return doc_det_ingrDAL.List();
        }

        public void Insert(Doc_detalle_ingreso entity)
        {
            doc_det_ingrDAL.Insert(entity);

        }

        public void Update(Doc_detalle_ingreso entity)
        {
            doc_det_ingrDAL.Update(entity);
        }

        public void Delete(int id)
        {
            doc_det_ingrDAL.Delete(id);
        }

    }
}
