using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    [Table("Bestellingen")]
    public class Bestelling
    {
        [Key]
        [Column("bestelling_id")]
        public int BestellingId { get; set; }

        [Column("reservering_id")]
        public int ReserveringId { get; set; }
        public Reservering? Reservering { get; set; }

        [Column("besteld_voorgerecht")]
        public bool BesteldVoorgerecht { get; set; }

        [Column("besteld_hoofdgerecht")]
        public bool BesteldHoofdgerecht { get; set; }

        [Column("besteld_nagerecht")]
        public bool BesteldNagerecht { get; set; }

        [Column("is_volwassen")]
        public bool IsVolwassen { get; set; }
        
        // Navigation properties for many-to-many relationships
        public ICollection<BestellingGerecht> BestellingGerechten { get; set; } = new List<BestellingGerecht>();
        public ICollection<BestellingAllergie> BestellingAllergieen { get; set; } = new List<BestellingAllergie>();
    }
}