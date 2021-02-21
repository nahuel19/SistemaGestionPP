using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Documents
{
    /// <summary>
    /// Clase template para documentos
    /// </summary>
    public abstract class DocumentAbstract
    {
        /// <summary>
        /// Método abstracto que se va a sobreescribir para generar el documento, según el tipo de doc.
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="text">string</param>
        /// <returns>string</returns>
        protected abstract void Create(DataTable dt, string path, string file, Dictionary<string, string> dataExtra);

        /// <summary>
        /// Método abstracto que se va a sobreescribir para abrir un archivo a partir de una ruta dada.
        /// </summary>
        /// <param name="path"></param>
        protected void OpenFile(string path, string file)
        {
            Process p = new Process();
            p.StartInfo.FileName = Path.Combine(path,file);
            p.Start();
        }


        /// <summary>
        /// Método template que genera el documento y luego lo abre.
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="text">String</param>
        public void CreateFileTemplate(DataTable dt, string path, string file, Dictionary<string, string> dataExtra)
        {            
            Create(dt, path, file, dataExtra);
            OpenFile(path,file);
        }

       
    }
}
