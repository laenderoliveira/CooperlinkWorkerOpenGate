namespace CooperlinkLocationWorker.Persistence.Interfaces
{
    public interface IMongoConfiguration
    {
        public string Connection { get; }
        public string Collection { get; }
    }
}
