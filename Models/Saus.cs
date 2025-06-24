using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Saus
{
  [Column("sausId")]
  public int SausId { get; set; }
  
  [Column("naam")]
  [MaxLength(100)]
  public string Naam { get; set; } = null!;
  
  [Column("prijs")]
  public decimal Prijs { get; set; }

  public ICollection<SausAllergeen> SausAllergenen { get; set; } = new List<SausAllergeen>();
  public ICollection<GerechtSamenstelling> GerechtSamenstellingen { get; set; } = new List<GerechtSamenstelling>();
}
