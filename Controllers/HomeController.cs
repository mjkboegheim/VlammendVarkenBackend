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
    var gerecht = await context.Gerechten
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

    if (gerecht == null)
    {
      return View("~/Views/Gast/Index.cshtml");
    }

    var samenstelling = gerecht.GerechtSamenstellingen.FirstOrDefault();

    if (samenstelling == null)
    {
      return View("~/Views/Gast/Index.cshtml");
    }

    var allergenenLijst = gerecht.GerechtSamenstellingen.SelectMany(GetAllergenenVanSamenstelling).Distinct().ToList();

    var gerechtViewModel = new GerechtViewModel
    {
      Soort = gerecht.Soort,
      Naam = gerecht.Naam,
      Hoofdonderdeel = samenstelling.Hoofdonderdeel.Naam,
      Bijgerecht = samenstelling.Bijgerecht.Naam,
      Groente = samenstelling.Groente.Naam,
      Saus = samenstelling.Saus.Naam,
      Prijs = (samenstelling.Hoofdonderdeel.Prijs) + (samenstelling.Bijgerecht.Prijs) + (samenstelling.Groente.Prijs) + (samenstelling.Saus.Prijs),
      Allergenen = allergenenLijst.Select(a => new AllergeenViewModel { Symbool = a }).ToList()
    };

    return View("~/Views/Gast/Index.cshtml", gerechtViewModel);
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
