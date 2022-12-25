using FrontEndMicroService.Client.Models;
using System;
using System.Net.Http.Json;

namespace FrontEndMicroService.Client.API
{

    public class ArticlesService : IArticlesService
    {
        public string GatewayApiGetURL = "https://localhost:7044/apigateway/Articles";

        public HttpClient _httpClient;
        public ArticlesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Article>> GetAll()
        {
            try {
                var response = await _httpClient.GetAsync(GatewayApiGetURL);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<Article>>();
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException();
            }
        }
        public async Task<Article> Create(Article Article)
{
            var response = await _httpClient.PostAsJsonAsync(GatewayApiGetURL, Article);


            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Article>();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

    }
}
