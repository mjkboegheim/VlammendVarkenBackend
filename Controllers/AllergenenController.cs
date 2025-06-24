using Microsoft.AspNetCore.Mvc;

namespace VlammendVarkenBackend.Controllers
{
  public class AllergenenController : Controller
  {
    public IActionResult Gast_Allergenen_Index()
    {
      return View("~/Views/Gast/Allergenen/Index.cshtml"); 
    }
  }
}
