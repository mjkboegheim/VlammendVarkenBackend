using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class GerechtSamenstelling
{
  // ---------------------------------------------------------------------------------------------------------------- //
  [Column("gerechtId")]
  public int GerechtId { get; init; }
  
  [Column("hoofdonderdeelId")]
  public int HoofdonderdeelId { get; init; }
  
  [Column("bijgerechtId")]
  public int BijgerechtId { get; init; }
  
  [Column("groenteId")]
  public int GroenteId { get; init; }
  
  [Column("sausId")]
  public int SausId { get; init; }
  // ---------------------------------------------------------------------------------------------------------------- //
  public Gerecht Gerecht { get; init; } = null!;
  public Hoofdonderdeel Hoofdonderdeel { get; init; } = null!;
  public Bijgerecht Bijgerecht { get; init; } = null!;
  public Groente Groente { get; init; } = null!;
  public Saus Saus { get; init; } = null!;
  // ---------------------------------------------------------------------------------------------------------------- //
}
