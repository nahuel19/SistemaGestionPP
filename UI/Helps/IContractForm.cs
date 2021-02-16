using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Helps
{
    /// <summary>
    /// Interface de contrato entre formularios usada para pasar info entre ellos
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public interface IContractForm<T> 
    {
        /// <summary>
        /// Método a sobreescribir para ejecutar las acciones que se necesiten
        /// </summary>
        /// <param name="entity">Entidad genérica</param>
        void Ejecutar(T entity);
    }
}
