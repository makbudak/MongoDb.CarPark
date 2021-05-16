using Microsoft.Extensions.Options;
using MongoDb.CarPark.DataAccess.Abstract;
using MongoDb.CarPark.Entities.Concrete;
using MongoDb.CarPark.Utilities;

namespace MongoDb.CarPark.DataAccess.Concrete
{
    public class BrandRepository : MongoDbRepository<Brand>, IBrandRepository
    {
        public BrandRepository(IOptions<MongoDbSettings> options) : base(options)
        {

        }
    }
}
