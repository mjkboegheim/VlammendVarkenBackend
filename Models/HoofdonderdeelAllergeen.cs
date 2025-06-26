using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class HoofdonderdeelAllergeen
{
  // ---------------------------------------------------------------------------------------------------------------- //
  [Column("hoofdonderdeelId")]
  public int HoofdonderdeelId { get; init; }
  
  [Column("allergeenId")]
  public int AllergeenId { get; init; }
  // ---------------------------------------------------------------------------------------------------------------- //
  public Hoofdonderdeel Hoofdonderdeel { get; init; } = null!;
  public Allergeen Allergeen { get; init; } = null!;
  // ---------------------------------------------------------------------------------------------------------------- //
}
