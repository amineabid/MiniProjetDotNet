using FrontEndMicroService.Client.Models;
using System.Net.Http.Json;

namespace FrontEndMicroService.Client.API 
{
    public class InterventionsService :IInterventionsService
    {
        public string GatewayApiGetURL = "https://localhost:7044/apigateway/Interventions";

        public HttpClient _httpClient;
        public InterventionsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Intervention>> GetAll()
        {
            var response = await _httpClient.GetAsync(GatewayApiGetURL);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Intervention>>();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public async Task<Intervention> Create(Intervention Intervention)
        {
            var response = await _httpClient.PostAsJsonAsync(GatewayApiGetURL, Intervention);


            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Intervention>();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
