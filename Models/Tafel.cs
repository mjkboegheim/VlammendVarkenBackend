using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    [Table("Tafels")]
    public class Tafel
    {
        [Key]
        [Column("tafel_id")]
        public int TafelId { get; set; }

        // Eén tafel kan meerdere reserveringen hebben (indien geen groepsreservering)
        public ICollection<Reservering> Reserveringen { get; set; } = new List<Reservering>();

        // Navigatie naar koppeltabel met tafelgroepen
        public ICollection<TafelGroepTafel> TafelGroepTafels { get; set; } = new List<TafelGroepTafel>();
    }
}