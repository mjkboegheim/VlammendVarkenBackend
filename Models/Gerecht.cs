using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    [Table("Gerechten")]
    public class Gerecht
    {
        [Key]
        [Column("gerecht_id")]
        public int GerechtId { get; set; }

        [Column("gerechtcategorie_id")]
        public int GerechtCategorieId { get; set; }
        public GerechtCategorie? GerechtCategorie { get; set; }

        [Column("naam")]
        public string Naam { get; set; } = string.Empty;

        [Column("beschrijving")]
        public string? Beschrijving { get; set; }

        [Column("bereidingstijd")]
        public int Bereidingstijd { get; set; }

        [Column("prijs", TypeName = "decimal(5, 2)")]
        public decimal Prijs { get; set; }

        [Column("bijgerecht_id")]
        public int? BijgerechtId { get; set; }
        [ForeignKey("BijgerechtId")]
        public Gerecht? Bijgerecht { get; set; }

        [Column("groente_id")]
        public int? GroenteId { get; set; }
        [ForeignKey("GroenteId")]
        public Product? Groente { get; set; }

        [Column("saus_id")]
        public int? SausId { get; set; }
        [ForeignKey("SausId")]
        public Product? Saus { get; set; }

        // Navigation properties for many-to-many relationships
        public ICollection<Ingredient> Ingredienten { get; set; } = new List<Ingredient>();
        public ICollection<BestellingGerecht> BestellingGerechten { get; set; } = new List<BestellingGerecht>();
        public ICollection<GerechtAllergie> GerechtAllergieen { get; set; } = new List<GerechtAllergie>();
    }
}