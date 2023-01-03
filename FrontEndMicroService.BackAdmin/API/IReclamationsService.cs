using FrontEndMicroService.BackAdmin.Models;
using System;
using System.Net.Http.Json;

namespace FrontEndMicroService.BackAdmin.API
{

    public interface IReclamationsService
    {
        public Task<List<Reclamation>> GetAll();
        public Task<Reclamation> Create(Reclamation Article);

        public Task<Reclamation> Edit(Reclamation Article);
        public Task<Reclamation> Delete(int id);
    }
}
