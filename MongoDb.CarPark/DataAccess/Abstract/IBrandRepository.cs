using MongoDb.CarPark.Entities.Concrete;

namespace MongoDb.CarPark.DataAccess.Abstract
{
    public interface IBrandRepository : IRepository<Brand, string>
    {
    }
}
