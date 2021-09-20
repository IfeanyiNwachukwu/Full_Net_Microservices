using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ServicesPlatform.DTOs.Readable;

namespace ServicesPlatform.SyncDataServices.HttpRun
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SendPlatformToCommand(PlatformReadDTO platform)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(platform),
                Encoding.UTF8,
                "application/json"
            );
            var url = _configuration["CommandService"];
            var response = await _httpClient.PostAsync($"{url}",httpContent);

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> sync POST to CommandService was Ok!");
            }
            else
            {
                Console.WriteLine("--> sync POST to CommandService was NOT Ok!");
            }
        
        }
    }
}