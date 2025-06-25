using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class BestellingGerecht
{
  [Column("bestellingId")]
  public int BestellingId { get; init; }
  
  [Column("gerechtId")]
  public int GerechtId { get; init; }

  public Bestelling Bestelling { get; init; } = null!;
  public Gerecht Gerecht { get; init; } = null!;
}
