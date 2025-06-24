using Microsoft.AspNetCore.Mvc;

namespace VlammendVarkenBackend.Controllers
{
  public class BestellingenController : Controller
  {
    public IActionResult Gast_Bestellingen_Overzicht_Index()
    {
      return View("~/Views/Gast/Bestellingen/Overzicht/Index.cshtml"); 
    }
    public IActionResult Gast_Bestellingen_Tafels_Index()
    {
      return View("~/Views/Gast/Bestellingen/Tafels/Index.cshtml"); 
    }
    public IActionResult Personeel_Bestellingen_Overzicht_Index()
    {
      return View("~/Views/Personeel/Bestellingen/Overzicht/Index.cshtml"); 
    }
    public IActionResult Personeel_Bestellingen_Details_Index()
    {
      return View("~/Views/Personeel/Bestellingen/Details/Index.cshtml"); 
    }
  }
}
