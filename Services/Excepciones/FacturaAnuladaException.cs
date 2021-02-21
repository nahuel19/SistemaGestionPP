using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Excepciones
{
    public class FacturaAnuladaException : Exception
    {
        public string Error { get => "No se puede imprimir una factura anulda"; }
        public string Factura { get; set; }

        public FacturaAnuladaException(string _factura)
        {
            this.Factura = _factura;
        }
    }
}
