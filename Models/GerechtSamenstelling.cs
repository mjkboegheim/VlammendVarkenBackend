using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class GerechtSamenstelling
{
  [Column("gerechtId")]
  public int GerechtId { get; set; }
  
  [Column("hoofdonderdeelId")]
  public int HoofdonderdeelId { get; set; }
  
  [Column("bijgerechtId")]
  public int BijgerechtId { get; set; }
  
  [Column("groenteId")]
  public int GroenteId { get; set; }
  
  [Column("sausId")]
  public int SausId { get; set; }

  public Gerecht Gerecht { get; set; } = null!;
  public Hoofdonderdeel Hoofdonderdeel { get; set; } = null!;
  public Bijgerecht Bijgerecht { get; set; } = null!;
  public Groente Groente { get; set; } = null!;
  public Saus Saus { get; set; } = null!;
}
