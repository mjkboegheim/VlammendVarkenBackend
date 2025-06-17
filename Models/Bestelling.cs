using VlammendVarkenBackend.Controllers;

namespace VlammendVarkenBackend.Models
{
    public class Bestelling
    {
        public int BestellingId { get; set; }
        public int ReserveringId { get; set; }
        public Reservering? Reservering { get; set; }
        public bool BesteldVoorgerecht { get; set; }
        public bool BesteldHoofdgerecht { get; set; }
        public bool BesteldNagerecht { get; set; }
        public bool IsVolwassen { get; set; }
        public ICollection<BestellingAllergie>? BestellingAllergieën { get; set; }
        public ICollection<BestellingGerecht>? BestellingGerechten { get; set; }
    }
}