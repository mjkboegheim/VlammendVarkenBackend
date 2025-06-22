using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    [Table("TafelGroepTafels")]
    public class TafelGroepTafel
    {
        [Column("tafelgroep_id")]
        public int TafelGroepId { get; set; }
        public TafelGroep? TafelGroep { get; set; }

        [Column("tafel_id")]
        public int TafelId { get; set; }
        public Tafel? Tafel { get; set; }
    }
}