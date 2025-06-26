using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Bestelling
{
  // ---------------------------------------------------------------------------------------------------------------- //
  [Column("id")]
  public int Id { get; init; }
  
  [Column("levertijdId")]
  public int LevertijdId { get; init; }
  
  [Column("besteldatum")]
  public DateTime Besteldatum { get; init; }
  // ---------------------------------------------------------------------------------------------------------------- //
  public Levertijd Levertijd { get; init; } = null!;
  // ---------------------------------------------------------------------------------------------------------------- //
  public ICollection<BestellingGerecht> Gerechten { get; init; } = new List<BestellingGerecht>();
  public ICollection<BestellingTafel> Tafels { get; init; } = new List<BestellingTafel>();
  // ---------------------------------------------------------------------------------------------------------------- //
}
