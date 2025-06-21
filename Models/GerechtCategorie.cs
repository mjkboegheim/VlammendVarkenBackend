using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    public class GerechtCategorie
    {
        [Column("gerechtcategorie_id")]
        public int GerechtCategorieId { get; set; }

        [Column("naam")]
        public string Naam { get; set; } = string.Empty;

        public ICollection<Gerecht>? Gerechten { get; set; }
    }
}