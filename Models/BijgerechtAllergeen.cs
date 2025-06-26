using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class BijgerechtAllergeen
{
  // ---------------------------------------------------------------------------------------------------------------- //
  [Column("bijgerechtId")]
  public int BijgerechtId { get; init; }
  
  [Column("allergeenId")]
  public int AllergeenId { get; init; }
  // ---------------------------------------------------------------------------------------------------------------- //
  public Bijgerecht Bijgerecht { get; init; } = null!;
  public Allergeen Allergeen { get; init; } = null!;
  // ---------------------------------------------------------------------------------------------------------------- //
}
