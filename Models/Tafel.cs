using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models;

public class Tafel
{
    public int Id { get; set; }
    public int Nummer { get; set; }  // Tafel nummer (bijv. Tafel 1, Tafel 2, etc.)
        
    // Navigatie-eigenschap naar BestellingTafels
    public ICollection<BestellingTafel> BestellingTafels { get; set; } = new List<BestellingTafel>();
}