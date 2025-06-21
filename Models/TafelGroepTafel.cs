using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    public class TafelGroepTafel
    {
        [Column("tafelgroep_id")]
        public int TafelGroepId { get; set; }

        [Column("tafel_id")]
        public int TafelId { get; set; }

        public TafelGroep? TafelGroep { get; set; }
        public Tafel? Tafel { get; set; }
    }
}