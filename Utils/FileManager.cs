using System.IO;

namespace Utils
{
    public static class FileManager
    {
        public static string[] GetFiles(string directoryPath, string searchPattern)
        {
            return Directory.GetFiles(directoryPath, searchPattern);
        }

        public static void SaveFile(byte[] content, string filePath)
        {
            File.WriteAllBytes(filePath, content);
        }
    }
}
