namespace VlammendVarkenBackend.Models.ViewModels;

public class BestellingOverzichtViewModel
{
    public int BestellingId { get; set; }
    public List<int> Tafelnummers { get; set; } = new();
    public DateTime Besteldatum { get; set; }
    public int AantalGasten { get; set; } = 0; // Simpel voorbeeld, kan je zelf vullen
    public bool HeeftAttentie { get; set; } = false; // Simpel voorbeeld, kan je zelf vullen
    public int BereidingstijdMinuten { get; set; }
}
