using System.Linq;

namespace LetsTest.Mocking
{
    public interface IHousekeeperRepository
    {
        IQueryable<Housekeeper> GetHousekeepers();
    }

    public class HousekeeperRepository : IHousekeeperRepository
    {
        private static readonly UnitOfWork UnitOfWork = new UnitOfWork();

        public IQueryable<Housekeeper> GetHousekeepers()
        {
            return UnitOfWork.Query<Housekeeper>();
        }
    }
}