namespace VlammendVarkenBackend.ViewModels
{
    public class GerechtOverzichtViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; } = string.Empty;
        public decimal Prijs { get; set; }
        public string? Groente { get; set; }
        public string? Saus { get; set; }
        public string? Bijgerecht { get; set; }
        public List<string> Allergieen { get; set; } = new();
    }
}