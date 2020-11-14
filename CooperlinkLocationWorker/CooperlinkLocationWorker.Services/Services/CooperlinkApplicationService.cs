using CooperlinkLocationWorker.Domain.Enum;
using CooperlinkLocationWorker.Domain.Extensions;
using CooperlinkLocationWorker.Domain.Models;
using CooperlinkLocationWorker.Infrastructure.Interfaces;
using CooperlinkLocationWorker.Persistence.Interfaces;
using CooperlinkLocationWorker.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CooperlinkLocationWorker.Services.Services
{
    public class CooperlinkApplicationService : ICooperlinkApplicationService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ICooperlinkHttpService _cooperlinkHttpService;
        private readonly ILocationConfiguration _locationConfiguration;
        private readonly IBrokerMqttConfig _brokerMqttConfig;
        private readonly IBrokerMqtt _brokerMqtt;
        private readonly ILogger<CooperlinkApplicationService> _logger;

        private Location _baseLocation;
        private double _radius;
        private EDistanceType _distanceType;

        public CooperlinkApplicationService(IVehicleRepository vehicleRepository,
                                            ICooperlinkHttpService cooperlinkHttpService,
                                            ILocationConfiguration locationConfiguration,
                                            IBrokerMqttConfig brokerMqttConfig,
                                            IBrokerMqtt brokerMqtt,
                                            ILogger<CooperlinkApplicationService> logger)
        {
            _vehicleRepository = vehicleRepository;
            _cooperlinkHttpService = cooperlinkHttpService;
            _locationConfiguration = locationConfiguration;
            _brokerMqtt = brokerMqtt;
            _brokerMqttConfig = brokerMqttConfig;
            _logger = logger;
            _baseLocation = new Location(_locationConfiguration.Latitude, _locationConfiguration.Longitude);
            _radius = _locationConfiguration.Radius;
            _distanceType = _locationConfiguration.DistanceType;
        }

        public async Task StartAsyncService()
        {
            var vehicles = await _cooperlinkHttpService.GetLocationVehicle();
            var lastVehice = await _vehicleRepository.LastDocumentAsync();

            foreach (var vehicle in vehicles)
            {
                _logger.LogInformation($"Vehicle location at: {DateTimeOffset.Now}");

                await _vehicleRepository.AddAsync(vehicle);

                if (lastVehice != null && vehicle.LastLocation.LocationWithinRadius(_baseLocation, _radius, _distanceType))
                {
                    _logger.LogCritical($"Vehicle within radius at: {DateTimeOffset.Now}");
                    
                    if (vehicle.LastLocation.AllowedOpenGate(lastVehice.LastLocation, _baseLocation, _radius, _distanceType))
                    {
                        _brokerMqtt.PublishMessageDefaultTopic(_brokerMqttConfig.Payload);
                        _logger.LogCritical($"Open gate at: {DateTimeOffset.Now}");
                    }

                    if (vehicle.LastLocation.Ignition != lastVehice.LastLocation.Ignition)
                        _brokerMqtt.PublishMessage("vehicle/cb300", vehicle.LastLocation.Ignition == EIgnition.ON ? "IgnitionOn" : "IgnitionOff");
                }
            }
        }
    }
}
