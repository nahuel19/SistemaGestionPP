using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Services.Documents
{
    public class ITextEvents : PdfPageEventHelper
    {        
        PdfContentByte cb, cbl;

        PdfTemplate footerTemplate, footerTemplateL;

        BaseFont bf = null;
                
        DateTime PrintTime = DateTime.Now;

        #region Fields
        private string _header;
        #endregion

        #region Properties
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }
        #endregion

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                cbl = writer.DirectContent;               
                footerTemplate = cb.CreateTemplate(50, 50);
                footerTemplateL = cbl.CreateTemplate(50, 50);


            }
            catch (DocumentException de)
            {
            }
            catch (System.IO.IOException ioe)
            {
            }
        }

        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            
            string fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm") ;
            String text = fecha + " - Página " + writer.PageNumber + " de ";
            String text2 = "Nota: s.e.u.o.";
            
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(document.PageSize.GetRight(180), document.PageSize.GetBottom(29));
                cb.ShowText(text);
                cb.EndText();

                float len = bf.GetWidthPoint(text, 9);
                cb.AddTemplate(footerTemplate, document.PageSize.GetRight(180) + len, document.PageSize.GetBottom(30));

                cbl.BeginText();
                cbl.SetFontAndSize(bf, 10);
                cbl.SetTextMatrix(document.PageSize.GetLeft(50), document.PageSize.GetBottom(29));
                cbl.ShowText(text2);
                cbl.EndText();

                float lenl = bf.GetWidthPoint(text2, 10);
                cbl.AddTemplate(footerTemplateL, document.PageSize.GetLeft(180) + lenl, document.PageSize.GetBottom(29));
            }

            
        }
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            footerTemplate.BeginText();
            footerTemplate.SetFontAndSize(bf, 9);
            footerTemplate.SetTextMatrix(0, -1);
            footerTemplate.ShowText((writer.PageNumber).ToString());
            footerTemplate.EndText();

        }

        public PdfPTable getHeader(string titulo)
        {
            iTextSharp.text.Font font1 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 15);
            iTextSharp.text.Font font2 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 15);

            PdfPTable tableTitulo = new PdfPTable(2);

            float[] widthsTitulo = new float[] { 10f, 3f };
            tableTitulo.SetWidths(widthsTitulo);
            tableTitulo.WidthPercentage = 100;
            tableTitulo.DefaultCell.Border = 0;

            string rutaImagen = ConfigurationManager.AppSettings["rutaImgLogo"].ToString();
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(rutaImagen);
            imagen.Border = 0;
            imagen.ScaleAbsolute(159f, 60f);

            PdfPCell tilde = new PdfPCell(imagen, true);
            tilde.HorizontalAlignment = Element.ALIGN_RIGHT;
            tilde.FixedHeight = 40f;
            tilde.Border = 0;

            tableTitulo.AddCell(new Paragraph(titulo, font2));
            tableTitulo.AddCell(tilde);
            return tableTitulo;
        }
    }
}
