namespace VlammendVarkenBackend.Models
{
    public class Reservering
    {
        public int ReserveringId { get; set; }
        public int? TafelId { get; set; }
        public Tafel? Tafel { get; set; }
        public int? TafelGroepId { get; set; }
        public TafelGroep? TafelGroep { get; set; }
        public DateTime Tijd { get; set; }
        public string Status { get; set; } = string.Empty;
        public ICollection<Bestelling>? Bestellingen { get; set; }
    }
}