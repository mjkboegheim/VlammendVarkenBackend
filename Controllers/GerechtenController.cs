using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VlammendVarkenBackend.Data;
using VlammendVarkenBackend.Models;
using VlammendVarkenBackend.Models.ViewModels;

namespace VlammendVarkenBackend.Controllers;

public class GerechtenController(AppDbContext context) : Controller
{
  private IQueryable<Gerecht> QueryGerechtenBySoort(int? gerechtId, string gerechtSoort)
  {
    var query = context.Gerechten
      .Include(g => g.Samenstellingen)
        .ThenInclude(gs => gs.Hoofdonderdeel)
          .ThenInclude(h => h.Allergenen)
            .ThenInclude(ha => ha.Allergeen)
      .Include(g => g.Samenstellingen)
        .ThenInclude(gs => gs.Bijgerecht)
          .ThenInclude(b => b.Allergenen)
            .ThenInclude(ba => ba.Allergeen)
      .Include(g => g.Samenstellingen)
        .ThenInclude(gs => gs.Groente)
          .ThenInclude(gro => gro.Allergenen)
            .ThenInclude(ga => ga.Allergeen)
      .Include(g => g.Samenstellingen)
        .ThenInclude(gs => gs.Saus)
          .ThenInclude(s => s.Allergenen)
            .ThenInclude(sa => sa.Allergeen)
      .Where(g => g.Soort == gerechtSoort);
    
    if (gerechtId != null) {
      query = query.Where(g => gerechtId == g.Id);
    }
    
    if (gerechtSoort == "dagmenu") {
      query = query.Take(1);
    }

    return query;
  }
  
  private static GerechtViewModel? MaakGerechtViewModel(Gerecht gerecht)
  {
    var gerechtSamenstelling = gerecht.Samenstellingen.FirstOrDefault();
    
    if (gerechtSamenstelling == null) return null;
    
    return new GerechtViewModel
    {
      Id = gerecht.Id,
      Soort = gerecht.Soort,
      Naam = gerecht.Naam,
      Prijs = 
        gerechtSamenstelling.Hoofdonderdeel.Prijs +
        gerechtSamenstelling.Bijgerecht.Prijs + 
        gerechtSamenstelling.Groente.Prijs + 
        gerechtSamenstelling.Saus.Prijs,
      
      Hoofdonderdelen = new()
      {
        new HoofdonderdeelViewModel
        {
          Naam = gerechtSamenstelling.Hoofdonderdeel.Naam,
          Prijs = gerechtSamenstelling.Hoofdonderdeel.Prijs,
          Allergenen = gerechtSamenstelling.Hoofdonderdeel.Allergenen.Select(ha => 
            new AllergeenViewModel
            {
              Symbool = ha.Allergeen.Symbool
            }
          ).ToList()
        }
      },
      Bijgerechten = new()
      {
        new BijgerechtViewModel
        {
          Naam = gerechtSamenstelling.Bijgerecht.Naam,
          Prijs = gerechtSamenstelling.Bijgerecht.Prijs,
          Allergenen = gerechtSamenstelling.Bijgerecht.Allergenen.Select(ha => 
            new AllergeenViewModel
            {
              Symbool = ha.Allergeen.Symbool
            }
          ).ToList()
        }
      },
      Groenten = new()
      {
        new GroenteViewModel
        {
          Naam = gerechtSamenstelling.Groente.Naam,
          Prijs = gerechtSamenstelling.Groente.Prijs,
          Allergenen = gerechtSamenstelling.Groente.Allergenen.Select(ha => 
            new AllergeenViewModel
            {
              Symbool = ha.Allergeen.Symbool
            }
          ).ToList()
        }
      },
      Sausen = new()
      {
        new SausViewModel
        {
          Naam = gerechtSamenstelling.Saus.Naam,
          Prijs = gerechtSamenstelling.Saus.Prijs,
          Allergenen = gerechtSamenstelling.Saus.Allergenen.Select(ha => 
            new AllergeenViewModel
            {
              Symbool = ha.Allergeen.Symbool
            }
          ).ToList()
        }
      },
    };
  }
  
  public async Task<IActionResult> Gast_Gerechten_Index(int? gerechtId, string gerechtSoort)
  {
    var gerechten = await QueryGerechtenBySoort(gerechtId, gerechtSoort).ToListAsync();

    if (gerechtId != null)
    {
      var gerechtViewModel = MaakGerechtViewModel(gerechten[0]);
      return View("~/Views/Gast/Gerechten/Hoofdgerechten/Edit.cshtml", gerechtViewModel);
    }
    
    switch (gerechtSoort)
    {
      case "dagmenu":
        var gerechtViewModel = MaakGerechtViewModel(gerechten[0]);
        return View("~/Views/Gast/Index.cshtml", gerechtViewModel);

      case "hoofdgerecht":
        return View("~/Views/Gast/Gerechten/Hoofdgerechten/Index.cshtml");

      default:
        var gerechtLijstViewModel = new GerechtLijstViewModel();
        gerechtLijstViewModel.Gerechten.AddRange(gerechten.Select(MaakGerechtViewModel).Where(gerechtVm => gerechtVm != null)!);
        return View("~/Views/Gast/Gerechten/Index.cshtml", gerechtLijstViewModel);
    }
  }
}
