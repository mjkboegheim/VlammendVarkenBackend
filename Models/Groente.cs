using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Groente
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
  public ICollection<GroenteAllergeen> Allergenen { get; init; } = new List<GroenteAllergeen>();
  public ICollection<GerechtSamenstelling> Samenstellingen { get; init; } = new List<GerechtSamenstelling>();
  // ---------------------------------------------------------------------------------------------------------------- //
}
