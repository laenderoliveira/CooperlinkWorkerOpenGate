using System;
using System.Threading;
using System.Threading.Tasks;
using CooperlinkLocationWorker.Services.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CooperlinkLocationWorker.Application
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ICooperlinkApplicationService _cooperlinkApplicationService;
        
        public Worker(ILogger<Worker> logger, ICooperlinkApplicationService cooperlinkApplicationService)
        {
            _logger = logger;
            _cooperlinkApplicationService = cooperlinkApplicationService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(2500, stoppingToken);
                await _cooperlinkApplicationService.StartAsyncService();
            }
        }
    }
}
