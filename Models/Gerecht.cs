using VlammendVarkenBackend.Controllers;

namespace VlammendVarkenBackend.Models
{
    public class Gerecht
    {
        public int GerechtId { get; set; }
        public int GerechtCategorieId { get; set; }
        public GerechtCategorie? GerechtCategorie { get; set; }
        public string Naam { get; set; } = string.Empty;
        public int Bereidingstijd { get; set; }
        public ICollection<Ingredient>? Ingrediënten { get; set; }
        public ICollection<BestellingGerecht>? BestellingGerechten { get; set; }
    }
}