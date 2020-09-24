using LetsTest.Fundamentals;
using NUnit.Framework;

namespace LetsTest.NUnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(0);

            // result needs to be NotFound object
            Assert.That(result, Is.TypeOf<NotFound>());

            // result needs to be NotFound object or one of its derivatives
            // Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {

        }
    }
}