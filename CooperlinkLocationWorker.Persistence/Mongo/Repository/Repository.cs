using CooperlinkLocationWorker.Domain.Collections;
using CooperlinkLocationWorker.Persistence.Interfaces;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace CooperlinkLocationWorker.Persistence.Mongo.Repository
{
    public class Repository<T> : IRepository<T> where T: CollectionModel
    {
        public IMongoCollection<T> Collection { get; private set; }
        private readonly IMongoDatabase _database;

        public Repository(IMongoConnection mongoConnection)
        {
            _database = mongoConnection.ConnectDatabase();
            Collection = _database.GetCollection<T>(GetCollectionName());
        }

        private protected string GetCollectionName()
        {
            var documentType = typeof(T);

            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }

        public async Task AddAsync(T document)
        {
            await Collection.InsertOneAsync(document);
        }

        public async Task<T> FindAsync(FilterDefinition<T> filter, SortDefinition<T> sort)
        {
            return await Collection.Find(filter)
                .Sort(sort)
                .FirstOrDefaultAsync();
        }
    }
}
