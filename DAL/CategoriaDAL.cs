using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using ModeloEntidades;

namespace DAL
{
    public class CategoriaDAL : IDAL<Categoria>
    {
        dbGestionPP context = dbGestionPP.Instance();

        public Categoria GetById(int id)
        {
            return context.Categoria.Find(id);
        }

        public IEnumerable<Categoria> List()
        {
            return context.Categoria.ToList();
        }

        public void Insert(Categoria entity)
        {
            context.Categoria.Add(entity);
            context.SaveChanges();
        }        

        public void Update(Categoria entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Categoria categoria = context.Categoria.Find(id);
            context.Categoria.Remove(categoria);
            context.SaveChanges();
        } 

        
    }
}
