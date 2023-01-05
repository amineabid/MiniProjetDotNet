using ReclameClientApi.Data;
using ReclameClientApi.Models;
using MassTransit;
using Shared;
using Microsoft.EntityFrameworkCore;

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
            if (context.Message.action == "Add")
            {
                var newProduct = new Article
                {
                    Id = context.Message.Id,
                    Name = context.Message.Name
                };
                _context.Add(newProduct);
                await _context.SaveChangesAsync();
            }
            else if (context.Message.action == "Delete")
            {
                var deleted = await _context.Article.FirstOrDefaultAsync(a => a.Id == context.Message.Id);
                _context.Article.Remove(deleted);
                await _context.SaveChangesAsync();
            }
            else if (context.Message.action == "Put")
            {
                var updated = await _context.Article.FirstOrDefaultAsync(a => a.Id == context.Message.Id);
                updated.Name = context.Message.Name;
                _context.Article.Update(updated);
                await _context.SaveChangesAsync();
            }
        }
    }
}
