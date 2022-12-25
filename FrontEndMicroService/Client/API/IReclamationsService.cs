using FrontEndMicroService.Client.Models;
using System;
using System.Net.Http.Json;

namespace FrontEndMicroService.Client.API
{

    public interface IReclamationsService
    {
        public Task<List<Reclamation>> GetAll();
        public Task<Reclamation> Create(Reclamation Article);

    }
}
