using DinkToPdf;
using DinkToPdf.Contracts;

namespace PDFGeneration
{
    public static class PDFGenerator
    {
        public static void Generate(string htmlContent, string outputPath)
        {
            var pdfConverter = new SynchronizedConverter(new PdfTools());
            var pdfDocument = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Out = outputPath
                },
                Objects = {
                    new ObjectSettings
                    {
                        PagesCount = true,
                        HtmlContent = htmlContent,
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            pdfConverter.Convert(pdfDocument);
        }
    }
}
