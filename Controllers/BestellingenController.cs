using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VlammendVarkenBackend.Data;
using VlammendVarkenBackend.Models.ViewModels;

namespace VlammendVarkenBackend.Controllers
{
    public class BestellingenController : Controller
    {
        private readonly AppDbContext _context;

        public BestellingenController(AppDbContext context)
        {
            _context = context;
        }

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
            var bestellingen = _context.Bestellingen
                .Include(b => b.BestellingTafels).ThenInclude(bt => bt.Tafel)
                .Include(b => b.Levertijd)
                .OrderBy(b => b.Besteldatum)
                .Select(b => new BestellingOverzichtViewModel
                {
                    BestellingId = b.BestellingId,
                    Tafelnummers = b.BestellingTafels.Select(bt => bt.Tafel.Nummer).ToList(),
                    Besteldatum = b.Besteldatum,
                    BereidingstijdMinuten = b.Levertijd.Minuten,
                    AantalGasten = b.BestellingTafels.Count * 2,
                    HeeftAttentie = (b.Besteldatum.Minute % 2 == 0)
                })
                .ToList();

            return View("~/Views/Personeel/Bestellingen/Overzicht/Index.cshtml", bestellingen);
        }

        public IActionResult Personeel_Bestellingen_Details_Index()
        {
            return View("~/Views/Personeel/Bestellingen/Details/Index.cshtml");
        }
    }
}