using System;
using System.IO;
using XMLProcessing;
using HTMLGeneration;

namespace XMLToPDFApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string templatePath = @"C:\ws-project\Layout NFe\index.html";
            string xmlPath = @"C:\Users\Gabriel\Desktop\NFe\v4_ComLocalEntrega.xml";
            string outputPath = @"C:\Users\Gabriel\Desktop\Danfe\output.html";

            var data = XMLParser.Parse(xmlPath);
            string filledTemplate = HTMLGenerator.Generate(data, templatePath);

            File.WriteAllText(outputPath, filledTemplate);

            Console.WriteLine("HTML gerado com sucesso!");
        }
    }
}
