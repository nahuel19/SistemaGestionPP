using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Helps
{
    public interface IContractForm<T> 
    {
        void Ejecutar(T entity);
    }
}
