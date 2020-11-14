using CooperlinkLocationWorker.Persistence.Interfaces;
using CooperlinkLocationWorker.Persistence.Mongo.Configuration;
using CooperlinkLocationWorker.Persistence.Mongo.Repository;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace CooperlinkLocationWorker.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddTransient<IMongoConfiguration, MongoConfiguration>();
            services.AddTransient<IMongoConnection, MongoConnection>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
