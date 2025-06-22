using Microsoft.EntityFrameworkCore;
using VlammendVarkenBackend.Models;

namespace VlammendVarkenBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Allergie> Allergieen { get; set; }
        public DbSet<Bestelling> Bestellingen { get; set; }
        public DbSet<BestellingAllergie> BestellingAllergieen { get; set; }
        public DbSet<BestellingGerecht> BestellingGerechten { get; set; }
        public DbSet<Gerecht> Gerechten { get; set; }
        public DbSet<GerechtAllergie> GerechtAllergieen { get; set; }
        public DbSet<GerechtCategorie> GerechtCategorieen { get; set; }
        public DbSet<Ingredient> Ingredienten { get; set; }
        public DbSet<Product> Producten { get; set; }
        public DbSet<ProductCategorie> ProductCategorieen { get; set; }
        public DbSet<Reservering> Reserveringen { get; set; }
        public DbSet<Tafel> Tafels { get; set; }
        public DbSet<TafelGroep> TafelGroepen { get; set; }
        public DbSet<TafelGroepTafel> TafelGroepTafels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TafelGroepTafel>()
                .HasKey(t => new { t.TafelGroepId, t.TafelId });

            modelBuilder.Entity<Ingredient>()
                .HasKey(i => new { i.GerechtId, i.ProductId });

            modelBuilder.Entity<BestellingAllergie>()
                .HasKey(ba => new { ba.BestellingId, ba.AllergieId });

            modelBuilder.Entity<GerechtAllergie>()
                .HasKey(ga => new { ga.GerechtId, ga.AllergieId });

            modelBuilder.Entity<Gerecht>()
                .HasOne(g => g.Bijgerecht)
                .WithMany()
                .HasForeignKey(g => g.BijgerechtId)
                .OnDelete(DeleteBehavior.Restrict); // Om cirkelreferenties te voorkomen

            modelBuilder.Entity<Gerecht>()
                .HasOne(g => g.Groente)
                .WithMany()
                .HasForeignKey(g => g.GroenteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Gerecht>()
                .HasOne(g => g.Saus)
                .WithMany()
                .HasForeignKey(g => g.SausId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservering>()
                .HasOne(r => r.Tafel)
                .WithMany()
                .HasForeignKey(r => r.TafelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservering>()
                .HasOne(r => r.TafelGroep)
                .WithMany()
                .HasForeignKey(r => r.TafelGroepId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
