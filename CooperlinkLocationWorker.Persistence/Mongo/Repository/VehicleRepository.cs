using CooperlinkLocationWorker.Domain.Models;
using CooperlinkLocationWorker.Persistence.Interfaces;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace CooperlinkLocationWorker.Persistence.Mongo.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IRepository<Vehicle> _repository;

        public VehicleRepository(IRepository<Vehicle> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Vehicle document)
        {
            await _repository.AddAsync(document);
        }

        public async Task<Vehicle> LastDocumentAsync()
        {
            var sort = Builders<Vehicle>.Sort.Descending(lnq => lnq.CreatedAt);
            var filter = Builders<Vehicle>.Filter.Where(doc => true);
            return await _repository.FindAsync(filter, sort);
        }
    }
}
