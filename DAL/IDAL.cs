using ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL<Entity> where Entity : IEntityBase
    {
        Entity GetById(int id);
        IEnumerable<Entity> List();
        void Insert(Entity entity);
        void Update(Entity entity);
        void Delete(int id);

    }
}
