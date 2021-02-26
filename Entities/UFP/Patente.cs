using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.UFP
{
    /// <summary>
    /// patente
    /// </summary>
    public class Patente : FamiliaElement
    {
        public Patente()
        {

        }

        /// <summary>
        /// agrega elemento, al ser patente no se puede agregar
        /// </summary>
        /// <param name="d"></param>
        public override void Add(FamiliaElement d)
        {
            throw new Exception("No se puede agregar una patente");
        }

        /// <summary>
        /// quita elemto, al ser patente no se puede quitar
        /// </summary>
        /// <param name="d"></param>
        public override void Remove(FamiliaElement d)
        {
            throw new Exception("No se puede quitar una patente");
        }

        public override int ChildrenCount
        {
            get
            {
                return 0;
            }
        }
    }
}
