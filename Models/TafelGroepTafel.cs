using VlammendVarkenBackend.Controllers;

namespace VlammendVarkenBackend.Models
{
    public class TafelGroepTafel
    {
        public int TafelGroepId { get; set; }
        public TafelGroep? TafelGroep { get; set; }
        public int TafelId { get; set; }
        public Tafel? Tafel { get; set; }
    }
}