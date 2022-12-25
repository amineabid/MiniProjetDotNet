using FrontEndMicroService.Client.Models;
using System;
using System.Net.Http.Json;

namespace FrontEndMicroService.Client.API
{

    public interface IArticlesService
    {
        public Task<List<Article>> GetAll();
        public Task<Article> Create(Article Article);

    }
}
