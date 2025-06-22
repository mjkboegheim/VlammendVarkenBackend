using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    [Table("Ingredienten")]
    public class Ingredient
    {
        [Column("gerecht_id")]
        public int GerechtId { get; set; }
        public Gerecht? Gerecht { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Column("hoeveelheid", TypeName = "decimal(10, 2)")]
        public decimal Hoeveelheid { get; set; }
    }
}