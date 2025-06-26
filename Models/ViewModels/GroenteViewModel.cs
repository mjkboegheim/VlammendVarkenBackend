namespace VlammendVarkenBackend.Models.ViewModels;

public class GroenteViewModel
{
  // ---------------------------------------------------------------------------------------------------------------- //
  public string Naam { get; init; } = null!;
  
  public decimal Prijs { get; init; }
  // ---------------------------------------------------------------------------------------------------------------- //
  public List<AllergeenViewModel> Allergenen { get; init; } = new();
  // ---------------------------------------------------------------------------------------------------------------- //
}
