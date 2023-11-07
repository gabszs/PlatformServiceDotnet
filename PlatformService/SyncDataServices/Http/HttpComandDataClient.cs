using System.Text;
using System.Text.Json;
using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpComandDataClient : IHttpComandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpComandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }


        public async Task SendPlatformToCommand(PlatformReadDto plat)
        {
            StringContent httpContent = new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "application/json"
            );
            var response = await _httpClient.PostAsync(_configuration["CommandService"], httpContent);

            if (response.IsSuccessStatusCode)
            {
                System.Console.WriteLine("----------->>> SUCCESS, Sync Post to the command Service was OK!!");
            }
            else
            {
                System.Console.WriteLine("----------->>> FAILED, Sync Post to the command Service was not OK!!");
            }

        }
    }
}