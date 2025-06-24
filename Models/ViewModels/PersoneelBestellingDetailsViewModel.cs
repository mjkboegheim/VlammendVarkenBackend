namespace VlammendVarkenBackend.Models.ViewModels
{

    public class PersoneelBestellingDetailsViewModel
    {
        public int BestellingId { get; set; }
        public List<int> Tafelnummers { get; set; } = new();
        public DateTime Besteldatum { get; set; }
        public int BereidingstijdMinuten { get; set; }
        public string AftelTijd 
        {
            get
            {
                // Default "MM:ss" string op basis van BereidingstijdMinuten
                return $"{BereidingstijdMinuten:D2}:00";
            }
        }
        public List<BestellingGerechtViewModel> Gerechten { get; set; } = new();
    }
}