using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class HoofdonderdeelAllergeen
{
  [Column("hoofdonderdeelId")]
  public int HoofdonderdeelId { get; set; }
  
  [Column("allergeenId")]
  public int AllergeenId { get; set; }

  public Hoofdonderdeel Hoofdonderdeel { get; set; } = null!;
  public Allergeen Allergeen { get; set; } = null!;
}
