using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    public class Gerecht
    {
        [Column("gerecht_id")]
        public int GerechtId { get; set; }

        [Column("gerechtcategorie_id")]
        public int GerechtCategorieId { get; set; }

        [Column("naam")]
        public string Naam { get; set; } = string.Empty;

        [Column("beschrijving")]
        public string? Beschrijving { get; set; }

        [Column("bereidingstijd")]
        public int Bereidingstijd { get; set; }

        [Column("prijs")]
        public decimal Prijs { get; set; }

        [Column("bijgerecht_id")]
        public int? BijgerechtId { get; set; }

        [Column("groente_id")]
        public int? GroenteId { get; set; }

        [Column("saus_id")]
        public int? SausId { get; set; }

        public GerechtCategorie? GerechtCategorie { get; set; }
        public Gerecht? Bijgerecht { get; set; }
        public Product? Groente { get; set; }
        public Product? Saus { get; set; }
        public ICollection<GerechtAllergie>? GerechtAllergieen { get; set; }
        public ICollection<Ingredient>? Ingredienten { get; set; }
    }
}