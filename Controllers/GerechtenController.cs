using Microsoft.AspNetCore.Mvc;

namespace VlammendVarkenBackend.Controllers
{
  public class GerechtenController : Controller
  {
    public IActionResult Gast_Gerechten_Voorgerechten_Index()
    {
      return View("~/Views/Gast/Gerechten/Voorgerechten/Index.cshtml");
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
    public IActionResult Gast_Gerechten_Hoofdgerechten_Vegetarisch_index()
    {
      return View("~/Views/Gast/Gerechten/Hoofdgerechten/Vegetarisch/Index.cshtml");
    }
    public IActionResult Gast_Gerechten_Hoofdgerechten_Edit()
    {
      return View("~/Views/Gast/Gerechten/Hoofdgerechten/Edit.cshtml");
    }
    public IActionResult Gast_Gerechten_Nagerechten_Index()
    {
      return View("~/Views/Gast/Gerechten/Nagerechten/Index.cshtml");
    }
  }
}
