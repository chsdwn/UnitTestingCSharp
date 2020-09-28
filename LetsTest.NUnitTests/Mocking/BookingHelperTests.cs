using System;
using System.Collections.Generic;
using System.Linq;
using LetsTest.Mocking;
using Moq;
using NUnit.Framework;

namespace LetsTest.NUnitTests.Mocking
{
    [TestFixture]
    public class BookingHelperTests
    {
        private Mock<IBookingStorage> _storage;

        [SetUp]
        public void SetUp()
        {
            _storage = new Mock<IBookingStorage>();
        }

        [Test]
        public void OverlappingBookingsExist_BookingStatusIsNotCancelled_ReturnEmptyString()
        {
            var booking = new Booking { Status = "Cancelled" };

            var result = BookingHelper.OverlappingBookingsExist(booking, _storage.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void OverlappingBookingsExist_NoOverlappingBookings_ReturnEmptyString()
        {
            var booking = new Booking { Status = "" };
            _storage
                .Setup(s => s.GetAvailableBookings(booking))
                .Returns(new List<Booking>().AsQueryable());

            var result = BookingHelper.OverlappingBookingsExist(booking, _storage.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void OverlappingBookingsExist_HasOverlappingBooking_ReturnFirstOverlappingBookingReference()
        {
            var booking = new Booking
            {
                Id = 1,
                Status = "",
                ArrivalDate = new DateTime(2000, 1, 1),
                DepartureDate = new DateTime(2000, 1, 2)
            };
            _storage
                .Setup(s => s.GetAvailableBookings(booking))
                .Returns(
                    new List<Booking>
                    {
                        new Booking
                        {
                            Id = 2,
                            Status = "",
                            ArrivalDate = new DateTime(2000, 1, 1),
                            DepartureDate = new DateTime(2000, 1, 2),
                            Reference = "a"
                        }
                    }.AsQueryable());

            var result = BookingHelper.OverlappingBookingsExist(booking, _storage.Object);

            Assert.That(result, Is.EqualTo("a"));
        }
    }
}