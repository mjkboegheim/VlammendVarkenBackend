using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using VlammendVarkenBackend.Models;

namespace VlammendVarkenBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tafel> Tafel { get; set; }
        public DbSet<TafelGroep> TafelGroep { get; set; }
        public DbSet<TafelGroepTafel> TafelGroepTafel { get; set; }
        public DbSet<Reservering> Reservering { get; set; }
        public DbSet<Bestelling> Bestelling { get; set; }
        public DbSet<Allergie> Allergie { get; set; }
        public DbSet<BestellingAllergie> BestellingAllergie { get; set; }
        public DbSet<GerechtCategorie> GerechtCategorie { get; set; }
        public DbSet<Gerecht> Gerecht { get; set; }
        public DbSet<BestellingGerecht> BestellingGerecht { get; set; }
        public DbSet<ProductCategorie> ProductCategorie { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Ingredient> Ingrediënt { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TafelGroepTafel>().HasKey(x => new { x.TafelGroepId, x.TafelId });
            modelBuilder.Entity<BestellingAllergie>().HasKey(x => new { x.BestellingId, x.AllergieId });
            modelBuilder.Entity<Ingredient>().HasKey(x => new { x.GerechtId, x.ProductId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
