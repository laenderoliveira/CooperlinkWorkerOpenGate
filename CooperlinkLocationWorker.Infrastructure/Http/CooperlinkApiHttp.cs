using CooperlinkLocationWorker.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CooperlinkLocationWorker.Infrastructure.Http
{
    public class CooperlinkApiHttp : ICooperlinkApiHttp
    {
        private readonly ICooperlinkApiConfig _configCooperlinkApi;
        private readonly ILogger<CooperlinkApiHttp> _logger;
        private string _baseUrl;
        private string _token;
        private HttpClient Http { get; }

        public CooperlinkApiHttp(ICooperlinkApiConfig configCooperlinkApi, ILogger<CooperlinkApiHttp> logger, HttpClient http)
        {
            _configCooperlinkApi = configCooperlinkApi;
            _logger = logger;
            Http = http;
        }

        private async Task<string> GenerateBaseAddress()
        {
            var response = await PostRequest(ContentUser(), _configCooperlinkApi.UrlBase);

            var textResponse = await response.Content.ReadAsStringAsync();

            JObject json = JObject.Parse(textResponse);
            
            var server =  (string)json["servidores"].FirstOrDefault();

            if (string.IsNullOrEmpty(server))
                throw new HttpRequestException("Server unavailable or Username/Password invalid.");

            _logger.LogInformation($"Generate new url server. UrlServer: {server}, at: {DateTimeOffset.Now}");

            return server;
        }

        private async Task<string> GenerateToken()
        {
            var response = await PostRequest(ContentUser(), $"{_baseUrl}/{_configCooperlinkApi.RouteToken}");

            JObject respostaJson = JObject.Parse(await response.Content.ReadAsStringAsync());

            if (!await CheckUserLogged(response))
                throw new HttpRequestException((string)respostaJson["mensagem"]);

            var token = (string)respostaJson["token"];

            _logger.LogInformation($"Generate new token at {DateTimeOffset.Now}. Token: {token}");

            return token;
        }

        private async Task<HttpResponseMessage> PostRequest(Dictionary<string, string> content, string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(content) };

            var response = await Http.SendAsync(request);

            return response;
        }

        private Dictionary<string, string> ContentUser()
        {
            var content = new Dictionary<string, string>();
            content.Add("usuario", _configCooperlinkApi.Username);
            content.Add("senha", _configCooperlinkApi.Password);
            return content;
        }

        public async Task<HttpResponseMessage> LocationVehicle()
        {
            if (string.IsNullOrEmpty(_token) || string.IsNullOrEmpty(_baseUrl))
            {
                _baseUrl = await GenerateBaseAddress();
                _token = await GenerateToken();
            }

            var content = new Dictionary<string, string>();

            content.Add("token", _token);

            var response = await PostRequest(content, $"{_baseUrl}/{_configCooperlinkApi.RouteVehicle}");
            
            if (response.IsSuccessStatusCode && !await CheckUserLogged(response))
            {
                _token = await GenerateToken();
                return await LocationVehicle();
            }

            return response;
        }

        private async Task<bool> CheckUserLogged(HttpResponseMessage response)
        {
            JObject respostaJson = JObject.Parse(await response.Content.ReadAsStringAsync());

            return (bool)respostaJson["logado"];
        }


    }
}
