namespace VlammendVarkenBackend.ViewModels
{
    public class GerechtViewModel
    {
        public int GerechtId { get; set; }
        public string Naam { get; set; } = string.Empty;
        public string? Beschrijving { get; set; }
        public string Categorie { get; set; } = string.Empty;
        public decimal Prijs { get; set; }
        public int Bereidingstijd { get; set; }

        public string? BijgerechtNaam { get; set; }
        public string? GroenteNaam { get; set; }
        public string? SausNaam { get; set; }

        public List<string> Allergieen { get; set; } = new();
        public List<IngredientViewModel> Ingredienten { get; set; } = new();
    }
}