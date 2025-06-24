using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class BestellingTafel
{
  [Column("bestellingId")]
  public int BestellingId { get; set; }
  
  [Column("tafelId")]
  public int TafelId { get; set; }

  public Bestelling Bestelling { get; set; } = null!;
  public Tafel Tafel { get; set; } = null!;
}
