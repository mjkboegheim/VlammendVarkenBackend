using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Hoofdonderdeel
{
  [Column("hoofdonderdeelId")]
  public int HoofdonderdeelId { get; set; }
  
  [Column("naam")]
  [MaxLength(100)]
  public string Naam { get; set; } = null!;
  
  [Column("prijs")]
  public decimal Prijs { get; set; }

  public ICollection<HoofdonderdeelAllergeen> HoofdonderdeelAllergenen { get; set; } = new List<HoofdonderdeelAllergeen>();
  public ICollection<GerechtSamenstelling> GerechtSamenstellingen { get; set; } = new List<GerechtSamenstelling>();
}
