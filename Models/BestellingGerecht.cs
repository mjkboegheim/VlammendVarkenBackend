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
        public Bestelling? Bestelling { get; set; }

        [Column("gerecht_id")]
        public int GerechtId { get; set; }
        public Gerecht? Gerecht { get; set; }

        [Column("serveren_na")]
        public int? ServerenNa { get; set; }
    }
}