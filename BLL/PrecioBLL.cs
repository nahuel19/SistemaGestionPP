using DAL;
using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PrecioBLL
    {
        
        PrecioDAL precioDAL = new PrecioDAL();
        

        public Precio GetById(int id)
        {
            return precioDAL.GetById(id);
        }

        public IEnumerable<Precio> List()
        {
            return precioDAL.List();
        }

        public void Insert(Precio entity)
        {
            precioDAL.Insert(entity);

        }

        public void Update(Precio entity)
        {
            precioDAL.Update(entity);
        }

        public void Delete(int id)
        {
            precioDAL.Delete(id);
        }

    }
}
