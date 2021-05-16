using MongoDb.CarPark.Entities.Concrete;

namespace MongoDb.CarPark.DataAccess.Abstract
{
    public interface ISerieRepository : IRepository<Serie, string>
    {
    }
}
