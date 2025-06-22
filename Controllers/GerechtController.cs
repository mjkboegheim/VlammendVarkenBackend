using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VlammendVarkenBackend.Models;
using VlammendVarkenBackend.Data;
using Microsoft.EntityFrameworkCore;
using VlammendVarkenBackend.Helpers;

using VlammendVarkenBackend.ViewModels;

namespace VlammendVarkenBackend.Controllers
{
    public class GerechtController : Controller
    {
        private readonly AppDbContext _context;

        public GerechtController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var gerecht = _context.Gerechten
                .Include(g => g.GerechtCategorie)
                .Include(g => g.Bijgerecht)
                .Include(g => g.Groente)
                .Include(g => g.Saus)
                .Include(g => g.GerechtAllergieen)
                .ThenInclude(ga => ga.Allergie)
                .Include(g => g.Ingredienten)
                .ThenInclude(i => i.Product)
                .Where(g => g.GerechtCategorieId == 5) // Dagemenu
                .FirstOrDefault();

            if (gerecht == null)
            {
                return NotFound(new { message = "Geen dagmenu gevonden." });
            }

            var viewModel = ViewModelMapper.MapToViewModel(gerecht);
            viewModel.Beschrijving = "Ons zorgvuldig samengesteld dagmenu.";

            return Json(viewModel);
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
