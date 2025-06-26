using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class BestellingTafel
{
    [Column("bestellingId")]
    public int BestellingId { get; init; }
    
    [Column("tafelId")]
    public int TafelId { get; init; }

    public Bestelling Bestelling { get; init; } = null!;
    public Tafel Tafel { get; init; } = null!;
}
