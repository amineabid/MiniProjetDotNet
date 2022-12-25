using ArticleApi.Data;
using ArticleApi.Models;
using MassTransit;
using Shared;

namespace ArticleApi.Consumer
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
                Name = context.Message.Name
            };
            _context.Add(newProduct);
            await _context.SaveChangesAsync();  
        }
    }
}
