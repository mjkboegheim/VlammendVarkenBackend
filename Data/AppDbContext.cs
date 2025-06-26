using Microsoft.EntityFrameworkCore;
using VlammendVarkenBackend.Models;

namespace VlammendVarkenBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Allergeen> Allergenen { get; set; }
        public DbSet<Gerecht> Gerechten { get; set; }
        public DbSet<Hoofdonderdeel> Hoofdonderdelen { get; set; }
        public DbSet<Bijgerecht> Bijgerechten { get; set; }
        public DbSet<Groente> Groenten { get; set; }
        public DbSet<Saus> Sausen { get; set; }
        public DbSet<Tafel> Tafels { get; set; }
        public DbSet<Levertijd> Levertijden { get; set; }
        public DbSet<Bestelling> Bestellingen { get; set; }

        public DbSet<GerechtSamenstelling> GerechtSamenstellingen { get; set; }
        public DbSet<HoofdonderdeelAllergeen> HoofdonderdeelAllergenen { get; set; }
        public DbSet<BijgerechtAllergeen> BijgerechtAllergenen { get; set; }
        public DbSet<GroenteAllergeen> GroenteAllergenen { get; set; }
        public DbSet<SausAllergeen> SausAllergenen { get; set; }
        public DbSet<BestellingGerecht> BestellingGerechten { get; set; }
        public DbSet<BestellingTafel> BestellingTafels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuratie voor veel-op-veel relaties
            modelBuilder.Entity<GerechtSamenstelling>()
                .HasKey(gs => new { gs.GerechtId, gs.HoofdonderdeelId, gs.BijgerechtId, gs.GroenteId, gs.SausId });

            modelBuilder.Entity<HoofdonderdeelAllergeen>()
                .HasKey(ha => new { ha.HoofdonderdeelId, ha.AllergeenId });

            modelBuilder.Entity<BijgerechtAllergeen>()
                .HasKey(ba => new { ba.BijgerechtId, ba.AllergeenId });

            modelBuilder.Entity<GroenteAllergeen>()
                .HasKey(ga => new { ga.GroenteId, ga.AllergeenId });

            modelBuilder.Entity<SausAllergeen>()
                .HasKey(sa => new { sa.SausId, sa.AllergeenId });

            modelBuilder.Entity<BestellingGerecht>()
                .HasKey(bg => new { bg.BestellingId, bg.GerechtId });

            // Configuratie voor de relatie tussen Bestelling en BestellingTafel (veel-op-veel)
            modelBuilder.Entity<BestellingTafel>()
                .HasKey(bt => new { bt.BestellingId, bt.TafelId });  // Composite key van BestellingId en TafelId

            // Relatie tussen BestellingTafel en Bestelling
            modelBuilder.Entity<BestellingTafel>()
                .HasOne(bt => bt.Bestelling)
                .WithMany(b => b.BestellingTafels)  // Bestelling heeft BestellingTafels
                .HasForeignKey(bt => bt.BestellingId);  // Foreign key van BestellingId

            // Relatie tussen BestellingTafel en Tafel
            modelBuilder.Entity<BestellingTafel>()
                .HasOne(bt => bt.Tafel)
                .WithMany(t => t.BestellingTafels)  // Tafel heeft BestellingTafels
                .HasForeignKey(bt => bt.TafelId);  // Foreign key van TafelId
        }
    }
}
