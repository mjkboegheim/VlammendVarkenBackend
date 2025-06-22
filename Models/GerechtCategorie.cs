using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    [Table("GerechtCategorieen")]
    public class GerechtCategorie
    {
        [Key]
        [Column("gerechtcategorie_id")]
        public int GerechtCategorieId { get; set; }

        [Required]
        [Column("naam")]
        public string Naam { get; set; } = string.Empty;

        // Navigation property to related dishes (never null)
        public ICollection<Gerecht> Gerechten { get; set; } = new List<Gerecht>();
    }
}