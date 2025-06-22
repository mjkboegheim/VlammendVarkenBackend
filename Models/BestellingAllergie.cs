using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    [Table("BestellingAllergieen")]
    public class BestellingAllergie
    {
        [Column("bestelling_id")]
        public int BestellingId { get; set; }
        public Bestelling? Bestelling { get; set; }

        [Column("allergie_id")]
        public int AllergieId { get; set; }
        public Allergie? Allergie { get; set; }
    }
}