using Microsoft.EntityFrameworkCore;
using VlammendVarkenBackend.Models;

namespace VlammendVarkenBackend.Data
{
  public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
  {
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
      
      modelBuilder.Entity<GerechtSamenstelling>()
        .HasKey(g => new { g.GerechtId, g.HoofdonderdeelId, g.BijgerechtId, g.GroenteId, g.SausId });

      modelBuilder.Entity<HoofdonderdeelAllergeen>()
        .HasKey(h => new { h.HoofdonderdeelId, h.AllergeenId });

      modelBuilder.Entity<BijgerechtAllergeen>()
        .HasKey(b => new { b.BijgerechtId, b.AllergeenId });

      modelBuilder.Entity<GroenteAllergeen>()
        .HasKey(g => new { g.GroenteId, g.AllergeenId });

      modelBuilder.Entity<SausAllergeen>()
        .HasKey(s => new { s.SausId, s.AllergeenId });

      modelBuilder.Entity<BestellingGerecht>()
        .HasKey(bg => new { bg.BestellingId, bg.GerechtId });

      modelBuilder.Entity<BestellingTafel>()
        .HasKey(bt => new { bt.BestellingId, bt.TafelId });
    }
  }
}
