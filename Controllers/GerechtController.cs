using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VlammendVarkenBackend.Controllers
{
    public class GerechtController : Controller
    {
        // GET: /<controller>/
        
        public IActionResult Index()
        {
            return View("~/Views/Gerechten/Index.cshtml"); 
        }
        
        public IActionResult Voorgerecht_Index()
        {
            return View("~/Views/Gerechten/Voorgerechten/Index.cshtml");
        }
        
        public IActionResult Hoofdgerecht_Index()
        {
            return View("~/Views/Gerechten/Hoofdgerechten/Index.cshtml");
        }
        
        public IActionResult Vleesgerecht_Index()
        {
            return View("~/Views/Gerechten/Hoofdgerechten/Vlees/Index.cshtml");
        }
        
        public IActionResult Visgerecht_Index()
        {
            return View("~/Views/Gerechten/Hoofdgerechten/Vis/Index.cshtml");
        }
        
        public IActionResult Vegetarisch_Index()
        {
            return View("~/Views/Gerechten/Hoofdgerechten/Vegetarisch/Index.cshtml");
        }
        
        public IActionResult Hoofdgerecht_Edit()
        {
            return View("~/Views/Gerechten/Hoofdgerechten/Edit.cshtml");
        }
        
        public IActionResult Nagerecht_Index()
        {
            return View("~/Views/Gerechten/Nagerechten/Index.cshtml");
        }
    }
}

