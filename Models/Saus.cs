using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Saus
{
  // ---------------------------------------------------------------------------------------------------------------- //
  [Column("id")]
  public int Id { get; init; }
  
  [Column("naam")]
  [MaxLength(100)]
  public string Naam { get; init; } = null!;
  
  [Column("prijs")]
  public decimal Prijs { get; init; }
  // ---------------------------------------------------------------------------------------------------------------- //
  public ICollection<SausAllergeen> Allergenen { get; init; } = new List<SausAllergeen>();
  public ICollection<GerechtSamenstelling> Samenstellingen { get; init; } = new List<GerechtSamenstelling>();
  // ---------------------------------------------------------------------------------------------------------------- //
}
