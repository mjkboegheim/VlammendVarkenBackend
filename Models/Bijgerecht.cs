using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Bijgerecht
{
  [Column("bijgerechtId")]
  public int BijgerechtId { get; init; }
  
  [Column("naam")]
  [MaxLength(100)]
  public string Naam { get; init; } = null!;
  
  [Column("prijs")]
  public decimal Prijs { get; init; }

  public ICollection<BijgerechtAllergeen> BijgerechtAllergenen { get; init; } = new List<BijgerechtAllergeen>();
  public ICollection<GerechtSamenstelling> GerechtSamenstellingen { get; init; } = new List<GerechtSamenstelling>();
}
