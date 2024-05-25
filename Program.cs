using System;
using System.IO;
using System.Threading.Tasks;
using XMLProcessing;
using HTMLGeneration;
using PDFGeneration;

namespace XMLToPDFApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string templatePath = @"C:\ws-project\Layout NFe\index.html";
            string chNFe = "35110264542918000145553392048039911837511733";
            string apiUrl = "https://gateway.apiserpro.serpro.gov.br/consulta-nfe-df-trial/api/v1/nfe/"; 
            string token = "c66a7def1c96f7008a0c397dc588b6d7";
            string htmlOutputPath = @"C:\Users\Gabriel\Desktop\templeteHTML\output.html";
            string pdfOutputPath = @"C:\Users\Gabriel\Desktop\Danfe\output.pdf";

            try
            {
                /*
                string xmlPath = @"C:\Users\Gabriel\Desktop\NFe\v4_ComLocalEntrega.xml";
                var data = XMLParser.Parse(xmlPath);
                string filledTemplate = HTMLGenerator.Generate(data, templatePath);
                File.WriteAllText(htmlOutputPath, filledTemplate);
                PDFGenerator.Generate(filledTemplate, pdfOutputPath);
                Console.WriteLine("HTML e PDF gerados com sucesso!");
                */

                string xmlContent = await APIClient.GetXMLFromAPIAsync(apiUrl, chNFe, token);
                var data = XMLParser.ParseFromString(xmlContent);
                string filledTemplate = HTMLGenerator.Generate(data, templatePath);

                File.WriteAllText(htmlOutputPath, filledTemplate);
                PDFGenerator.Generate(filledTemplate, pdfOutputPath);

                Console.WriteLine("HTML e PDF gerados com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
