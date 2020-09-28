using System.Net;

namespace LetsTest.Mocking
{
    public interface IFileDownloader
    {
        void DownloadFile(string url, string path);
        void Dispose();
    }

    public class FileDownloader : IFileDownloader
    {
        private readonly WebClient _client;

        public FileDownloader()
        {
            _client = new WebClient();
        }

        public void DownloadFile(string url, string path)
        {
            _client.DownloadFile(url, path);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}