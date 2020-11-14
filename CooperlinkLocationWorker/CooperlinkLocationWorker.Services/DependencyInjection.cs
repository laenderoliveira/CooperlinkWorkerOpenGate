using CooperlinkLocationWorker.Infrastructure;
using CooperlinkLocationWorker.Persistence;
using CooperlinkLocationWorker.Services.Configuration;
using CooperlinkLocationWorker.Services.Interfaces;
using CooperlinkLocationWorker.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CooperlinkLocationWorker.Services
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICooperlinkHttpService, CooperlinkHttpService>();
            services.AddTransient<ICooperlinkApplicationService, CooperlinkApplicationService>();
            services.AddTransient<ILocationConfiguration, LocationConfiguration>(); 
            services.AddInfrastructure();
            services.AddPersistence();
        }
    }
}
