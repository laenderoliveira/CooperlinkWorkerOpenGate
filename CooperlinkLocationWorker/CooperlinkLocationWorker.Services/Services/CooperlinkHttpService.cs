using CooperlinkLocationWorker.Domain.Models;
using CooperlinkLocationWorker.Infrastructure.Http;
using CooperlinkLocationWorker.Infrastructure.Interfaces;
using CooperlinkLocationWorker.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CooperlinkLocationWorker.Services.Services
{
    public class CooperlinkHttpService : ICooperlinkHttpService
    {
        private readonly ICooperlinkApiHttp _cooperlinkApiHttp;
        private readonly ILogger<CooperlinkHttpService> _logger;

        public CooperlinkHttpService(ICooperlinkApiHttp cooperlinkApiHttp, ILogger<CooperlinkHttpService> logger)
        {
            _cooperlinkApiHttp = cooperlinkApiHttp;
            _logger = logger;
        }

        public async Task<List<Vehicle>> GetLocationVehicle()
        {
            try
            {
                var response = await _cooperlinkApiHttp.LocationVehicle();

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    _logger.LogError($"Error querying data. Error: {await response.Content.ReadAsStringAsync()}");

                var result = await GetContentRequest<List<Vehicle>>(response);

                return result;
            }
            catch (HttpRequestException e)
            {
                var mensageHttp = e.InnerException != null ? e.InnerException.Message.ToString() + ".\r\n" + e.Message.ToString() : e.Message.ToString();
                
                _logger.LogError($"Error querying data. Error: {mensageHttp}");
                
                return new List<Vehicle>();
            }
        }

        private async Task<T> GetContentRequest<T>(HttpResponseMessage response)
        {
            var data = await response.Content.ReadAsStringAsync();
 
            JObject respostaJson = JObject.Parse(data);

            var listVeihicle = respostaJson["lista"];

            return listVeihicle.ToObject<T>();
        }
    }
}
