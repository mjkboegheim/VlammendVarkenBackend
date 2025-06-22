using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    [Table("Reserveringen")]
    public class Reservering
    {
        [Key]
        [Column("reservering_id")]
        public int ReserveringId { get; set; }

        [Column("tafel_id")]
        public int? TafelId { get; set; } // Optioneel
        public Tafel? Tafel { get; set; }

        [Column("tafelgroep_id")]
        public int? TafelGroepId { get; set; } // Optioneel
        public TafelGroep? TafelGroep { get; set; }

        [Required]
        [Column("tijd")]
        public DateTime Tijd { get; set; }

        [Required]
        [Column("status")]
        public string Status { get; set; } = string.Empty;

        // Navigation property naar bestellingen
        public ICollection<Bestelling> Bestellingen { get; set; } = new List<Bestelling>();
    }
}