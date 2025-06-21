using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VlammendVarkenBackend.Controllers
{
    public class BestellingController : Controller
    {
        // GET: /<controller>/
        public IActionResult Overzicht_Gast_Index()
        {
            return View("~/Views/Bestelling/Overzicht/Gast/Index.cshtml"); 
        }
        
        public IActionResult Overzicht_Chefkok_Index()
        {
            return View("~/Views/Bestelling/Overzicht/Chefkok/Index.cshtml"); 
        }
        
        public IActionResult Details_Index()
        {
            return View("~/Views/Bestelling/Overzicht/Chefkok/Details/Index.cshtml"); 
        }
        
        public IActionResult Tafels_Index()
        {
            return View("~/Views/Bestelling/Tafels/Index.cshtml"); 
        }
    }
}

