using DAL;
using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductoBLL
    {
        ProductoDAL prodDAL = new ProductoDAL();

        public Producto GetById(int? id)
        {
            return prodDAL.GetById(id);
        }

        public IEnumerable<Producto> List()
        {
            return prodDAL.List();
        }

        public void Insert(Producto entity)
        {
            prodDAL.Insert(entity);

        }

        public void Update(Producto entity)
        {
            prodDAL.Update(entity);
        }

        public void Delete(int? id)
        {
            prodDAL.Delete(id);
        }
    }
}
