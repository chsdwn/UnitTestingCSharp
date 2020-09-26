using LetsTest.Mocking;

namespace LetsTest.NUnitTests.Mocking
{
    // Can be called other projects like "Scub" or "Mock"
    public class FakeFileReader : IFileReader
    {
        public string Read(string path)
        {
            return "";
        }
    }
}