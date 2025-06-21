using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    public class BestellingAllergie
    {
        [Column("bestelling_id")]
        public int BestellingId { get; set; }

        [Column("allergie_id")]
        public int AllergieId { get; set; }

        public Bestelling? Bestelling { get; set; }
        public Allergie? Allergie { get; set; }
    }
}