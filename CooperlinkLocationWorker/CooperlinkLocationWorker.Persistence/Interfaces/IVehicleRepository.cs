using CooperlinkLocationWorker.Domain.Models;
using System.Threading.Tasks;

namespace CooperlinkLocationWorker.Persistence.Interfaces
{
    public interface IVehicleRepository
    {
        Task AddAsync(Vehicle document);
        Task<Vehicle> LastDocumentAsync();
    }
}
