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
                .Include(b => b.BestellingTafels)  // Haal BestellingTafels op
                    .ThenInclude(bt => bt.Tafel)  // Haal de Tafel op via BestellingTafel
                .Include(b => b.Levertijd)
                .Include(b => b.Gerechten)
                    .ThenInclude(bg => bg.Gerecht)
                        .ThenInclude(g => g.Samenstellingen)
                            .ThenInclude(gs => gs.Hoofdonderdeel)
                                .ThenInclude(h => h.Allergenen)
                                    .ThenInclude(hoa => hoa.Allergeen)
                .Include(b => b.Gerechten)
                    .ThenInclude(bg => bg.Gerecht)
                        .ThenInclude(g => g.Samenstellingen)
                            .ThenInclude(gs => gs.Bijgerecht)
                                .ThenInclude(bg => bg.Allergenen)
                                    .ThenInclude(bga => bga.Allergeen)
                .Include(b => b.Gerechten)
                    .ThenInclude(bg => bg.Gerecht)
                        .ThenInclude(g => g.Samenstellingen)
                            .ThenInclude(gs => gs.Groente)
                                .ThenInclude(gr => gr.Allergenen)
                                    .ThenInclude(ga => ga.Allergeen)
                .Include(b => b.Gerechten)
                    .ThenInclude(bg => bg.Gerecht)
                        .ThenInclude(g => g.Samenstellingen)
                            .ThenInclude(gs => gs.Saus)
                                .ThenInclude(s => s.Allergenen)
                                    .ThenInclude(sa => sa.Allergeen)
                .OrderBy(b => b.Besteldatum)
                .ToList()
                .Select(b => new BestellingOverzichtViewModel
                {
                    BestellingId = b.Id,
                    Tafelnummers = b.BestellingTafels.Select(bt => bt.Tafel.Nummer).ToList(),  // Gebruik BestellingTafels hier
                    Besteldatum = b.Besteldatum,
                    BereidingstijdMinuten = b.Levertijd.Minuten,
                    AantalGasten = b.BestellingTafels.Count * 2,  // Aantal tafels x 2 gasten
                    HeeftAttentie = (b.Besteldatum.Minute % 2 == 0),

                    Allergenen = b.Gerechten
                        .SelectMany(bg => bg.Gerecht.Samenstellingen)
                        .SelectMany(gs => 
                            gs.Hoofdonderdeel.Allergenen.Select(hoa => hoa.Allergeen.Symbool)
                            .Concat(gs.Bijgerecht.Allergenen.Select(bga => bga.Allergeen.Symbool))
                            .Concat(gs.Groente.Allergenen.Select(ga => ga.Allergeen.Symbool))
                            .Concat(gs.Saus.Allergenen.Select(sa => sa.Allergeen.Symbool))
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
                .Include(b => b.Levertijd)  // Haal Levertijd op
                .Include(b => b.BestellingTafels)  // Haal BestellingTafels op
                    .ThenInclude(bt => bt.Tafel)  // Haal de Tafel op via BestellingTafel
                .Include(b => b.Gerechten)  // Haal Gerechten op
                    .ThenInclude(bg => bg.Gerecht)
                        .ThenInclude(g => g.Samenstellingen)  // Haal de samenstellingen van Gerechten op
                            .ThenInclude(gs => gs.Hoofdonderdeel)  // Haal Hoofdonderdeel op
                                .ThenInclude(h => h.Allergenen)  // Haal Allergenen op voor Hoofdonderdeel
                                    .ThenInclude(hoa => hoa.Allergeen)
                .Include(b => b.Gerechten)  // Herhaal voor de andere elementen zoals Bijgerecht, Groente, Saus
                    .ThenInclude(bg => bg.Gerecht)
                        .ThenInclude(g => g.Samenstellingen)
                            .ThenInclude(gs => gs.Bijgerecht)
                                .ThenInclude(bg => bg.Allergenen)
                                    .ThenInclude(bga => bga.Allergeen)
                .Include(b => b.Gerechten)
                    .ThenInclude(bg => bg.Gerecht)
                        .ThenInclude(g => g.Samenstellingen)
                            .ThenInclude(gs => gs.Groente)
                                .ThenInclude(gr => gr.Allergenen)
                                    .ThenInclude(ga => ga.Allergeen)
                .Include(b => b.Gerechten)
                    .ThenInclude(bg => bg.Gerecht)
                        .ThenInclude(g => g.Samenstellingen)
                            .ThenInclude(gs => gs.Saus)
                                .ThenInclude(s => s.Allergenen)
                                    .ThenInclude(sa => sa.Allergeen)
                .FirstOrDefault(b => b.Id == bestellingId);  // Correcte match op Id in plaats van BestellingId

            if (bestelling == null)
            {
                return NotFound();  // Bestelling niet gevonden
            }

            // Bereidingstijd ophalen (minuten)
            int bereidingstijd = bestelling.Levertijd?.Minuten ?? 0;

            // Tafelnummers ophalen via de BestellingTafels relatie
            var tafelnummers = bestelling.BestellingTafels
                .Select(bt => bt.Tafel.Nummer)
                .ToList();

            // Gerechten ophalen en hun samenstellingen verwerken
            var gerechtenVm = bestelling.Gerechten
                .SelectMany(bg => bg.Gerecht.Samenstellingen.Select(gs => new BestellingGerechtViewModel
                {
                    Soort = bg.Gerecht.Soort,
                    GerechtNaam = bg.Gerecht.Naam,
                    BijgerechtNaam = gs.Bijgerecht?.Naam ?? "-",  // Bijgerecht is nullable
                    GroenteNaam = gs.Groente?.Naam ?? "-",        // Groente is nullable
                    SausNaam = gs.Saus?.Naam ?? "-"               // Saus is nullable
                }))
                .ToList();

            // ViewModel voor de weergave
            var viewModel = new PersoneelBestellingDetailsViewModel
            {
                BestellingId = bestelling.Id,  // Gebruik Id van Bestelling
                Tafelnummers = tafelnummers,   // Tafelnummers uit BestellingTafels
                Besteldatum = bestelling.Besteldatum,  // Besteldatum
                BereidingstijdMinuten = bereidingstijd,  // Bereidingstijd in minuten
                Gerechten = gerechtenVm  // Gerechten met hun samenstellingen
            };

            // Teruggeven van de view met het model
            return View("~/Views/Personeel/Bestellingen/Details/Index.cshtml", viewModel);
        }
    }
}
