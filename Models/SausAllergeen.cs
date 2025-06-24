using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class SausAllergeen
{
  [Column("sausId")]
  public int SausId { get; set; }
  
  [Column("allergeenId")]
  public int AllergeenId { get; set; }

  public Saus Saus { get; set; } = null!;
  public Allergeen Allergeen { get; set; } = null!;
}
