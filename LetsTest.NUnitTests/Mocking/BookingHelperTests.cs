using System;
using System.Collections.Generic;
using System.Linq;
using LetsTest.Mocking;
using Moq;
using NUnit.Framework;

namespace LetsTest.NUnitTests.Mocking
{
    [TestFixture]
    public class BookingHelper_OverlappingBookingsExistTests
    {
        private Mock<IBookingStorage> _storage;

        [SetUp]
        public void SetUp()
        {
            _storage = new Mock<IBookingStorage>();
        }

        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {

        }
    }
}