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
            var alleVleesgerechten = await _context.Gerechten
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

            var vleesgerechten = alleVleesgerechten
                .Where(g => g.Ingredienten.Any(ing =>
                    ing.Product?.ProductCategorie?.Naam != null &&
                    string.Equals(ing.Product.ProductCategorie.Naam, "Vlees", StringComparison.OrdinalIgnoreCase)))
                .ToList();

            var viewModels = vleesgerechten.Select(MapGerechtToViewModel).ToList();

            Console.WriteLine($"Aantal hoofdgerechten: {alleVleesgerechten.Count}");
            Console.WriteLine($"Aantal vleesgerechten: {vleesgerechten.Count}");

            return View("~/Views/Gerechten/Hoofdgerechten/Vlees/Index.cshtml", viewModels);
        }
        
        public async Task<IActionResult> Visgerecht_Index()
        {
            var alleHoofdgerechten = await _context.Gerechten
                .Include(g => g.GerechtCategorie)
                .Include(g => g.Bijgerecht)
                .Include(g => g.Groente)
                .Include(g => g.Saus)
                .Include(g => g.GerechtAllergieen).ThenInclude(ga => ga.Allergie)
                .Include(g => g.Ingredienten).ThenInclude(ing => ing.Product).ThenInclude(p => p.ProductCategorie)
                .Where(g => g.GerechtCategorie != null && g.GerechtCategorie.Naam == "Hoofdgerechten")
                .ToListAsync();

            var visgerechten = alleHoofdgerechten
                .Where(g => g.Ingredienten.Any(ing =>
                    string.Equals(ing.Product?.ProductCategorie?.Naam, "Vis", StringComparison.OrdinalIgnoreCase)))
                .ToList();

            var viewModels = visgerechten.Select(MapGerechtToViewModel).ToList();

            Console.WriteLine($"Aantal hoofdgerechten: {alleHoofdgerechten.Count}");
            Console.WriteLine($"Aantal visgerechten: {visgerechten.Count}");

            return View("~/Views/Gerechten/Hoofdgerechten/Vis/Index.cshtml", viewModels);
        }

        public async Task<IActionResult> Vegetarisch_Index()
        {
            var alleHoofdgerechten = await _context.Gerechten
                .Include(g => g.GerechtCategorie)
                .Include(g => g.Bijgerecht)
                .Include(g => g.Groente)
                .Include(g => g.Saus)
                .Include(g => g.GerechtAllergieen).ThenInclude(ga => ga.Allergie)
                .Include(g => g.Ingredienten).ThenInclude(ing => ing.Product).ThenInclude(p => p.ProductCategorie)
                .Where(g => g.GerechtCategorie != null && g.GerechtCategorie.Naam == "Hoofdgerechten")
                .ToListAsync();

            var vegetarischeGerechten = alleHoofdgerechten
                .Where(g =>
                    g.Ingredienten.All(ing =>
                        ing.Product?.ProductCategorie?.Naam != null &&
                        !string.Equals(ing.Product.ProductCategorie.Naam, "Vlees", StringComparison.OrdinalIgnoreCase) &&
                        !string.Equals(ing.Product.ProductCategorie.Naam, "Vis", StringComparison.OrdinalIgnoreCase)))
                .ToList();

            var viewModels = vegetarischeGerechten.Select(MapGerechtToViewModel).ToList();

            Console.WriteLine($"Aantal hoofdgerechten: {alleHoofdgerechten.Count}");
            Console.WriteLine($"Aantal vegetarische hoofdgerechten: {vegetarischeGerechten.Count}");

            return View("~/Views/Gerechten/Hoofdgerechten/Vegetarisch/Index.cshtml", viewModels);
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
