using Microsoft.Extensions.Options;
using MongoDb.CarPark.DataAccess.Abstract;
using MongoDb.CarPark.Entities.Concrete;
using MongoDb.CarPark.Utilities;

namespace MongoDb.CarPark.DataAccess.Concrete
{
    public class SerieRepository : MongoDbRepository<Serie>, ISerieRepository
    {
        public SerieRepository(IOptions<MongoDbSettings> options) : base(options)
        {

        }
    }
}
