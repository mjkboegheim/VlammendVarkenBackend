using Microsoft.EntityFrameworkCore;
using VlammendVarkenBackend.Models;

namespace VlammendVarkenBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Tabellen
        public DbSet<Allergie> Allergieen { get; set; }
        public DbSet<Bestelling> Bestellingen { get; set; }
        public DbSet<Gerecht> Gerechten { get; set; }
        public DbSet<GerechtCategorie> GerechtCategorieen { get; set; }
        public DbSet<Product> Producten { get; set; }
        public DbSet<ProductCategorie> ProductCategorieen { get; set; }
        public DbSet<Reservering> Reserveringen { get; set; }
        public DbSet<Tafel> Tafels { get; set; }
        public DbSet<TafelGroep> TafelGroepen { get; set; }

        // Koppeltabellen
        public DbSet<GerechtAllergie> GerechtAllergieen { get; set; }
        public DbSet<Ingredient> Ingredienten { get; set; }
        public DbSet<TafelGroepTafel> TafelGroepTafels { get; set; }
        public DbSet<BestellingAllergie> BestellingAllergieen { get; set; }
        public DbSet<BestellingGerecht> BestellingGerechten { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // === Primary Keys voor koppeltabellen ===
            modelBuilder.Entity<GerechtAllergie>().HasKey(ga => new { ga.GerechtId, ga.AllergieId });
            modelBuilder.Entity<Ingredient>().HasKey(i => new { i.GerechtId, i.ProductId });
            modelBuilder.Entity<TafelGroepTafel>().HasKey(tgt => new { tgt.TafelGroepId, tgt.TafelId });
            modelBuilder.Entity<BestellingAllergie>().HasKey(ba => new { ba.BestellingId, ba.AllergieId });
            modelBuilder.Entity<BestellingGerecht>().HasKey(bg => new { bg.BestellingId, bg.GerechtId });

            // === Relatie: Gerecht ↔ Bijgerecht (self reference) ===
            modelBuilder.Entity<Gerecht>()
                .HasOne(g => g.Bijgerecht)
                .WithMany()
                .HasForeignKey(g => g.BijgerechtId)
                .OnDelete(DeleteBehavior.Restrict);

            // === Relatie: Ingredient → Product (FK verplicht) ===
            modelBuilder.Entity<Ingredient>()
                .HasOne(i => i.Product)
                .WithMany(p => p.Ingredienten)
                .HasForeignKey(i => i.ProductId)
                .IsRequired();

            // === Relatie: Product → ProductCategorie (FK verplicht) ===
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductCategorie)
                .WithMany(pc => pc.Producten)
                .HasForeignKey(p => p.ProductCategorieId)
                .IsRequired();
        }
    }
}
