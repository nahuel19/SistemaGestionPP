using DAL;
using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoriaBLL
    {
        CategoriaDAL catDAL = new CategoriaDAL();

        public Categoria GetById(int id)
        {
            return catDAL.GetById(id);
        }

        public IEnumerable<Categoria> List()
        {
            return catDAL.List();
        }

        public void Insert(Categoria entity)
        {
            catDAL.Insert(entity);
            
        }

        public void Update(Categoria entity)
        {
            catDAL.Update(entity);
        }

        public void Delete(int id)
        {
            catDAL.Delete(id);   
        }

    }
}
