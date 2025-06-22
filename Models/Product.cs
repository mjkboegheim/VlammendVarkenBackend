using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    [Table("Producten")]
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("productcategorie_id")]
        public int ProductCategorieId { get; set; }
        public ProductCategorie? ProductCategorie { get; set; }
        
        [Column("naam")]
        public string Naam { get; set; } = string.Empty;

        // Navigation property for the many-to-many relationship with Gerecht
        public ICollection<Ingredient> Ingredienten { get; set; } = new List<Ingredient>();
    }
}