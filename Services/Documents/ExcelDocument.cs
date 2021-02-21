using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Documents
{
    /// <summary>
    /// Hereda de DoccmentAbstract para hacer override del metodo template
    /// </summary>
    public class ExcelDocument : DocumentAbstract
    {
        /// <summary>
        /// Override de Create, recibe dataTable y lo exporta a excel
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="path">String</param>
        /// <param name="file">String</param>
        /// <param name="text">String</param>
        protected override void Create(DataTable dt, string path, string file, Dictionary<string, string> dataExtra)
        {
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }

            SLDocument doc = new SLDocument();
            doc.ImportDataTable(1, 1, dt, true);
            doc.SaveAs(Path.Combine(path, file));           
        }
    }
}
