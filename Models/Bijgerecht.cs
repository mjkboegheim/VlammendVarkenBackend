using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Bijgerecht
{
  [Column("bijgerechtId")]
  public int BijgerechtId { get; set; }
  
  [Column("naam")]
  [MaxLength(100)]
  public string Naam { get; set; } = null!;
  
  [Column("prijs")]
  public decimal Prijs { get; set; }

  public ICollection<BijgerechtAllergeen> BijgerechtAllergenen { get; set; } = new List<BijgerechtAllergeen>();
  public ICollection<GerechtSamenstelling> GerechtSamenstellingen { get; set; } = new List<GerechtSamenstelling>();
}
