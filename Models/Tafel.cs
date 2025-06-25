using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Tafel
{
    public int TafelId { get; set; }
    public int Nummer { get; set; }  // Tafel nummer (bijv. Tafel 1, Tafel 2, etc.)
        
    // Relatie naar TafelGroepTafel (veel-naar-veel)
    public ICollection<TafelGroepTafel> TafelGroepTafels { get; set; } = new List<TafelGroepTafel>();
        
    // Andere eigenschappen van de Tafel kunnen hier worden toegevoegd
}