using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    public class GerechtAllergie
    {
        [Column("gerecht_id")]
        public int GerechtId { get; set; }

        [Column("allergie_id")]
        public int AllergieId { get; set; }

        public Gerecht? Gerecht { get; set; }
        public Allergie? Allergie { get; set; }
    }
}