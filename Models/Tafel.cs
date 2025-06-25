using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Tafel
{
  [Column("tafelId")]
  public int TafelId { get; init; }
  
  [Column("nummer")]
  public int Nummer { get; init; }

  public ICollection<BestellingTafel> BestellingTafels { get; init; } = new List<BestellingTafel>();
}
