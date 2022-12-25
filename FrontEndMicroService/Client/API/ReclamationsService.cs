using FrontEndMicroService.Client.Models;
using System.Net.Http.Json;

namespace FrontEndMicroService.Client.API
{
    public class ReclamationsService : IReclamationsService
    {
        public string GatewayApiGetURL = "https://localhost:7044/apigateway/Reclamations";

        public HttpClient _httpClient;
        public ReclamationsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Reclamation>> GetAll()
        {
            var response = await _httpClient.GetAsync(GatewayApiGetURL);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Reclamation>>();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public async Task<Reclamation> Create(Reclamation Reclamation)
        {
            var response = await _httpClient.PostAsJsonAsync(GatewayApiGetURL, Reclamation);


            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Reclamation>();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
