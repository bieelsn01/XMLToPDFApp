using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace PDFGeneration
{
    public static class PDFGenerator
    {
        public static byte[] Generate(string htmlContent)
        {
            return PdfSharpWrapper.ConvertHtmlToPdf(htmlContent);
        }
    }
}
