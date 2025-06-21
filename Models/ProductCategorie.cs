using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    public class ProductCategorie
    {
        [Column("productcategorie_id")]
        public int ProductCategorieId { get; set; }

        [Column("naam")]
        public string Naam { get; set; } = string.Empty;

        public ICollection<Product>? Producten { get; set; }
    }
}