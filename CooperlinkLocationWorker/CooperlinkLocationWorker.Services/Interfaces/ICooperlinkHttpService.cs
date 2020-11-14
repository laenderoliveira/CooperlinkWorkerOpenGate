using CooperlinkLocationWorker.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CooperlinkLocationWorker.Services.Interfaces
{
    public interface ICooperlinkHttpService
    {
        Task<List<Vehicle>> GetLocationVehicle();
    }
}
