using DAL;
using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClienteBLL
    {
        ClienteDAL cliDAL = new ClienteDAL();

        public Cliente GetById(int id)
        {
            return cliDAL.GetById(id);
        }

        public IEnumerable<Cliente> List()
        {
            return cliDAL.List();
        }

        public void Insert(Cliente entity)
        {
            cliDAL.Insert(entity);

        }

        public void Update(Cliente entity)
        {
            cliDAL.Update(entity);
        }

        public void Delete(int id)
        {
            cliDAL.Delete(id);
        }
    }
}
