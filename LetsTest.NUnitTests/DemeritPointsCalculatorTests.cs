using System;
using LetsTest.Fundamentals;
using NUnit.Framework;

namespace LetsTest.NUnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;

        [SetUp]
        public void SetUp()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }

        [Test]
        public void CalculateDemeritPoints_SpeedIsLessThanZero_ThrowArgumentOutOfRangeException()
        {
            Assert.That(
                () => _demeritPointsCalculator.CalculateDemeritPoints(-1),
                Throws.TypeOf<ArgumentOutOfRangeException>()
            );
        }

        [Test]
        public void CalculateDemeritPoints_SpeedIsLessThanSpeedLimit_ReturnZero()
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(0);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateDemeritPoints_SpeedIsHigherThanSpeedLimit_ReturnOneForEveryFiveOverTheLimit()
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(70);

            Assert.That(result, Is.EqualTo(1));
        }
    }
}