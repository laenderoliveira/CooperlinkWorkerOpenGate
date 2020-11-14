using CooperlinkLocationWorker.Domain.Enum;
using CooperlinkLocationWorker.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;

namespace CooperlinkLocationWorker.Services.Configuration
{
    public class LocationConfiguration : ILocationConfiguration
    {
        private readonly IConfiguration _configuration;
        private readonly string _section = "LocationBase";

        public LocationConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public double Radius => Double.Parse(_configuration.GetSection(_section)["Radius"], CultureInfo.InvariantCulture);

        public double Latitude => Double.Parse(_configuration.GetSection(_section)["Latitude"], CultureInfo.InvariantCulture);

        public double Longitude => Double.Parse(_configuration.GetSection(_section)["Longitude"], CultureInfo.InvariantCulture);

        public EDistanceType DistanceType => (EDistanceType) Int32.Parse(_configuration.GetSection(_section)["DistanceType"], CultureInfo.InvariantCulture);
    }
}
