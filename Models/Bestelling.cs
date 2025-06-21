using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    public class Bestelling
    {
        [Column("bestelling_id")]
        public int BestellingId { get; set; }

        [Column("reservering_id")]
        public int ReserveringId { get; set; }

        [Column("besteld_voorgerecht")]
        public int? BesteldVoorgerecht { get; set; }

        [Column("besteld_hoofdgerecht")]
        public int? BesteldHoofdgerecht { get; set; }

        [Column("besteld_nagerecht")]
        public int? BesteldNagerecht { get; set; }

        [Column("is_volwassen")]
        public bool IsVolwassen { get; set; }

        public Reservering? Reservering { get; set; }
        public ICollection<BestellingAllergie>? Allergieën { get; set; }
        public ICollection<BestellingGerecht>? Gerechten { get; set; }
    }
}