using InterventionsApi.Data;
using InterventionsApi.Models;
using MassTransit;
using Shared;

namespace InterventionsApi.Consumer
{
    public class ArticleCreatedConsumer : IConsumer<ArticleCreated>
    {
        private readonly ApplicationDbContext _context;
        public ArticleCreatedConsumer(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Consume(ConsumeContext<ArticleCreated> context)
        {
            var newProduct = new Article
            {
                Id = context.Message.Id,
                Name = context.Message.Name
            };
            _context.Add(newProduct);
            await _context.SaveChangesAsync();  
        }
    }
}
