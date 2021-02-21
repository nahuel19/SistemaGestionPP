using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.UFP
{
    public abstract class FamiliaElement
    {
        public FamiliaElement()
        {
            IdFamiliaElement = Guid.NewGuid().ToString();
        }

        public abstract void Add(FamiliaElement d);

        public abstract void Remove(FamiliaElement d);

        public abstract int ChildrenCount { get; }

        public string Nombre { get; set; }

        public string IdFamiliaElement { get; set; }

    }
}
