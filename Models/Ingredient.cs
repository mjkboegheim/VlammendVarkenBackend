namespace VlammendVarkenBackend.Models
{
    public class Ingredient
    {
        public int GerechtId { get; set; }
        public Gerecht? Gerecht { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public decimal Hoeveelheid { get; set; }
    }
}