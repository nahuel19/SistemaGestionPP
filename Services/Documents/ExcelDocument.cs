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
    public class ExcelDocument : DocumentAbstract
    {
        protected override void Create(DataTable dt, string path, string file, string text)
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
