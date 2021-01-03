using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClienteDAL : IDAL<Cliente>
    {
        dbGestionPP context = dbGestionPP.Instance();

        public Cliente GetById(int id)
        {
            return context.Cliente.Find(id);
        }

        public IEnumerable<Cliente> List()
        {
            return context.Cliente.ToList();
        }

        public void Insert(Cliente entity)
        {
            context.Cliente.Add(entity);
            context.SaveChanges();
        }

        public void Update(Cliente entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Cliente cliente = context.Cliente.Find(id);
            context.Cliente.Remove(cliente);
            context.SaveChanges();
        }
    }
}
