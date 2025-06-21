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

        [Column("bereidingstijd")]
        public int Bereidingstijd { get; set; }

        [Column("prijs")]
        public double Prijs { get; set; }

        [Column("bijgerecht_id")]
        public int? BijgerechtId { get; set; }

        [Column("groente_id")]
        public int? GroenteId { get; set; }

        [Column("saus_id")]
        public int? SausId { get; set; }

        public GerechtCategorie? GerechtCategorie { get; set; }

        [ForeignKey("BijgerechtId")]
        public Gerecht? Bijgerecht { get; set; }

        [ForeignKey("GroenteId")]
        public Product? Groente { get; set; }

        [ForeignKey("SausId")]
        public Product? Saus { get; set; }

        public ICollection<Ingredient>? Ingrediënten { get; set; }
        public ICollection<BestellingGerecht>? BestellingGerechten { get; set; }
    }
}