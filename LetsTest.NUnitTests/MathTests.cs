using LetsTest.Fundamentals;
using NUnit.Framework;

namespace LetsTest.NUnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            var result = _math.Add(10, 5);

            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        {
            var result = _math.Max(10, 5);

            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        {
            var result = _math.Max(5, 10);

            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
        {
            var result = _math.Max(10, 10);

            Assert.That(result, Is.EqualTo(10));
        }
    }
}