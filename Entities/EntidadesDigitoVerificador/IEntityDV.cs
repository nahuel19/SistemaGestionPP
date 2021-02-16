using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.EntidadesDigitoVerificador
{
    public interface IEntityDV
    {
        int id { get; set; }
        byte[] DVH { get; set; }

    }
}
