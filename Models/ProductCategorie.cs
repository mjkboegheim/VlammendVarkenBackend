using Microsoft.CodeAnalysis;

namespace VlammendVarkenBackend.Models
{
    public class ProductCategorie
    {
        public int ProductCategorieId { get; set; }
        public string Naam { get; set; } = string.Empty;
        public ICollection<Product>? Producten { get; set; }
    }
}