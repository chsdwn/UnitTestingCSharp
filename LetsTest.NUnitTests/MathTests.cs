using System.Collections.Generic;
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
        [Ignore("Ignored")]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            var result = _math.Add(10, 5);

            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        [TestCase(10, 5, 10)]
        [TestCase(5, 10, 10)]
        [TestCase(10, 10, 10)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            // Assert.That(result, Is.Not.Empty);
            // Assert.That(result.Count(), Is.EqualTo(3));
            // Assert.That(result, Does.Contain(1));
            // Assert.That(result, Does.Contain(3));
            // Assert.That(result, Does.Contain(5));

            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

            // Assert.That(result, Is.Ordered);
            // Assert.That(result, Is.Unique);
        }
    }
}