using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Gerecht
{
  [Column("gerechtId")]
  public int GerechtId { get; init; }
  
  [Column("soort")]
  [MaxLength(100)]
  public string Soort { get; init; } = null!;
  
  [Column("naam")]
  [MaxLength(100)]
  public string Naam { get; init; } = null!;

  public ICollection<GerechtSamenstelling> GerechtSamenstellingen { get; init; } = new List<GerechtSamenstelling>();
  public ICollection<BestellingGerecht> BestellingGerechten { get; init; } = new List<BestellingGerecht>();
}
