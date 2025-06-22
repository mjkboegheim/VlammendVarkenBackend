namespace VlammendVarkenBackend.ViewModels
{
    public class ReserveringViewModel
    {
        public int ReserveringId { get; set; }
        public DateTime Tijd { get; set; }
        public string Status { get; set; } = string.Empty;

        public int? TafelId { get; set; }
        public int? TafelGroepId { get; set; }

        public List<BestellingViewModel> Bestellingen { get; set; } = new();
    }
}