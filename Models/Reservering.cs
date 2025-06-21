using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    public class Reservering
    {
        [Column("reservering_id")]
        public int ReserveringId { get; set; }

        [Column("tafel_id")]
        public int? TafelId { get; set; }

        [Column("tafelgroep_id")]
        public int? TafelGroepId { get; set; }

        [Column("tijd")]
        public DateTime Tijd { get; set; }

        [Column("status")]
        public string Status { get; set; } = string.Empty;

        public Tafel? Tafel { get; set; }
        public TafelGroep? TafelGroep { get; set; }
        public ICollection<Bestelling>? Bestellingen { get; set; }
    }
}