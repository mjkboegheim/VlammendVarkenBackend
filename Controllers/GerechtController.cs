using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VlammendVarkenBackend.Models;
using VlammendVarkenBackend.Data;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Index()
        {
            // Zoek gerecht met categorie "Dagemenu"
            var dagmenu = await _context.Gerechten
                .Include(g => g.GerechtCategorie)
                .Include(g => g.Bijgerecht)
                .Include(g => g.Groente)
                .Include(g => g.Saus)
                .Include(g => g.GerechtAllergieen)
                .ThenInclude(ga => ga.Allergie)
                .Where(g => g.GerechtCategorie.Naam == "Dagemenu")
                .FirstOrDefaultAsync();

            if (dagmenu == null)
            {
                return View("~/Views/Gerechten/Index.cshtml", null);
            }

            var viewModel = new GerechtViewModel
            {
                Id = dagmenu.GerechtId,
                Naam = dagmenu.Naam,
                Beschrijving = dagmenu.Beschrijving,
                Prijs = dagmenu.Prijs,
                Categorie = dagmenu.GerechtCategorie.Naam,
                Bijgerecht = dagmenu.Bijgerecht?.Naam,
                Groente = dagmenu.Groente?.Naam,
                Saus = dagmenu.Saus?.Naam,
                Allergieen = dagmenu.GerechtAllergieen
                    .Select(ga => MapAllergieNaamNaarEmoji(ga.Allergie.Naam))
                    .ToList()
            };

            return View("~/Views/Gerechten/Index.cshtml", viewModel);
        }
        
        private string MapAllergieNaamNaarEmoji(string naam)
        {
            return naam.ToLower() switch
            {
                "gluten" => "🌾",
                "lactose" => "🥛",
                "schaaldieren" => "🦐",
                _ => "⚠️"
            };
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
