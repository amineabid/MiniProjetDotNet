using FrontEndMicroService.BackAdmin.Models;
using System;
using System.Net.Http.Json;

namespace FrontEndMicroService.BackAdmin.API
{

    public interface IFacturesService
    {
        public Task<List<Facture>> GetAll();
        public Task<Facture> Create(Facture Facture);

        public Task<Facture> Edit(Facture Facture);
        public Task<Facture> Delete(int id);
    }
}
