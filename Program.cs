using XMLProcessing;
using HTMLGeneration;
using PDFGeneration;
using Utils;

namespace XMLToPDFApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string xmlDirectory = @"C:\Caminho\Para\Seu\Diretorio";
            string outputDirectory = @"C:\Caminho\Para\DiretorioDeSaida";

            var xmlFiles = FileManager.GetFiles(xmlDirectory, "*.xml");

            foreach (var xmlFile in xmlFiles)
            {
                var xmlData = XMLParser.Parse(xmlFile);

                string htmlContent = HTMLGenerator.Generate(xmlData);

                byte[] pdfBytes = PDFGenerator.Generate(htmlContent);

                string pdfFilePath = $"{outputDirectory}\\{System.IO.Path.GetFileNameWithoutExtension(xmlFile)}.pdf";
                FileManager.SaveFile(pdfBytes, pdfFilePath);
            }

            Console.WriteLine("Processo concluído.");
        }
    }
}
