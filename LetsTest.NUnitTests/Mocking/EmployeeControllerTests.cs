using LetsTest.Mocking;
using Moq;
using NUnit.Framework;

namespace LetsTest.NUnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeStorage> _employeeStorage;
        private EmployeeController _employeeController;

        [SetUp]
        public void SetUp()
        {
            _employeeStorage = new Mock<IEmployeeStorage>();
            _employeeController = new EmployeeController(_employeeStorage.Object);
        }

        [Test]
        public void DeleteEmployee_WhenCalled_CallEmployeeStorageDeleteMethod()
        {
            _employeeController.DeleteEmployee(1);

            _employeeStorage.Verify(e => e.Delete(1), Times.Once);
        }

        [Test]
        public void DeleteEmployee_WhenCalled_ReturnRedirectResult()
        {
            var result = _employeeController.DeleteEmployee(1);

            Assert.That(result, Is.TypeOf<RedirectResult>());
        }
    }
}