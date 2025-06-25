using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class SausAllergeen
{
  [Column("sausId")]
  public int SausId { get; init; }
  
  [Column("allergeenId")]
  public int AllergeenId { get; init; }

  public Saus Saus { get; init; } = null!;
  public Allergeen Allergeen { get; init; } = null!;
}
