using System.Xml.Linq;

namespace XMLProcessing
{
    public static class XMLParser
    {
        public static XMLData Parse(string xmlFilePath)
        {
            var xmlContent = XMLReader.Read(xmlFilePath);
            var doc = XDocument.Parse(xmlContent);
            var data = new XMLData();

            data.Campo1 = doc.Root.Element("NomeDoElemento1")?.Value ?? "";
            data.Campo2 = doc.Root.Element("NomeDoElemento2")?.Value ?? "";
            // Continue mapeando os campos conforme necessário

            return data;
        }
    }
}
