using System.Collections.Generic;
using LetsTest.Mocking;
using Moq;
using NUnit.Framework;

namespace LetsTest.NUnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IVideoRepository> _repository;
        private Mock<IFileReader> _fileReader;
        private VideoService _videoService;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IVideoRepository>();
            _fileReader = new Mock<IFileReader>();
            _videoService = new VideoService(_repository.Object, _fileReader.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosProcessed_ReturnEmptyString()
        {
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AFewUnprocessesdVideos_ReturnAStringWithIdOfUnprocessedVideos()
        {
            _repository
                .Setup(r => r.GetUnprocessedVideos())
                .Returns(new List<Video> { new Video { Id = 1 }, new Video { Id = 2 } });

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2"));
        }
    }
}