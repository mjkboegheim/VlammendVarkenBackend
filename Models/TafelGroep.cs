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

        // Navigatie naar koppeltabel met tafels (many-to-many)
        public ICollection<TafelGroepTafel> TafelGroepTafels { get; set; } = new List<TafelGroepTafel>();

        // Optioneel: navigatie naar reserveringen (één-op-veel)
        public ICollection<Reservering> Reserveringen { get; set; } = new List<Reservering>();
    }
}