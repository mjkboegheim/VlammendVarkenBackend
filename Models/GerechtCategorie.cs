namespace VlammendVarkenBackend.Models
{
    public class GerechtCategorie
    {
        public int GerechtCategorieId { get; set; }
        public string Naam { get; set; } = string.Empty;
        public ICollection<Gerecht>? Gerechten { get; set; }
    }
}