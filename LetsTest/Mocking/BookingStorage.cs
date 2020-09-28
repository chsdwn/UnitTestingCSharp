using System.Linq;

namespace LetsTest.Mocking
{
    public interface IBookingStorage
    {
        IQueryable<Booking> GetAvailableBookings(Booking booking);
    }

    public class BookingStorage : IBookingStorage
    {
        public IQueryable<Booking> GetAvailableBookings(Booking booking)
        {
            var unitOfWork = new UnitOfWork();
            var bookings =
                unitOfWork.Query<Booking>()
                    .Where(
                        b => b.Id != booking.Id && b.Status != "Cancelled");

            return bookings;
        }
    }
}