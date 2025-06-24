using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Groente
{
  [Column("groenteId")]
  public int GroenteId { get; set; }
  
  [Column("naam")]
  [MaxLength(100)]
  public string Naam { get; set; } = null!;
  
  [Column("prijs")]
  public decimal Prijs { get; set; }

  public ICollection<GroenteAllergeen> GroenteAllergenen { get; set; } = new List<GroenteAllergeen>();
  public ICollection<GerechtSamenstelling> GerechtSamenstellingen { get; set; } = new List<GerechtSamenstelling>();
}
