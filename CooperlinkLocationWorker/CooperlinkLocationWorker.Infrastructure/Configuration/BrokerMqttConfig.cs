using CooperlinkLocationWorker.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace CooperlinkLocationWorker.Infrastructure.Configuration
{
    public class BrokerMqttConfig : IBrokerMqttConfig
    {
        private readonly IConfiguration _configuration;
        private readonly string _section = "BrokerMqtt";

        public BrokerMqttConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Server => _configuration.GetSection(_section)["Server"];

        public int Port => Int32.Parse(_configuration.GetSection(_section)["Port"]);

        public string Topic => _configuration.GetSection(_section)["Topic"];

        public string Username => _configuration.GetSection(_section)["Username"];

        public string Password => _configuration.GetSection(_section)["Password"];

        public string Payload => _configuration.GetSection(_section)["Payload"];
    }
}
