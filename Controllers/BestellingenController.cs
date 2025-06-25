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
            .Include(b => b.BestellingGerechten)
                .ThenInclude(bg => bg.Gerecht)
                    .ThenInclude(g => g.GerechtSamenstellingen)
                        .ThenInclude(gs => gs.Hoofdonderdeel)
                            .ThenInclude(h => h.HoofdonderdeelAllergenen)
                                .ThenInclude(hoa => hoa.Allergeen)
            .Include(b => b.BestellingGerechten)
                .ThenInclude(bg => bg.Gerecht)
                    .ThenInclude(g => g.GerechtSamenstellingen)
                        .ThenInclude(gs => gs.Bijgerecht)
                            .ThenInclude(bg => bg.BijgerechtAllergenen)
                                .ThenInclude(bga => bga.Allergeen)
            .Include(b => b.BestellingGerechten)
                .ThenInclude(bg => bg.Gerecht)
                    .ThenInclude(g => g.GerechtSamenstellingen)
                        .ThenInclude(gs => gs.Groente)
                            .ThenInclude(gr => gr.GroenteAllergenen)
                                .ThenInclude(ga => ga.Allergeen)
            .Include(b => b.BestellingGerechten)
                .ThenInclude(bg => bg.Gerecht)
                    .ThenInclude(g => g.GerechtSamenstellingen)
                        .ThenInclude(gs => gs.Saus)
                            .ThenInclude(s => s.SausAllergenen)
                                .ThenInclude(sa => sa.Allergeen)
            .OrderBy(b => b.Besteldatum)
            .ToList()  // eerst ophalen, daarna in memory verwerken voor complexiteit
            .Select(b => new BestellingOverzichtViewModel
            {
                BestellingId = b.BestellingId,
                Tafelnummers = b.BestellingTafels.Select(bt => bt.Tafel.Nummer).ToList(),
                Besteldatum = b.Besteldatum,
                BereidingstijdMinuten = b.Levertijd.Minuten,
                AantalGasten = b.BestellingTafels.Count * 2,
                HeeftAttentie = (b.Besteldatum.Minute % 2 == 0),

                Allergenen = b.BestellingGerechten
                    .SelectMany(bg => bg.Gerecht.GerechtSamenstellingen)
                    .SelectMany(gs => 
                        gs.Hoofdonderdeel.HoofdonderdeelAllergenen.Select(hoa => hoa.Allergeen.Symbool)
                        .Concat(gs.Bijgerecht.BijgerechtAllergenen.Select(bga => bga.Allergeen.Symbool))
                        .Concat(gs.Groente.GroenteAllergenen.Select(ga => ga.Allergeen.Symbool))
                        .Concat(gs.Saus.SausAllergenen.Select(sa => sa.Allergeen.Symbool))
                    )
                    .Distinct()
                    .OrderBy(symbool => symbool)
                    .ToList()
            })
            .ToList();

        return View("~/Views/Personeel/Bestellingen/Overzicht/Index.cshtml", bestellingen);
        }


        public IActionResult Personeel_Bestellingen_Details_Index(int bestellingId)
        {
            var bestelling = _context.Bestellingen
                .Include(b => b.Levertijd) // Zorg dat levertijd mee geladen wordt!
                .Include(b => b.BestellingTafels).ThenInclude(bt => bt.Tafel)
                .Include(b => b.BestellingGerechten).ThenInclude(bg => bg.Gerecht)
                    .ThenInclude(g => g.GerechtSamenstellingen)
                        .ThenInclude(gs => gs.Hoofdonderdeel)
                .Include(b => b.BestellingGerechten).ThenInclude(bg => bg.Gerecht)
                    .ThenInclude(g => g.GerechtSamenstellingen)
                        .ThenInclude(gs => gs.Bijgerecht)
                .Include(b => b.BestellingGerechten).ThenInclude(bg => bg.Gerecht)
                    .ThenInclude(g => g.GerechtSamenstellingen)
                        .ThenInclude(gs => gs.Groente)
                .Include(b => b.BestellingGerechten).ThenInclude(bg => bg.Gerecht)
                    .ThenInclude(g => g.GerechtSamenstellingen)
                        .ThenInclude(gs => gs.Saus)
                .FirstOrDefault(b => b.BestellingId == bestellingId);

            if (bestelling == null)
            {
                return NotFound();
            }

            int bereidingstijd = bestelling.Levertijd?.Minuten ?? 0;

            var tafelnummers = bestelling.BestellingTafels
                .Select(bt => bt.Tafel.Nummer)
                .ToList();

            var gerechtenVm = bestelling.BestellingGerechten
                .SelectMany(bg => bg.Gerecht.GerechtSamenstellingen.Select(gs => new BestellingGerechtViewModel
                {
                    Soort = bg.Gerecht.Soort,
                    GerechtNaam = bg.Gerecht.Naam,
                    BijgerechtNaam = gs.Bijgerecht?.Naam ?? "-",
                    GroenteNaam = gs.Groente?.Naam ?? "-",
                    SausNaam = gs.Saus?.Naam ?? "-"
                }))
                .ToList();

            var viewModel = new PersoneelBestellingDetailsViewModel
            {
                BestellingId = bestelling.BestellingId,
                Tafelnummers = tafelnummers,
                Besteldatum = bestelling.Besteldatum,
                BereidingstijdMinuten = bereidingstijd,
                Gerechten = gerechtenVm
            };

            return View("~/Views/Personeel/Bestellingen/Details/Index.cshtml", viewModel);
        }
    }
}
