namespace VlammendVarkenBackend.Models
{
    public class Allergie
    {
        public int AllergieId { get; set; }
        public string Naam { get; set; } = string.Empty;
        public ICollection<BestellingAllergie>? BestellingAllergieën { get; set; }
    }
}