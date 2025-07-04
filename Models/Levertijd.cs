using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Levertijd
{
  // ---------------------------------------------------------------------------------------------------------------- //
  [Column("id")]
  public int Id { get; init; }
  
  [Column("minuten")]
  public int Minuten { get; init; }
  // ---------------------------------------------------------------------------------------------------------------- //
  public ICollection<Bestelling> Bestellingen { get; init; } = new List<Bestelling>();
  // ---------------------------------------------------------------------------------------------------------------- //
}
