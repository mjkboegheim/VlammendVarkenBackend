using VlammendVarkenBackend.Controllers;

namespace VlammendVarkenBackend.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int ProductCategorieId { get; set; }
        public ProductCategorie? ProductCategorie { get; set; }
        public string Naam { get; set; } = string.Empty;
        public ICollection<Ingredient>? Ingrediënten { get; set; }
    }
}