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
    }
}