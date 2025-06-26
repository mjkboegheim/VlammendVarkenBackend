using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VlammendVarkenBackend.Data;
using VlammendVarkenBackend.Models.ViewModels;

namespace VlammendVarkenBackend.Controllers;

public class AllergenenController(AppDbContext context) : Controller
{
  public async Task<IActionResult> Gast_Allergenen_Index()
  {
    var allergenenViewModel = 
      await context.Allergenen
       .Select(a => new AllergeenViewModel { Symbool = a.Symbool, Beschrijving = a.Beschrijving })
        .ToListAsync();

    return View("~/Views/Gast/Allergenen/Index.cshtml", allergenenViewModel);
  }
}
