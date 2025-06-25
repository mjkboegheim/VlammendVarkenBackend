using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VlammendVarkenBackend.Data;
using VlammendVarkenBackend.Models;
using VlammendVarkenBackend.Models.ViewModels;

namespace VlammendVarkenBackend.Controllers;

public class HomeController(AppDbContext context) : Controller
{
  public async Task<IActionResult> Gast_Index()
  {
    var dagmenu = await context.Gerechten
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
      .FirstOrDefaultAsync(g => g.Soort == "Dagmenu");

    if (dagmenu == null)
    {
      return View("~/Views/Gast/Index.cshtml");
    }

    var dagmenuSamenstelling = dagmenu.GerechtSamenstellingen.FirstOrDefault();

    if (dagmenuSamenstelling == null)
    {
      return View("~/Views/Gast/Index.cshtml");
    }

    var dagmenuAllergenenLijst = dagmenu.GerechtSamenstellingen.SelectMany(GetAllergenenVanSamenstelling).Distinct().ToList();

    var dagmenuViewModel = new GerechtViewModel
    {
      Soort = dagmenu.Soort,
      Naam = dagmenu.Naam,
      Hoofdonderdeel = dagmenuSamenstelling.Hoofdonderdeel.Naam,
      Bijgerecht = dagmenuSamenstelling.Bijgerecht.Naam,
      Groente = dagmenuSamenstelling.Groente.Naam,
      Saus = dagmenuSamenstelling.Saus.Naam,
      Prijs = (dagmenuSamenstelling.Hoofdonderdeel.Prijs) + (dagmenuSamenstelling.Bijgerecht.Prijs) + (dagmenuSamenstelling.Groente.Prijs) + (dagmenuSamenstelling.Saus.Prijs),
      Allergenen = dagmenuAllergenenLijst.Select(a => new AllergeenViewModel { Symbool = a }).ToList()
    };

    return View("~/Views/Gast/Index.cshtml", dagmenuViewModel);
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
