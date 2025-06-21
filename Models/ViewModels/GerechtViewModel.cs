namespace VlammendVarkenBackend.Models.ViewModels
{
    public class GerechtViewModel
    {
        public int Id { get; set; }

        public string Naam { get; set; } = string.Empty;

        public string Beschrijving { get; set; } = string.Empty;

        public double Prijs { get; set; }

        public string Category { get; set; } = string.Empty;

        // Optionele keuzemogelijkheden voor dit gerecht (namen van gerelateerde entiteiten)
        public string? Bijgerecht { get; set; }   // Naam van het bijgerecht (Gerecht)
        public string? Groente { get; set; }      // Naam van het groenteproduct (Product)
        public string? Saus { get; set; }         // Naam van het sausproduct (Product)
    }
}