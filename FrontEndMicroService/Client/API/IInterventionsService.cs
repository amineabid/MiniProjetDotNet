using FrontEndMicroService.Client.Models;
using System;
using System.Net.Http.Json;

namespace FrontEndMicroService.Client.API
{

    public interface IInterventionsService
    {
        public Task<List<Intervention>> GetAll();
        public Task<Intervention> Create(Intervention Article);

    }
}
