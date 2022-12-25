using ReclameClientApi.Data;
using ReclameClientApi.Models;
using MassTransit;
using Shared;

namespace ReclameClientApi.Consumer
{
    public class ReclamationCreatedConsumer : IConsumer<ReclamationCreated>
    {
        private readonly ApplicationDbContext _context;
        public ReclamationCreatedConsumer(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Consume(ConsumeContext<ReclamationCreated> context)
        {
            var newProduct = new Reclamation
            {
                Name = context.Message.Name,
                Email = context.Message.Email,
                Description = context.Message.Description,
                ArticleId = context.Message.ArticleId
            };
            _context.Add(newProduct);
            await _context.SaveChangesAsync();  
        }
    }
}