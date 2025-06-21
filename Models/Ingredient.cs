using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    public class Ingredient
    {
        [Column("gerecht_id")]
        public int GerechtId { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("hoeveelheid")]
        public double Hoeveelheid { get; set; }

        public Gerecht? Gerecht { get; set; }
        public Product? Product { get; set; }
    }
}