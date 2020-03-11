using DAL;
using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TipoDoc_identidadBLL
    {
        TipoDoc_identidadDAL tipoDoc_identDAL = new TipoDoc_identidadDAL();

        public TipoDoc_identidad GetById(int id)
        {
            return tipoDoc_identDAL.GetById(id);
        }

        public IEnumerable<TipoDoc_identidad> List()
        {
            return tipoDoc_identDAL.List();
        }

        public void Insert(TipoDoc_identidad entity)
        {
            tipoDoc_identDAL.Insert(entity);

        }

        public void Update(TipoDoc_identidad entity)
        {
            tipoDoc_identDAL.Update(entity);
        }

        public void Delete(int id)
        {
            tipoDoc_identDAL.Delete(id);
        }
    }
}
