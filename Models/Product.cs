using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    public class Product
    {
        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("productcategorie_id")]
        public int ProductCategorieId { get; set; }

        [Column("naam")]
        public string Naam { get; set; } = string.Empty;

        public ProductCategorie? ProductCategorie { get; set; }
        public ICollection<Ingredient>? Ingrediënten { get; set; }
    }
}