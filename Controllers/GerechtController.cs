using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VlammendVarkenBackend.Data;
using VlammendVarkenBackend.Models;
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

        public async Task<IActionResult> Index()
        {
            // Zoek gerecht met categorie "Dagmenu", met null-check
            var dagmenu = await _context.Gerechten
                .Include(g => g.GerechtCategorie)
                .Include(g => g.Bijgerecht)
                .Include(g => g.Groente)
                .Include(g => g.Saus)
                .Include(g => g.GerechtAllergieen)
                    .ThenInclude(ga => ga.Allergie)
                .Where(g => g.GerechtCategorie != null && g.GerechtCategorie.Naam == "Dagmenu")
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
                Categorie = (dagmenu.GerechtCategorie?.Naam ?? "Onbekend")!,
                Bijgerecht = dagmenu.Bijgerecht?.Naam,
                Groente = dagmenu.Groente?.Naam,
                Saus = dagmenu.Saus?.Naam,
                Allergieen = dagmenu.GerechtAllergieen
                    .Where(ga => ga.Allergie != null)
                    .Select(ga => MapAllergieNaamNaarEmoji(ga.Allergie!.Naam))
                    .ToList()
            };

            return View("~/Views/Gerechten/Index.cshtml", viewModel);
        }

        private string MapAllergieNaamNaarEmoji(string naam)
        {
            return naam switch
            {
                "Gluten" => "🌾",
                "Noten" => "🥜",
                "Melk" => "🥛",
                "Ei" => "🍳",
                "Vis" => "🐟",
                "Schaaldieren" => "🦐",
                "Soja" => "🌱",
                "Mosterd" => "🌶️",
                "Sesam" => "⚪",
                _ => "❓"
            };
        }
        
        public async Task<IActionResult> Voorgerecht_Index()
        {
            var voorgerechten = await _context.Gerechten
                .Include(g => g.GerechtCategorie)
                .Include(g => g.Bijgerecht)
                .Include(g => g.Groente)
                .Include(g => g.Saus)
                .Include(g => g.GerechtAllergieen)
                .ThenInclude(ga => ga.Allergie)
                .Where(g => g.GerechtCategorie != null && g.GerechtCategorie.Naam == "Voorgerechten")
                .ToListAsync();

            var viewModel = voorgerechten.Select(g => new GerechtViewModel
            {
                Id = g.GerechtId,
                Naam = g.Naam,
                Beschrijving = g.Beschrijving,
                Prijs = g.Prijs,
                Categorie = g.GerechtCategorie?.Naam ?? "Onbekend",
                Bijgerecht = g.Bijgerecht?.Naam,
                Groente = g.Groente?.Naam,
                Saus = g.Saus?.Naam,
                Allergieen = g.GerechtAllergieen
                    .Where(ga => ga.Allergie != null)
                    .Select(ga => MapAllergieNaamNaarEmoji(ga.Allergie!.Naam))
                    .ToList()
            }).ToList();

            return View("~/Views/Gerechten/Voorgerechten/Index.cshtml", viewModel);
        }


    }
}
