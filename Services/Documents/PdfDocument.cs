using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Services.Documents
{
    /// <summary>
    /// Hereda de DoccmentAbstract para hacer override del metodo template
    /// </summary>
    public class PdfDocument : DocumentAbstract
    {
        /// <summary>
        /// Override de Create, recibe dataTable y lo exporta a PDF
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="path">String</param>
        /// <param name="file">String</param>
        /// <param name="text">String</param>
        protected override void Create(System.Data.DataTable dt, string path, string file, string text)
        {
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }

            Document document = new Document();

            string _path = Path.Combine(path, file);

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(_path, FileMode.Create));
            writer.PageEvent = new ITextEvents();

            document.Open();

            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 9);
            iTextSharp.text.Font font6 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
            iTextSharp.text.Font font8 = iTextSharp.text.FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10);
            document.Add(new ITextEvents().getHeader(ConfigurationManager.AppSettings["NombreEmpresa"]));
            document.Add(Chunk.NEWLINE);
            document.Add(new Phrase(text));
            document.Add(Chunk.NEWLINE);

            Paragraph datos = new Paragraph();
            datos.Alignment = Element.ALIGN_RIGHT;
            datos.Add(new Chunk(ConfigurationManager.AppSettings["TelEmpresa"], font8));
            datos.Add(new Chunk("\n"+ConfigurationManager.AppSettings["DirecEmpresa"], font8));
            document.Add(datos);
            document.Add(Chunk.NEWLINE);

            Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, offset:1)));
            document.Add(line);
            document.Add(Chunk.NEWLINE);
            
            PdfPTable table = new PdfPTable(dt.Columns.Count);
            table.HeaderRows = 1;            
            table.WidthPercentage = 100;
            table.DefaultCell.Border = 0;

            PdfPCell cell = new PdfPCell(new Phrase("items"));

            cell.Colspan = dt.Columns.Count;

            foreach (DataColumn c in dt.Columns)
            {
                PdfPCell _cell = new PdfPCell(new Phrase(c.ColumnName.ToUpper(), font6));

                _cell.HorizontalAlignment = Element.ALIGN_CENTER;               
                _cell.BorderWidthRight = 0;
                _cell.BorderWidthTop = 0;
                _cell.BorderWidthLeft = 0;
                table.AddCell(_cell);
            }


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                table.WidthPercentage = 100;
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    if (!String.IsNullOrEmpty(dt.Rows[i][k].ToString()))
                        table.AddCell(new Phrase(String.IsNullOrEmpty(dt.Rows[i][k].ToString()) ? "" : dt.Rows[i][k].ToString(), font5));
                    else
                        table.AddCell(new Phrase(""));
                }
            }
            
            document.Add(table);

            document.Add(Chunk.NEWLINE);
            document.Close();

        }      


    }
}
