using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    public class TafelGroep
    {
        [Column("tafelgroep_id")]
        public int TafelGroepId { get; set; }

        [Column("code")]
        public string Code { get; set; } = string.Empty;

        [Column("aantal_personen")]
        public int AantalPersonen { get; set; }

        public ICollection<TafelGroepTafel>? TafelGroepTafels { get; set; }
    }
}