using CooperlinkLocationWorker.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CooperlinkLocationWorker.Persistence.Mongo.Configuration
{
    public class MongoConfiguration : IMongoConfiguration
    {
        private readonly IConfiguration _configuration;
        private readonly string _section = "MongoConnection";

        public MongoConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Connection { get => _configuration.GetSection(_section)["Connection"]; }
        public string Collection { get => _configuration.GetSection(_section)["Collection"]; }
    }
}
