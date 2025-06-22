using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    [Table("Allergieen")]
    public class Allergie
    {
        [Key]
        [Column("allergie_id")]
        public int AllergieId { get; set; }

        [Required]
        [Column("naam")]
        public string Naam { get; set; } = string.Empty;

        public ICollection<BestellingAllergie> BestellingAllergieen { get; set; } = new List<BestellingAllergie>();
        public ICollection<GerechtAllergie> GerechtAllergieen { get; set; } = new List<GerechtAllergie>();
    }
}