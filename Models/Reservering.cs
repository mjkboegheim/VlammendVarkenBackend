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
        public int? TafelId { get; set; } // Nullable because a reservation can be for a group
        public Tafel? Tafel { get; set; }

        [Column("tafelgroep_id")]
        public int? TafelGroepId { get; set; } // Nullable because a reservation can be for a single table
        public TafelGroep? TafelGroep { get; set; }

        [Column("tijd")]
        public DateTime Tijd { get; set; }

        [Column("status")]
        public string Status { get; set; } = string.Empty;
        
        // Navigation property to related orders
        public ICollection<Bestelling> Bestellingen { get; set; } = new List<Bestelling>();
    }
}