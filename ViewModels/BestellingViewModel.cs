namespace VlammendVarkenBackend.ViewModels
{
    public class BestellingViewModel
    {
        public int BestellingId { get; set; }
        public bool BesteldVoorgerecht { get; set; }
        public bool BesteldHoofdgerecht { get; set; }
        public bool BesteldNagerecht { get; set; }
        public bool IsVolwassen { get; set; }

        public List<AllergieViewModel> Allergieen { get; set; } = new();
        public List<GerechtViewModel> Gerechten { get; set; } = new();
    }
}