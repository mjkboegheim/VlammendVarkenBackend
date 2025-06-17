namespace VlammendVarkenBackend.Models
{
    public class TafelGroep
    {
        public int TafelGroepId { get; set; }
        public string Code { get; set; } = string.Empty;
        public int AantalPersonen { get; set; }
        public ICollection<TafelGroepTafel>? TafelGroepTafels { get; set; }
        public ICollection<Reservering>? Reserveringen { get; set; }
    }
}