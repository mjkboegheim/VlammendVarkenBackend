namespace VlammendVarkenBackend.Models.ViewModels;

public class GerechtViewModel
{
  public string Soort { get; init; } = null!;
  
  public string Naam { get; init; } = null!;
  
  public string Hoofdonderdeel { get; init; } = null!;
  
  public string Bijgerecht { get; init; } = null!;
  
  public string Groente { get; init; } = null!;
  
  public string Saus { get; init; } = null!;
  
  public List<AllergeenViewModel> Allergenen { get; init; } = new();
  
  public decimal Prijs { get; init; }
}
