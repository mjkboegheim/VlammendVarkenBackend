using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Tafel
{
  // ---------------------------------------------------------------------------------------------------------------- //
  [Column("id")]
  public int Id { get; init; }
  
  [Column("nummer")]
  public int Nummer { get; init; }
  // ---------------------------------------------------------------------------------------------------------------- //
  public ICollection<BestellingTafel> BestellingTafels { get; init; } = new List<BestellingTafel>();
  // ---------------------------------------------------------------------------------------------------------------- //
}
