using CooperlinkLocationWorker.Infrastructure.Configuration;
using CooperlinkLocationWorker.Infrastructure.Configurattion;
using CooperlinkLocationWorker.Infrastructure.Http;
using CooperlinkLocationWorker.Infrastructure.Interfaces;
using CooperlinkLocationWorker.Infrastructure.Mqtt;
using Microsoft.Extensions.DependencyInjection;

namespace CooperlinkLocationWorker.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ICooperlinkApiConfig, CooperlinkApiConfig>();
            services.AddHttpClient<ICooperlinkApiHttp, CooperlinkApiHttp>();
            services.AddTransient<IBrokerMqttConfig, BrokerMqttConfig>();
            services.AddTransient<IBrokerMqtt, BrokerMqtt>();
        }
    }
}
