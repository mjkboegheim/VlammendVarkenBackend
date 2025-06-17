namespace VlammendVarkenBackend.Models
{
    public class BestellingGerecht
    {
        public int BestellingGerechtId { get; set; }
        public int BestellingId { get; set; }
        public Bestelling? Bestelling { get; set; }
        public int GerechtId { get; set; }
        public Gerecht? Gerecht { get; set; }
        public int? ServerenNa { get; set; }
    }
}