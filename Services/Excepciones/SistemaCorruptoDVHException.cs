using Entities.EntidadesDigitoVerificador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Excepciones
{
    public class SistemaCorruptoDVHException : Exception
    {
        public string Error { get; set; }
        public List<EntityDVHcorrupto> Afectadas { get; set; }

        public SistemaCorruptoDVHException(List<EntityDVHcorrupto> _Afectadas)
        {            
            this.Afectadas = _Afectadas;
        }

        public string CargarEntidadesParaMostrar(SistemaCorruptoDVHException ex, string _error)
        {
            Error = _error;
            string entidades = "";

            foreach (var i in ex.Afectadas)
            {
                if (i.status == ConstantesTexto.Corrupto)
                {
                    entidades += i.tabla + " " + "ID: ";

                    foreach (var f in i.filas)
                    {
                        entidades += f.ToString() + " ";
                    }
                    entidades += "\n";
                }
            }

            return entidades;
        }
    }
}
