using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VlammendVarkenBackend.Data;
using VlammendVarkenBackend.Models;
using VlammendVarkenBackend.Models.ViewModels;

namespace VlammendVarkenBackend.Controllers;

public class GerechtenController(AppDbContext context) : Controller
{
  
  public async Task<IActionResult> Gast_Gerechten_Voorgerechten_Index()
  {
    var voorgerechten = await context.Gerechten
      .Include(g => g.GerechtSamenstellingen)
        .ThenInclude(gs => gs.Hoofdonderdeel)
          .ThenInclude(h => h.HoofdonderdeelAllergenen)
            .ThenInclude(ha => ha.Allergeen)
      .Include(g => g.GerechtSamenstellingen)
        .ThenInclude(gs => gs.Bijgerecht)
          .ThenInclude(b => b.BijgerechtAllergenen)
            .ThenInclude(ba => ba.Allergeen)
      .Include(g => g.GerechtSamenstellingen)
        .ThenInclude(gs => gs.Groente)
          .ThenInclude(gro => gro.GroenteAllergenen)
            .ThenInclude(ga => ga.Allergeen)
      .Include(g => g.GerechtSamenstellingen)
        .ThenInclude(gs => gs.Saus)
          .ThenInclude(s => s.SausAllergenen)
            .ThenInclude(sa => sa.Allergeen)
      .Where(g => g.Soort == "Voorgerecht")
      .ToListAsync();

    var voorgerechtenViewModel = new GerechtenViewModel();

    foreach (var voorgerecht in voorgerechten)
    {
      var voorgerechtSamenstelling = voorgerecht.GerechtSamenstellingen.FirstOrDefault();
      if (voorgerechtSamenstelling == null) continue;

      var voorgerechtAllergenenLijst = voorgerecht.GerechtSamenstellingen.SelectMany(GetAllergenenVanSamenstelling).Distinct().ToList();

      var voorgerechtViewModel = new GerechtViewModel
      {
        Soort = voorgerecht.Soort,
        Naam = voorgerecht.Naam,
        Hoofdonderdeel = voorgerechtSamenstelling.Hoofdonderdeel.Naam,
        Bijgerecht = voorgerechtSamenstelling.Bijgerecht.Naam,
        Groente = voorgerechtSamenstelling.Groente.Naam,
        Saus = voorgerechtSamenstelling.Saus.Naam,
        Prijs = voorgerechtSamenstelling.Hoofdonderdeel.Prijs + voorgerechtSamenstelling.Bijgerecht.Prijs + voorgerechtSamenstelling.Groente.Prijs + voorgerechtSamenstelling.Saus.Prijs,
        Allergenen = voorgerechtAllergenenLijst.Select(a => new AllergeenViewModel { Symbool = a }).ToList()
      };

      voorgerechtenViewModel.Gerechten.Add(voorgerechtViewModel);
    }
    
    return View("~/Views/Gast/Gerechten/Voorgerechten/Index.cshtml", voorgerechtenViewModel);
  }
  
  public IActionResult Gast_Gerechten_Hoofdgerechten_Index()
  {
    return View("~/Views/Gast/Gerechten/Hoofdgerechten/Index.cshtml");
  }
  
  public IActionResult Gast_Gerechten_Hoofdgerechten_Vlees_Index()
  {
    return View("~/Views/Gast/Gerechten/Hoofdgerechten/Vlees/Index.cshtml");
  }
  
  public IActionResult Gast_Gerechten_Hoofdgerechten_Vis_Index()
  {
    return View("~/Views/Gast/Gerechten/Hoofdgerechten/Vis/Index.cshtml");
  }
  
  public IActionResult Gast_Gerechten_Hoofdgerechten_Vegetarisch_Index()
  {
    return View("~/Views/Gast/Gerechten/Hoofdgerechten/Vegetarisch/Index.cshtml");
  }
  
  public IActionResult Gast_Gerechten_Hoofdgerechten_Edit()
  {
    return View("~/Views/Gast/Gerechten/Hoofdgerechten/Edit.cshtml");
  }
  
  public async Task<IActionResult> Gast_Gerechten_Nagerechten_Index()
  {
    var nagerechten = await context.Gerechten
      .Include(g => g.GerechtSamenstellingen)
        .ThenInclude(gs => gs.Hoofdonderdeel)
          .ThenInclude(h => h.HoofdonderdeelAllergenen)
            .ThenInclude(ha => ha.Allergeen)
      .Include(g => g.GerechtSamenstellingen)
        .ThenInclude(gs => gs.Bijgerecht)
          .ThenInclude(b => b.BijgerechtAllergenen)
            .ThenInclude(ba => ba.Allergeen)
      .Include(g => g.GerechtSamenstellingen)
        .ThenInclude(gs => gs.Groente)
          .ThenInclude(gro => gro.GroenteAllergenen)
            .ThenInclude(ga => ga.Allergeen)
      .Include(g => g.GerechtSamenstellingen)
        .ThenInclude(gs => gs.Saus)
          .ThenInclude(s => s.SausAllergenen)
            .ThenInclude(sa => sa.Allergeen)
      .Where(g => g.Soort == "Nagerecht")
      .ToListAsync();

    var nagerechtenViewModel = new GerechtenViewModel();

    foreach (var nagerecht in nagerechten)
    {
      var nagerechtSamenstelling = nagerecht.GerechtSamenstellingen.FirstOrDefault();
      if (nagerechtSamenstelling == null) continue;

      var nagerechtAllergenenLijst = nagerecht.GerechtSamenstellingen.SelectMany(GetAllergenenVanSamenstelling).Distinct().ToList();

      var nagerechtViewModel = new GerechtViewModel
      {
        Soort = nagerecht.Soort,
        Naam = nagerecht.Naam,
        Hoofdonderdeel = nagerechtSamenstelling.Hoofdonderdeel.Naam,
        Bijgerecht = nagerechtSamenstelling.Bijgerecht.Naam,
        Groente = nagerechtSamenstelling.Groente.Naam,
        Saus = nagerechtSamenstelling.Saus.Naam,
        Prijs = nagerechtSamenstelling.Hoofdonderdeel.Prijs + nagerechtSamenstelling.Bijgerecht.Prijs + nagerechtSamenstelling.Groente.Prijs + nagerechtSamenstelling.Saus.Prijs,
        Allergenen = nagerechtAllergenenLijst.Select(a => new AllergeenViewModel { Symbool = a }).ToList()
      };

      nagerechtenViewModel.Gerechten.Add(nagerechtViewModel);
    }
    
    return View("~/Views/Gast/Gerechten/nagerechten/Index.cshtml", nagerechtenViewModel);
  }
  
  private static IEnumerable<string> GetAllergenenVanSamenstelling(GerechtSamenstelling s)
  {
    var hoofdonderdeelAllergenen = s.Hoofdonderdeel.HoofdonderdeelAllergenen.Select(ha => ha.Allergeen.Symbool);
    var bijgerechtAllergenen = s.Bijgerecht.BijgerechtAllergenen.Select(ba => ba.Allergeen.Symbool);
    var groenteAllergenen = s.Groente.GroenteAllergenen.Select(ga => ga.Allergeen.Symbool);
    var sausAllergenen = s.Saus.SausAllergenen.Select(sa => sa.Allergeen.Symbool);

    return hoofdonderdeelAllergenen.Concat(bijgerechtAllergenen).Concat(groenteAllergenen).Concat(sausAllergenen);
  }
}
