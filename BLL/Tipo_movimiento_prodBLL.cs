using DAL;
using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Tipo_movimiento_prodBLL
    {
        Tipo_movimiento_prodDAL tipo_mov_prodDAL = new Tipo_movimiento_prodDAL();

        public Tipo_movimiento_prod GetById(int id)
        {
            return tipo_mov_prodDAL.GetById(id);
        }

        public IEnumerable<Tipo_movimiento_prod> List()
        {
            return tipo_mov_prodDAL.List();
        }

        public void Insert(Tipo_movimiento_prod entity)
        {
            tipo_mov_prodDAL.Insert(entity);

        }

        public void Update(Tipo_movimiento_prod entity)
        {
            tipo_mov_prodDAL.Update(entity);
        }

        public void Delete(int id)
        {
            tipo_mov_prodDAL.Delete(id);
        }
    }
}
