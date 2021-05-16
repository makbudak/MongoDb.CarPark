using MongoDb.CarPark.Entities.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDb.CarPark.Entities.Concrete
{
    public class Serie : MongoDbEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string BrandId { get; set; }

        public string Name { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? UpdatedDate { get; set; }

        public bool Deleted { get; set; }

        [BsonIgnore]
        public Brand Brand { get; set; }
    }
}
