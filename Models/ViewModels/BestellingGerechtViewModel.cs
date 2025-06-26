namespace VlammendVarkenBackend.Models.ViewModels
{
    public class BestellingGerechtViewModel
    {
        public string? GerechtNaam { get; set; }  // Nullable
        public string? Soort { get; set; }        // Nullable
        public string? BijgerechtNaam { get; set; } // Nullable
        public string? GroenteNaam { get; set; }    // Nullable
        public string? SausNaam { get; set; }      // Nullable
        public decimal Prijs { get; set; }        // Prijs kan niet nullable zijn
    }
}