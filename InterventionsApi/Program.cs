using ArticleApi.Consumer;
using InterventionsApi.Data;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'OrdersApiContext' not found.")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMassTransit(optinos => {
    optinos.AddConsumer<InterventionCreatedConsumer>();
    optinos.UsingRabbitMq((context, cnf) => {
        cnf.Host(new Uri("rabbitmq://localhost:4100"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cnf.ReceiveEndpoint("event-listener", e =>
        {
            e.ConfigureConsumer<InterventionCreatedConsumer>(context);
        });
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
