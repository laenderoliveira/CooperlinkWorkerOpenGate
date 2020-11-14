using MongoDB.Driver;

namespace CooperlinkLocationWorker.Persistence.Interfaces
{
    public interface IMongoConnection
    {
        IMongoDatabase ConnectDatabase();
    }
}
