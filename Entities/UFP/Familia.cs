using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.UFP
{
    public class Familia : FamiliaElement
    {
        private List<FamiliaElement> _accesos = new List<FamiliaElement>();
        
        
        public Familia()
        {

        }

        public override void Add(FamiliaElement d)
        {
            _accesos.Add(d);
        }

        public override void Remove(FamiliaElement d)
        {
            
            _accesos.RemoveAll(x => x.IdFamiliaElement == d.IdFamiliaElement);
            //_accesos.Remove(d);
        }

        public List<FamiliaElement> Accesos
        {
            get
            {
                return _accesos;
            }
            set
            {
                _accesos = value;
            }
        }


        public override int ChildrenCount
        {
            get
            {
                return _accesos.Count;
            }
        }
    }
}
