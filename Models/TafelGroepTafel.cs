using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    [Table("TafelGroepTafels")]
    public class TafelGroepTafel
    {
        [Column("tafelgroep_id")]
        public int TafelGroepId { get; set; }

        [ForeignKey(nameof(TafelGroepId))]
        public TafelGroep TafelGroep { get; set; } = null!;

        [Column("tafel_id")]
        public int TafelId { get; set; }

        [ForeignKey(nameof(TafelId))]
        public Tafel Tafel { get; set; } = null!;
    }
}