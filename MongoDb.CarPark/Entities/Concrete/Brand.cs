using MongoDb.CarPark.Entities.Abstract;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDb.CarPark.Entities.Concrete
{
    public class Brand : MongoDbEntity
    {
        public string Name { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? UpdatedDate { get; set; }

        public bool Deleted { get; set; }
    }
}
