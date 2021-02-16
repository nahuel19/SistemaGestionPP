using Entities.EntidadesDigitoVerificador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Excepciones
{
    public class SistemaCorruptoDVVException : Exception
    {
        public string Error { get; set; }
        public List<EntityDVVcorrupto> Entidades { get; set; }

        public SistemaCorruptoDVVException(List<EntityDVVcorrupto> _tablas)
        {
            this.Entidades = _tablas;
        }

        public string CargarEntidadesParaMostrar(SistemaCorruptoDVVException ex, string _error)
        {
            Error = _error;
            string entidades = "";

            foreach (var i in ex.Entidades)
            {
                if (i.status == ConstantesTexto.Corrupto)
                {
                    entidades += i.tabla + "\n";
                }
            }

            return entidades;
        }
    }
}
