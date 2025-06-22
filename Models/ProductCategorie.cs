using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    [Table("ProductCategorieen")]
    public class ProductCategorie
    {
        [Key]
        [Column("productcategorie_id")]
        public int ProductCategorieId { get; set; }

        [Required]
        [Column("naam")]
        public string Naam { get; set; } = string.Empty;

        // Navigatie-eigenschap
        public ICollection<Product> Producten { get; set; } = new List<Product>();
    }
}