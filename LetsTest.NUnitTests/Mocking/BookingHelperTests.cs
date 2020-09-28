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
        private Mock<IBookingRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IBookingRepository>();
        }

        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            _repository
                .Setup(r => r.GetActiveBookings(1))
                .Returns(new List<Booking>
                {
                    new Booking
                    {
                        Id = 2,
                        ArrivalDate = new DateTime(2017, 1, 15, 14, 0, 0),
                        DepartureDate = new DateTime(2017, 1, 20, 10, 0, 0),
                        Reference = "a"
                    }
                }.AsQueryable());

            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = new DateTime(2017, 1, 10, 14, 0, 0),
                DepartureDate = new DateTime(2017, 1, 14, 10, 0, 0)
            }, _repository.Object);

            Assert.That(result, Is.Empty);
        }
    }
}