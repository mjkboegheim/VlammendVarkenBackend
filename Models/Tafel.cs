using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Tafel
{
  [Column("tafelId")]
  public int TafelId { get; set; }
  
  [Column("nummer")]
  public int Nummer { get; set; }

  public ICollection<BestellingTafel> BestellingTafels { get; set; } = new List<BestellingTafel>();
}
