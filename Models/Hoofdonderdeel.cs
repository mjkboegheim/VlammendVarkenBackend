using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Hoofdonderdeel
{
  [Column("hoofdonderdeelId")]
  public int HoofdonderdeelId { get; init; }
  
  [Column("naam")]
  [MaxLength(100)]
  public string Naam { get; init; } = null!;
  
  [Column("prijs")]
  public decimal Prijs { get; init; }

  public ICollection<HoofdonderdeelAllergeen> HoofdonderdeelAllergenen { get; init; } = new List<HoofdonderdeelAllergeen>();
  public ICollection<GerechtSamenstelling> GerechtSamenstellingen { get; init; } = new List<GerechtSamenstelling>();
}
