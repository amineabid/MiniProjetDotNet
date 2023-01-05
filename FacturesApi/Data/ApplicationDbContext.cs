
using Microsoft.EntityFrameworkCore;
using FacturesApi.Models;

namespace FacturesApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Reclamation> Reclamation { get; set; } = default!;
        public DbSet<Intervention> Intervention { get; set; } = default!;
        public DbSet<Article> Article { get; set; } = default!;
        public DbSet<Piece> Piece { get; set; } = default!;
        public DbSet<Facture> Facture { get; set; } = default!;
        public DbSet<LigneFacture> LigneFacture { get; set; } = default!;
    }
}
