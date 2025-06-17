namespace VlammendVarkenBackend.Models
{
    public class BestellingAllergie
    {
        public int BestellingId { get; set; }
        public Bestelling? Bestelling { get; set; }
        public int AllergieId { get; set; }
        public Allergie? Allergie { get; set; }
    }

}