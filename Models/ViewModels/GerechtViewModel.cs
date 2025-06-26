namespace VlammendVarkenBackend.Models.ViewModels;

public class GerechtViewModel
{
  // ---------------------------------------------------------------------------------------------------------------- //
  public int Id { get; init; }
  
  public string Soort { get; init; } = null!;
  
  public string Naam { get; init; } = null!;
  
  public decimal Prijs { get; init; }
  // ---------------------------------------------------------------------------------------------------------------- //
  public List<HoofdonderdeelViewModel> Hoofdonderdelen { get; init; } = new();
  public List<BijgerechtViewModel> Bijgerechten { get; init; } = new();
  public List<GroenteViewModel> Groenten { get; init; } = new();
  public List<SausViewModel> Sausen { get; init; } = new();
  // ---------------------------------------------------------------------------------------------------------------- //
}
