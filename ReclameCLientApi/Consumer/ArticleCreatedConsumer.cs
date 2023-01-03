using ReclameClientApi.Data;
using ReclameClientApi.Models;
using MassTransit;
using Shared;

namespace ReclameClientApi.Consumer
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
