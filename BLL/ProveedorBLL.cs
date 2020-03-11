using DAL;
using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProveedorBLL
    {
        ProveedorDAL proveedorDAL = new ProveedorDAL();

        public Proveedor GetById(int id)
        {
            return proveedorDAL.GetById(id);
        }

        public IEnumerable<Proveedor> List()
        {
            return proveedorDAL.List();
        }

        public void Insert(Proveedor entity)
        {
            proveedorDAL.Insert(entity);

        }

        public void Update(Proveedor entity)
        {
            proveedorDAL.Update(entity);
        }

        public void Delete(int id)
        {
            proveedorDAL.Delete(id);
        }
    }
}
