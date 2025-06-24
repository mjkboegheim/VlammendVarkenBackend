using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class BijgerechtAllergeen
{
  [Column("bijgerechtId")]
  public int BijgerechtId { get; set; }
  
  [Column("allergeenId")]
  public int AllergeenId { get; set; }

  public Bijgerecht Bijgerecht { get; set; } = null!;
  public Allergeen Allergeen { get; set; } = null!;
}
