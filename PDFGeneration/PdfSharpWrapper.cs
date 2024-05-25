using System.IO;
using PdfSharp.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace PDFGeneration
{
    public static class PdfSharpWrapper
    {
        public static byte[] ConvertHtmlToPdf(string htmlContent)
        {
            var pdfDocument = PdfGenerator.GeneratePdf(htmlContent, PdfSharp.PageSize.A4);
            using (var stream = new MemoryStream())
            {
                pdfDocument.Save(stream, false);
                return stream.ToArray();
            }
        }
    }
}
