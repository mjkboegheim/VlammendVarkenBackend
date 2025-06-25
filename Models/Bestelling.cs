using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Bestelling
{
  [Column("bestellingId")]
  public int BestellingId { get; init; }
  
  [Column("levertijdId")]
  public int LevertijdId { get; init; }
  
  [Column("besteldatum")]
  public DateTime Besteldatum { get; init; }

  public Levertijd Levertijd { get; init; } = null!;

  public ICollection<BestellingGerecht> BestellingGerechten { get; init; } = new List<BestellingGerecht>();
  public ICollection<BestellingTafel> BestellingTafels { get; init; } = new List<BestellingTafel>();
}
