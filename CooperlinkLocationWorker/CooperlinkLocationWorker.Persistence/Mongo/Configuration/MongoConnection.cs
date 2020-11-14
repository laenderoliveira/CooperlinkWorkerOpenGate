using CooperlinkLocationWorker.Persistence.Interfaces;
using MongoDB.Driver;

namespace CooperlinkLocationWorker.Persistence.Mongo.Configuration
{
    public class MongoConnection : IMongoConnection
    {
        private readonly IMongoConfiguration _configuration;

        public MongoConnection(IMongoConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IMongoDatabase ConnectDatabase()
        {
            return new MongoClient(_configuration.Connection).GetDatabase(_configuration.Collection);
        }
    }
}
