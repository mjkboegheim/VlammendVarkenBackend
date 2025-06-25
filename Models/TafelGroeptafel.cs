using System.ComponentModel.DataAnnotations.Schema;

namespace VlammendVarkenBackend.Models
{
    public class TafelGroepTafel
    {
        public int TafelGroepId { get; set; }
        public Tafelgroep Tafelgroep { get; set; }  // Navigatie naar Tafelgroep

        public int TafelId { get; set; }
        public Tafel Tafel { get; set; }  // Navigatie naar Tafel
    }
}