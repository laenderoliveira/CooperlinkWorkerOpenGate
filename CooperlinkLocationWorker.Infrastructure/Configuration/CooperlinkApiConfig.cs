using CooperlinkLocationWorker.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CooperlinkLocationWorker.Infrastructure.Configurattion
{

    public class CooperlinkApiConfig : ICooperlinkApiConfig
    {
        private readonly IConfiguration _configuration;
        private readonly string _section = "CooperlinkApi";

        public CooperlinkApiConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string UrlBase => _configuration.GetSection(_section)["UrlBase"];

        public string Username => _configuration.GetSection(_section)["Username"];

        public string Password => _configuration.GetSection(_section)["Password"];

        public string RouteToken => _configuration.GetSection(_section)["RouteToken"];

        public string RouteVehicle => _configuration.GetSection(_section)["RouteVehicle"];
    }
}
