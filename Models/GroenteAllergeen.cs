using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class GroenteAllergeen
{
  [Column("groenteId")]
  public int GroenteId { get; set; }
  
  [Column("allergeenId")]
  public int AllergeenId { get; set; }

  public Groente Groente { get; set; } = null!;
  public Allergeen Allergeen { get; set; } = null!;
}
