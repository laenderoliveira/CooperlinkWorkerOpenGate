using System.Net.Http;
using System.Threading.Tasks;

namespace CooperlinkLocationWorker.Infrastructure.Interfaces
{
    public interface ICooperlinkApiHttp
    {
        Task<HttpResponseMessage> LocationVehicle();
    }
}
