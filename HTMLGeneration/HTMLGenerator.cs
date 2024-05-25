using System.IO;

namespace HTMLGeneration
{
    public static class HTMLGenerator
    {
        public static string Generate(XMLProcessing.XMLData data)
        {
            string templatePath = @"Caminho\Para\Template\DanfeTemplate.html";
            string templateContent = File.ReadAllText(templatePath);

            // Substitua os placeholders do template com os dados reais
            templateContent = templateContent.Replace("{{Campo1}}", data.Campo1);
            templateContent = templateContent.Replace("{{Campo2}}", data.Campo2);
            templateContent = templateContent.Replace("{{chNFe}}", data.chNFe);
            // Continue substituindo os placeholders conforme necessário

            return templateContent;
        }
    }
}
