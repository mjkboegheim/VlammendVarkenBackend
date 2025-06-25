using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class GroenteAllergeen
{
  [Column("groenteId")]
  public int GroenteId { get; init; }
  
  [Column("allergeenId")]
  public int AllergeenId { get; init; }

  public Groente Groente { get; init; } = null!;
  public Allergeen Allergeen { get; init; } = null!;
}
