using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Bestelling
{
  [Column("bestellingId")]
  public int BestellingId { get; set; }
  
  [Column("levertijdId")]
  public int LevertijdId { get; set; }
  
  [Column("besteldatum")]
  public DateTime Besteldatum { get; set; }

  public Levertijd Levertijd { get; set; } = null!;

  public ICollection<BestellingGerecht> BestellingGerechten { get; set; } = new List<BestellingGerecht>();
  public ICollection<BestellingTafel> BestellingTafels { get; set; } = new List<BestellingTafel>();
}
