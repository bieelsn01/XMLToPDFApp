using System.IO;

namespace XMLProcessing
{
    public static class XMLReader
    {
        public static string Read(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
