using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Saus
{
  [Column("sausId")]
  public int SausId { get; init; }
  
  [Column("naam")]
  [MaxLength(100)]
  public string Naam { get; init; } = null!;
  
  [Column("prijs")]
  public decimal Prijs { get; init; }

  public ICollection<SausAllergeen> SausAllergenen { get; init; } = new List<SausAllergeen>();
  public ICollection<GerechtSamenstelling> GerechtSamenstellingen { get; init; } = new List<GerechtSamenstelling>();
}
