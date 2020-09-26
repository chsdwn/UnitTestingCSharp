using System.IO;

namespace LetsTest.Mocking
{
    public class FileReader : IFileReader
    {
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }

    public interface IFileReader
    {
        string Read(string path);
    }
}