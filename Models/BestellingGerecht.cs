using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    [Table("BestellingGerechten")]
    public class BestellingGerecht
    {
        [Key]
        [Column("bestellinggerecht_id")]
        public int BestellingGerechtId { get; set; }

        [Column("bestelling_id")]
        public int BestellingId { get; set; }

        [ForeignKey("BestellingId")]
        public Bestelling Bestelling { get; set; } = null!;

        [Column("gerecht_id")]
        public int GerechtId { get; set; }

        [ForeignKey("GerechtId")]
        public Gerecht Gerecht { get; set; } = null!;

        [Column("serveren_na")]
        public int? ServerenNa { get; set; }
    }
}