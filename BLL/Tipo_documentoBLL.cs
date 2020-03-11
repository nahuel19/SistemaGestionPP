using DAL;
using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Tipo_documentoBLL
    {
        Tipo_documentoDAL tipo_docDAL = new Tipo_documentoDAL();

        public Tipo_documento GetById(int id)
        {
            return tipo_docDAL.GetById(id);
        }

        public IEnumerable<Tipo_documento> List()
        {
            return tipo_docDAL.List();
        }

        public void Insert(Tipo_documento entity)
        {
            tipo_docDAL.Insert(entity);

        }

        public void Update(Tipo_documento entity)
        {
            tipo_docDAL.Update(entity);
        }

        public void Delete(int id)
        {
            tipo_docDAL.Delete(id);
        }
    }
}
