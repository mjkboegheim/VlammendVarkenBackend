namespace VlammendVarkenBackend.ViewModels
{
    public class GerechtViewModel
    {
        public int Id { get; set; }

        public string Naam { get; set; } = string.Empty;

        public string? Beschrijving { get; set; }

        public decimal Prijs { get; set; }

        public string Categorie { get; set; } = string.Empty;

        public string? Bijgerecht { get; set; }

        public string? Groente { get; set; }

        public string? Saus { get; set; }

        public List<string> Allergieen { get; set; } = new();
    }
}