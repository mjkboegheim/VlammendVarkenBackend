using System.Collections.Generic;
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

        [Required]
        [Column("productcategorie_id")]
        public int ProductCategorieId { get; set; }

        [ForeignKey("ProductCategorieId")]
        public ProductCategorie ProductCategorie { get; set; } = null!;
        
        [Column("prijs", TypeName = "decimal(5, 2)")]
        public decimal Prijs { get; set; }
        
        [Required]
        [Column("naam")]
        public string Naam { get; set; } = string.Empty;

        public ICollection<Ingredient> Ingredienten { get; set; } = new List<Ingredient>();
    }
}