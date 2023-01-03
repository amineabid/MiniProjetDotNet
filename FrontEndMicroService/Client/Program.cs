using FrontEndMicroService.Client;
using FrontEndMicroService.Client.API;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
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
