using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDb.CarPark.Utilities
{
    public class MongoDbSettings
    {
        public string ConnectionString;
        public string Database;

        public const string ConnectionStringValue = nameof(ConnectionString);
        public const string DatabaseValue = nameof(Database);
    }
}
