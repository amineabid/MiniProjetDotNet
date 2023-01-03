using FrontEndMicroService.BackAdmin.Models;
using System;
using System.Net.Http.Json;

namespace FrontEndMicroService.BackAdmin.API
{

    public class ArticlesService : IArticlesService
    {
        public string GatewayApiGetURL = "https://localhost:7044/apigateway/Articles";
        public string GatewayApiGetURLPieces = "https://localhost:7044/apigateway/Pieces";

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
                return Article;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public async Task<Article> Edit(Article Article)
{
            var response = await _httpClient.PutAsJsonAsync(GatewayApiGetURL+"/"+Article.Id, Article);


            if (response.IsSuccessStatusCode)
            {
                return Article;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public async Task<Article> Delete(int id)
{
            var response = await _httpClient.DeleteAsync(GatewayApiGetURL+"/"+id);


            if (response.IsSuccessStatusCode)
            {
                return new Article { Id= id,Name="" };
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public async Task<List<Piece>> GetPiecesArtciles(int articleId)
        {
            try {
                var response = await _httpClient.GetAsync(GatewayApiGetURL+ "/Pieces/"+ articleId);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<Piece>>();
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
        public async Task<Piece> CreatePiece(Piece Piece)
{
            var response = await _httpClient.PostAsJsonAsync(GatewayApiGetURLPieces, Piece);


            if (response.IsSuccessStatusCode)
            {
                return Piece;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public async Task<Piece> EditPiece(Piece Piece)
{
            var response = await _httpClient.PutAsJsonAsync(GatewayApiGetURLPieces+"/"+ Piece.Id, Piece);


            if (response.IsSuccessStatusCode)
            {
                return Piece;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public async Task<Piece> DeletePiece(int id)
{
            var response = await _httpClient.DeleteAsync(GatewayApiGetURLPieces+"/"+id);


            if (response.IsSuccessStatusCode)
            {
                return new Piece { Id= id,Name="",ArticleId=0 };
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

    }
}
