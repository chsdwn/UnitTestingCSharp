﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LetsTest.Mocking
{
    public static class BookingHelper
    {
        public static string OverlappingBookingsExist(Booking booking, IBookingRepository storage)
        {
            if (booking.Status == "Cancelled")
                return string.Empty;

            var bookings = storage.GetActiveBookings(booking.Id);

            var overlappingBooking =
                bookings.FirstOrDefault(
                    b =>
                        booking.ArrivalDate < b.DepartureDate
                        && booking.DepartureDate > b.ArrivalDate);

            return overlappingBooking == null ? string.Empty : overlappingBooking.Reference;
        }
    }

    public interface IUnitOfWork
    {
        IQueryable<T> Query<T>();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public IQueryable<T> Query<T>()
        {
            return new List<T>().AsQueryable();
        }
    }

    public class Booking
    {
        public string Status { get; set; }
        public int Id { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Reference { get; set; }
    }
}