using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    public class Tafel
    {
        [Column("tafel_id")]
        public int TafelId { get; set; }

        public ICollection<TafelGroepTafel>? TafelGroepTafels { get; set; }
    }
}