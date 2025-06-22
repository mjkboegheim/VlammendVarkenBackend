
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VlammendVarkenBackend.Data;
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
                return View("~/Views/Gerechten/Index.cshtml", null);

            var viewModel = MapGerechtToViewModel(dagmenu);
            return View("~/Views/Gerechten/Index.cshtml", viewModel);
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

            var viewModel = voorgerechten.Select(MapGerechtToViewModel).ToList();
            return View("~/Views/Gerechten/Voorgerechten/Index.cshtml", viewModel);
        }

        public async Task<IActionResult> Hoofdgerecht_Index()
        {
            var hoofdgerechten = await _context.Gerechten
                .Include(g => g.GerechtCategorie)
                .Include(g => g.Bijgerecht)
                .Include(g => g.Groente)
                .Include(g => g.Saus)
                .Include(g => g.GerechtAllergieen)
                    .ThenInclude(ga => ga.Allergie)
                .Where(g => g.GerechtCategorie != null && g.GerechtCategorie.Naam == "Hoofdgerechten")
                .ToListAsync();

            var viewModel = hoofdgerechten.Select(MapGerechtToViewModel).ToList();
            return View("~/Views/Gerechten/Hoofdgerechten/Index.cshtml", viewModel);
        }

        [HttpGet]
        public IActionResult Hoofdgerecht_Soorten_Index()
        {
            return View("~/Views/Gerechten/Hoofdgerechten/Soorten/Index.cshtml");
        }

        public async Task<IActionResult> Vleesgerecht_Index()
        {
            var alleHoofdgerechten = await _context.Gerechten
                .Include(g => g.GerechtCategorie)
                .Include(g => g.Bijgerecht)
                .Include(g => g.Groente)
                .Include(g => g.Saus)
                .Include(g => g.GerechtAllergieen)
                    .ThenInclude(ga => ga.Allergie)
                .Include(g => g.Ingredienten)
                    .ThenInclude(ing => ing.Product)
                        .ThenInclude(p => p.ProductCategorie)
                .Where(g => g.GerechtCategorie != null && g.GerechtCategorie.Naam == "Hoofdgerechten")
                .ToListAsync();

            var vleesgerechten = alleHoofdgerechten
                .Where(g => g.Ingredienten.Any(ing =>
                    ing.Product?.ProductCategorie?.Naam != null &&
                    string.Equals(ing.Product.ProductCategorie.Naam, "Vlees", StringComparison.OrdinalIgnoreCase)))
                .ToList();

            var viewModels = vleesgerechten.Select(MapGerechtToViewModel).ToList();

            Console.WriteLine($"Aantal hoofdgerechten: {alleHoofdgerechten.Count}");
            Console.WriteLine($"Aantal vleesgerechten: {vleesgerechten.Count}");

            return View("~/Views/Gerechten/Hoofdgerechten/Vlees/Index.cshtml", viewModels);
        }

        public async Task<IActionResult> Visgerecht_Index()
        {
            var visgerechten = await _context.Gerechten
                .Include(g => g.GerechtCategorie)
                .Include(g => g.Ingredienten)
                    .ThenInclude(i => i.Product)
                        .ThenInclude(p => p.ProductCategorie)
                .Where(g => g.GerechtCategorie != null && g.GerechtCategorie.Naam == "Hoofdgerechten")
                .ToListAsync();

            var selectie = visgerechten
                .Where(g => g.Ingredienten.Any(i =>
                    i.Product?.ProductCategorie?.Naam == "Vis"))
                .Select(MapGerechtToViewModel)
                .ToList();

            return View("~/Views/Gerechten/Hoofdgerechten/Vis/Index.cshtml", selectie);
        }

        public async Task<IActionResult> Vegetarisch_Index()
        {
            var gerechten = await _context.Gerechten
                .Include(g => g.GerechtCategorie)
                .Include(g => g.Ingredienten)
                    .ThenInclude(i => i.Product)
                        .ThenInclude(p => p.ProductCategorie)
                .Where(g => g.GerechtCategorie != null && g.GerechtCategorie.Naam == "Hoofdgerechten")
                .ToListAsync();

            var selectie = gerechten
                .Where(g => g.Ingredienten.All(i =>
                    i.Product?.ProductCategorie?.Naam != "Vlees" &&
                    i.Product?.ProductCategorie?.Naam != "Vis"))
                .Select(MapGerechtToViewModel)
                .ToList();

            return View("~/Views/Gerechten/Hoofdgerechten/Vegetarisch/Index.cshtml", selectie);
        }

        // === Helpers ===

        private GerechtViewModel MapGerechtToViewModel(Models.Gerecht g)
        {
            return new GerechtViewModel
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
            };
        }

        private string MapAllergieNaamNaarEmoji(string naam)
        {
            return naam switch
            {
                "Gluten" => "🌾",
                "Lactose" => "🥛",
                "Schaaldieren" => "🦐",
                _ => "❓"
            };
        }
    }
}
