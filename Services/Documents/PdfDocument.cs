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
    public class PdfDocument : DocumentAbstract
    {
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


        public void pdf(DataTable dt, string txt)
        {       
                Document document = new Document();


                // Path.Combine(ruta, zipNombre);
                string nombreArchivo = "pruab.pdf";
                string ruta = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["rutaPdfs"].ToString());

                string path = Path.Combine(ruta, nombreArchivo);

                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
                writer.PageEvent = new ITextEvents();

                document.Open();

                iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 10);
                iTextSharp.text.Font font6 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);
                iTextSharp.text.Font fontG = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 15);
                document.Add(new ITextEvents().getHeader("titulo"));
                document.Add(Chunk.NEWLINE);               

                PdfPTable table = new PdfPTable(dt.Columns.Count);
                table.HeaderRows = 1;
                //float[] widths = new float[] { 1f/*, 1f, 1f */};
                //table.SetWidths(widths);
                table.WidthPercentage = 20;
                table.DefaultCell.Border = 0;

                PdfPCell cell = new PdfPCell(new Phrase("items"));

                cell.Colspan = dt.Columns.Count;

            foreach (DataColumn c in dt.Columns)
            {
                PdfPCell _cell = new PdfPCell(new Phrase(c.ColumnName, font6));

                _cell.HorizontalAlignment = Element.ALIGN_CENTER;
                //_cell.VerticalAlignment = Element.ALIGN_MIDDLE;
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
                    if (!String.IsNullOrEmpty(dt.Rows[k][i].ToString()))
                        table.AddCell(new Phrase(dt.Rows[k][i].ToString()));
                }
            }


            //foreach (DataRow r in dt.Rows)
            //{

            //    if (dt.Rows.Count > 0)
            //    {
            //        PdfPCell _cell = new PdfPCell(new Phrase(r[], font6));

            //        _cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //        //_cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //        _cell.BorderWidthRight = 0;
            //        _cell.BorderWidthTop = 0;
            //        _cell.BorderWidthLeft = 0;
            //        table.AddCell(_cell);

            //    }
            //}

            //agrego tabla al pdf y cierro doc
            document.Add(table);

            document.Add(Chunk.NEWLINE);
            document.Close();

          
            
           

        }



    }
}
