using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    public class Tafelgroep
    {
        public int TafelGroepId { get; set; }
        public string Naam { get; set; }  // Naam van de tafelgroep (bijv. Groep A, Groep B, etc.)
        
        // Relatie naar TafelGroepTafel (veel-naar-veel)
        public ICollection<TafelGroepTafel> TafelGroepTafels { get; set; } = new List<TafelGroepTafel>();
        
        // Andere eigenschappen van de Tafelgroep kunnen hier worden toegevoegd
    }
}