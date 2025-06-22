using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    public class Allergie
    {
        [Column("allergie_id")]
        public int AllergieId { get; set; }

        [Column("naam")]
        public string Naam { get; set; } = string.Empty;

        public ICollection<BestellingAllergie>? BestellingAllergieen { get; set; }
        public ICollection<GerechtAllergie>? GerechtAllergieen { get; set; }
    }
}