using FrontEndMicroService.BackAdmin.Models;
using System.Net.Http.Json;

namespace FrontEndMicroService.BackAdmin.API 
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
        public async Task<Intervention> Edit(Intervention Article)
        {
            var response = await _httpClient.PutAsJsonAsync(GatewayApiGetURL + "/" + Article.Id, Article);


            if (response.IsSuccessStatusCode)
            {
                return Article;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public async Task<Intervention> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync(GatewayApiGetURL + "/" + id);


            if (response.IsSuccessStatusCode)
            {
                return new Intervention { Id = id, Description = "", garantie = false, ReclamationId = 0, Reclamation = null };
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
