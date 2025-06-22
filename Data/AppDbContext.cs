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

            // === Seeding: Categorieën ===
            modelBuilder.Entity<GerechtCategorie>().HasData(
                new GerechtCategorie { GerechtCategorieId = 1, Naam = "Voorgerechten" },
                new GerechtCategorie { GerechtCategorieId = 2, Naam = "Hoofdgerechten" },
                new GerechtCategorie { GerechtCategorieId = 3, Naam = "Bijgerechten" },
                new GerechtCategorie { GerechtCategorieId = 4, Naam = "Nagerechten" },
                new GerechtCategorie { GerechtCategorieId = 5, Naam = "Dagmenu" }
            );

            modelBuilder.Entity<ProductCategorie>().HasData(
                new ProductCategorie { ProductCategorieId = 1, Naam = "Vlees" },
                new ProductCategorie { ProductCategorieId = 2, Naam = "Vis" },
                new ProductCategorie { ProductCategorieId = 3, Naam = "Groenten" },
                new ProductCategorie { ProductCategorieId = 4, Naam = "Zuivel" },
                new ProductCategorie { ProductCategorieId = 5, Naam = "Overige" },
                new ProductCategorie { ProductCategorieId = 6, Naam = "Sauzen" }
            );

            // === Seeding: Producten ===
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductCategorieId = 1, Naam = "Ribeye" },
                new Product { ProductId = 2, ProductCategorieId = 1, Naam = "Kipfilet" },
                new Product { ProductId = 3, ProductCategorieId = 1, Naam = "Varkenshaas" },
                new Product { ProductId = 4, ProductCategorieId = 1, Naam = "BBQ-Worst" },
                new Product { ProductId = 5, ProductCategorieId = 2, Naam = "Garnalen" },
                new Product { ProductId = 6, ProductCategorieId = 3, Naam = "Paprika" },
                new Product { ProductId = 7, ProductCategorieId = 3, Naam = "Maïs" },
                new Product { ProductId = 8, ProductCategorieId = 3, Naam = "Sla" },
                new Product { ProductId = 9, ProductCategorieId = 4, Naam = "Feta" },
                new Product { ProductId = 10, ProductCategorieId = 4, Naam = "Vanille-ijs" },
                new Product { ProductId = 11, ProductCategorieId = 5, Naam = "Brownie" },
                new Product { ProductId = 12, ProductCategorieId = 5, Naam = "Burgerbroodje" },
                new Product { ProductId = 13, ProductCategorieId = 6, Naam = "BBQ-Saus" }
            );

            // === Seeding: Gerechten ===
            modelBuilder.Entity<Gerecht>().HasData(
                new Gerecht { GerechtId = 1, GerechtCategorieId = 1, Naam = "Gegrilde Paprika met Feta", Beschrijving = "Geroosterde paprika met romige feta", Bereidingstijd = 12, Prijs = 7.50m },
                new Gerecht { GerechtId = 2, GerechtCategorieId = 1, Naam = "Spies van Garnalen", Beschrijving = "Gegrilde spies met gemarineerde garnalen", Bereidingstijd = 15, Prijs = 9.00m },
                new Gerecht { GerechtId = 3, GerechtCategorieId = 2, Naam = "Ribeye van de Grill", Beschrijving = "Perfect gegrilde ribeye met een rijke smaak", Bereidingstijd = 25, Prijs = 21.00m },
                new Gerecht { GerechtId = 4, GerechtCategorieId = 2, Naam = "Mixed Grill (Kip, Varkenshaas, Worst)", Beschrijving = "Combinatie van gegrild vlees", Bereidingstijd = 30, Prijs = 24.50m },
                new Gerecht { GerechtId = 5, GerechtCategorieId = 3, Naam = "Gegrilde Maïskolf", Beschrijving = "Maïskolf met rokerige grillsmaak", Bereidingstijd = 10, Prijs = 4.50m },
                new Gerecht { GerechtId = 6, GerechtCategorieId = 4, Naam = "Brownie met Vanille-ijs", Beschrijving = "Warme brownie met romig ijs", Bereidingstijd = 10, Prijs = 6.50m },
                new Gerecht { GerechtId = 7, GerechtCategorieId = 5, Naam = "Dagmenu: BBQ Burger & Cheesecake", Beschrijving = "Ons zorgvuldig samengesteld dagmenu.", Bereidingstijd = 35, Prijs = 19.50m, BijgerechtId = 5, GroenteId = 8, SausId = 13 }
            );

            // === Seeding: Ingrediënten ===
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { GerechtId = 1, ProductId = 6, Hoeveelheid = 0.50m },
                new Ingredient { GerechtId = 1, ProductId = 9, Hoeveelheid = 0.30m },
                new Ingredient { GerechtId = 2, ProductId = 5, Hoeveelheid = 0.70m },
                new Ingredient { GerechtId = 3, ProductId = 1, Hoeveelheid = 1.00m },
                new Ingredient { GerechtId = 4, ProductId = 2, Hoeveelheid = 0.50m },
                new Ingredient { GerechtId = 4, ProductId = 3, Hoeveelheid = 0.40m },
                new Ingredient { GerechtId = 4, ProductId = 4, Hoeveelheid = 0.40m },
                new Ingredient { GerechtId = 5, ProductId = 7, Hoeveelheid = 1.00m },
                new Ingredient { GerechtId = 6, ProductId = 11, Hoeveelheid = 1.00m },
                new Ingredient { GerechtId = 6, ProductId = 10, Hoeveelheid = 0.50m },
                new Ingredient { GerechtId = 7, ProductId = 12, Hoeveelheid = 1.00m },
                new Ingredient { GerechtId = 7, ProductId = 2, Hoeveelheid = 0.40m },
                new Ingredient { GerechtId = 7, ProductId = 11, Hoeveelheid = 0.50m }
            );

            // === Seeding: Tafels en Groepen ===
            modelBuilder.Entity<Tafel>().HasData(
                new Tafel { TafelId = 1 },
                new Tafel { TafelId = 2 },
                new Tafel { TafelId = 3 }
            );

            modelBuilder.Entity<TafelGroep>().HasData(
                new TafelGroep { TafelGroepId = 1, Code = "G1", AantalPersonen = 2 },
                new TafelGroep { TafelGroepId = 2, Code = "G2", AantalPersonen = 4 }
            );

            modelBuilder.Entity<TafelGroepTafel>().HasData(
                new TafelGroepTafel { TafelGroepId = 1, TafelId = 1 },
                new TafelGroepTafel { TafelGroepId = 2, TafelId = 2 },
                new TafelGroepTafel { TafelGroepId = 2, TafelId = 3 }
            );

            // === Seeding: Allergieën ===
            modelBuilder.Entity<Allergie>().HasData(
                new Allergie { AllergieId = 1, Naam = "Gluten" },
                new Allergie { AllergieId = 2, Naam = "Lactose" },
                new Allergie { AllergieId = 3, Naam = "Schaaldieren" }
            );

            modelBuilder.Entity<GerechtAllergie>().HasData(
                new GerechtAllergie { GerechtId = 2, AllergieId = 3 },
                new GerechtAllergie { GerechtId = 6, AllergieId = 2 },
                new GerechtAllergie { GerechtId = 7, AllergieId = 1 }
            );
        }
    }
}
