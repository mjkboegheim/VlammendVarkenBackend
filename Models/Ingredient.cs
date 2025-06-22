using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    [Table("Ingredienten")]
    public class Ingredient
    {
        [Column("gerecht_id")]
        public int GerechtId { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("hoeveelheid", TypeName = "decimal(10,2)")]
        public decimal Hoeveelheid { get; set; }

        // Navigatie-eigenschappen
        public Gerecht Gerecht { get; set; } = null!; // verplicht in DB
        public Product Product { get; set; } = null!; // verplicht in DB
    }
}