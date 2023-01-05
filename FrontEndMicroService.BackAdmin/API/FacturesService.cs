using FrontEndMicroService.BackAdmin.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace FrontEndMicroService.BackAdmin.API
{
    public class FacturesService : IFacturesService
    {
        public string GatewayApiGetURL = "https://localhost:7044/apigateway/Factures";

        public HttpClient _httpClient;
        public FacturesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Facture>> GetAll()
        {
            var response = await _httpClient.GetAsync(GatewayApiGetURL);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Facture>>();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public async Task<Facture> Create(Facture Facture)
{
            var jsonString = JsonConvert.SerializeObject(Facture, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
});
            Facture ordd = JsonConvert.DeserializeObject<Facture>(jsonString);
            var response = await _httpClient.PostAsJsonAsync(GatewayApiGetURL, ordd);


            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Facture>();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public async Task<Facture> Edit(Facture Facture)
        {
            var response = await _httpClient.PutAsJsonAsync(GatewayApiGetURL + "/" + Facture.Id, Facture);


            if (response.IsSuccessStatusCode)
            {
                return Facture;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public async Task<Facture> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync(GatewayApiGetURL + "/" + id);


            if (response.IsSuccessStatusCode)
            {
                return new Facture { Id = id, InterventionId = 0  };
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

    }
}
