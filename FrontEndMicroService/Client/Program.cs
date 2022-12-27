using FrontEndMicroService.Client;
using FrontEndMicroService.Client.API;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IArticlesService, ArticlesService>();
builder.Services.AddScoped<IReclamationsService, ReclamationsService>();
builder.Services.AddScoped<IInterventionsService, InterventionsService>();

builder.Services.AddMudServices();

builder.Services.AddScoped(sp => 
    new HttpClient { 
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
});


await builder.Build().RunAsync();
