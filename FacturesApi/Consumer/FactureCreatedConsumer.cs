using FacturesApi.Data;
using FacturesApi.Models;
using MassTransit;
using Shared;

namespace FacturesApi.Consumer
{
    public class FactureCreatedConsumer : IConsumer<FactureCreated>
    {
        private readonly ApplicationDbContext _context;
        public FactureCreatedConsumer(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Consume(ConsumeContext<FactureCreated> context)
        {
            var newProduct = new Facture
            {
                Id = context.Message.Id,
                InterventionId = context.Message.InterventionId,
                //Name = context.Message.Name
            };
            _context.Add(newProduct);
            await _context.SaveChangesAsync();  
        }
    }
}
