namespace VlammendVarkenBackend.Models
{
    public class Tafel
    {
        public int TafelId { get; set; }
        public ICollection<Reservering>? Reserveringen { get; set; }
        public ICollection<TafelGroepTafel>? TafelGroepTafels { get; set; }
    }

}