using InterventionsApi.Data;
using InterventionsApi.Models;
using MassTransit;
using Shared;

namespace InterventionsApi.Consumer
{
    public class InterventionCreatedConsumer : IConsumer<InterventionCreated>
    {
        private readonly ApplicationDbContext _context;
        public InterventionCreatedConsumer(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Consume(ConsumeContext<InterventionCreated> context)
        {
            var newProduct = new Intervention
            {
                Description = context.Message.Description,
                garantie = context.Message.garnatie,
                ReclamationId = context.Message.ReclamationId
            };
            _context.Add(newProduct);
            await _context.SaveChangesAsync();  
        }
    }
}