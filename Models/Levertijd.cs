using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Levertijd
{
  [Column("levertijdId")]
  public int LevertijdId { get; set; }
  
  [Column("minuten")]
  public int Minuten { get; set; }

  public ICollection<Bestelling> Bestellingen { get; set; } = new List<Bestelling>();
}
