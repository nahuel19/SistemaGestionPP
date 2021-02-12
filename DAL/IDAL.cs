using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Interface para clases de la DAL
    /// </summary>
    /// <typeparam name="Entity">Entidad genérica</typeparam>
    public interface IDAL<Entity> where Entity : IEntityBase
    {
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entity">Entidad genérica</param>
        /// <returns>Entidad genérica</returns>
        Entity Insert(Entity entity);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity">Entidad genérica</param>
        void Update(Entity entity);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id">int</param>
        void Delete(int id);

        /// <summary>
        /// List de Entidad genérica
        /// </summary>
        /// <returns>Entidad genérica</returns>
        List<Entity> List();

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Entidad genérica</returns>
        Entity GetById(int id);
        
        

    }
}
