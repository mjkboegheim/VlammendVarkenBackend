using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    [Table("BestellingAllergieen")]
    public class BestellingAllergie
    {
        [Column("bestelling_id")]
        public int BestellingId { get; set; }

        [ForeignKey("BestellingId")]
        public Bestelling Bestelling { get; set; } = null!;

        [Column("allergie_id")]
        public int AllergieId { get; set; }

        [ForeignKey("AllergieId")]
        public Allergie Allergie { get; set; } = null!;
    }
}