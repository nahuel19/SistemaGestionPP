using DAL;
using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Movimiento_productoBLL
    {
        Movimiento_productoDAL movimiento_productoDAL = new Movimiento_productoDAL();

        public Movimiento_producto GetById(int id)
        {
            return movimiento_productoDAL.GetById(id);
        }

        public IEnumerable<Movimiento_producto> List()
        {
            return movimiento_productoDAL.List();
        }

        public void Insert(Movimiento_producto entity)
        {
            movimiento_productoDAL.Insert(entity);

        }

        public void Update(Movimiento_producto entity)
        {
            movimiento_productoDAL.Update(entity);
        }

        public void Delete(int id)
        {
            movimiento_productoDAL.Delete(id);
        }
    }
}
