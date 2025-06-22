using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    [Table("GerechtAllergieen")]
    public class GerechtAllergie
    {
        [Column("gerecht_id")]
        public int GerechtId { get; set; }

        [ForeignKey("GerechtId")]
        public Gerecht Gerecht { get; set; } = null!;

        [Column("allergie_id")]
        public int AllergieId { get; set; }

        [ForeignKey("AllergieId")]
        public Allergie Allergie { get; set; } = null!;
    }
}