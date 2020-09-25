using LetsTest.Fundamentals;
using NUnit.Framework;

namespace LetsTest.NUnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(15, "FizzBuzz")]
        [TestCase(5, "Buzz")]
        [TestCase(3, "Fizz")]
        [TestCase(1, "1")]
        public void GetOutput_WhenCalled_ReturnFizzBuzzOrArgument(int number, string expectedResult)
        {
            var result = FizzBuzz.GetOutput(number);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}