using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArticleApi.Models;

namespace ArticleApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Piece> Piece { get; set; } = default!;
        public DbSet<Article> Article { get; set; } = default!;
    }
}
