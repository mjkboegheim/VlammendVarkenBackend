using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Allergeen
{
  [Column("allergeenId")]
  public int AllergeenId { get; init; }
  
  [Column("symbool")]
  [MaxLength(100)]
  public string Symbool { get; init; } = null!;
  
  [Column("beschrijving")]
  [MaxLength(100)]
  public string Beschrijving { get; init; } = null!;

  public ICollection<HoofdonderdeelAllergeen> HoofdonderdeelAllergenen { get; init; } = new List<HoofdonderdeelAllergeen>();
  public ICollection<BijgerechtAllergeen> BijgerechtAllergenen { get; init; } = new List<BijgerechtAllergeen>();
  public ICollection<GroenteAllergeen> GroenteAllergenen { get; init; } = new List<GroenteAllergeen>();
  public ICollection<SausAllergeen> SausAllergenen { get; init; } = new List<SausAllergeen>();
}
