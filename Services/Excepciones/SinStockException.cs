using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Excepciones
{
    public class SinStockException : Exception
    {
        public List<string> productos { get; set; }

        public SinStockException(List<string> list)
        {
            productos = list;
        }

        public string PrepararParaMostrar(List<string> list)
        {
            StringBuilder cadena = new StringBuilder();
            list.ForEach(x => cadena.Append(x.ToString() + "\n"));

            return cadena.ToString();

        }

    }
}


