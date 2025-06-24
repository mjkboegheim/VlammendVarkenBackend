namespace VlammendVarkenBackend.Models.ViewModels;

public class GerechtViewModel
{
  public string Soort { get; set; } = null!;
  
  public string Naam { get; set; } = null!;
  
  public string Hoofdonderdeel { get; set; } = null!;
  
  public string Bijgerecht { get; set; } = null!;
  
  public string Groente { get; set; } = null!;
  
  public string Saus { get; set; } = null!;
  
  public List<AllergeenViewModel> Allergenen { get; set; } = new();
  
  public decimal Prijs { get; set; }
}
