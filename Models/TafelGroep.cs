using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    [Table("TafelGroepen")]
    public class TafelGroep
    {
        [Key]
        [Column("tafelgroep_id")]
        public int TafelGroepId { get; set; }

        [Column("code")]
        public string Code { get; set; } = string.Empty;

        [Column("aantal_personen")]
        public int AantalPersonen { get; set; }
        
        // Navigation property for the many-to-many relationship
        public ICollection<TafelGroepTafel> TafelGroepTafels { get; set; } = new List<TafelGroepTafel>();
    }
}