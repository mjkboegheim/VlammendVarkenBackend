namespace VlammendVarkenBackend.Models.ViewModels
{
    public class PersoneelBestellingDetailsViewModel
    {
        public int BestellingId { get; set; }
        public List<int> Tafelnummers { get; set; } = new();
        public DateTime Besteldatum { get; set; }

        // Maximaal aantal minuten bereidingstijd over alle gerechten
        public int BereidingstijdMinuten { get; set; }

        public string AftelTijd
        {
            get
            {
                // Format MM:ss, altijd 00 seconden erbij
                return $"{BereidingstijdMinuten:D2}:00";
            }
        }

        public List<BestellingGerechtViewModel> Gerechten { get; set; } = new();

        public List<string> Allergenen { get; set; } = new();
    }
}