namespace VlammendVarkenBackend.Models.ViewModels
{
    public class BestellingOverzichtViewModel
    {
        public int BestellingId { get; set; }
        public List<int> Tafelnummers { get; set; } = new();
        public List<string> Tafelgroepen { get; set; } = new();  // Toegevoegd

        public DateTime Besteldatum { get; set; }
        public int AantalGasten { get; set; } = 0; // Simpel voorbeeld, kan je zelf vullen
        public bool HeeftAttentie { get; set; } = false; // Simpel voorbeeld, kan je zelf vullen
        public int BereidingstijdMinuten { get; set; }

        // Optioneel: default timer string "MM:00"
        public string AftelTijd
        {
            get
            {
                return $"{BereidingstijdMinuten:D2}:00";
            }
        }
        public List<string> Allergenen { get; set; } = new();
    }
}