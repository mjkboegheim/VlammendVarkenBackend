using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VlammendVarkenBackend.Models;
using VlammendVarkenBackend.Data;
using Microsoft.EntityFrameworkCore;

using VlammendVarkenBackend.Models.ViewModels;

namespace VlammendVarkenBackend.Controllers
{
    public class GerechtController : Controller
    {
        private readonly AppDbContext _context;

        public GerechtController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var dagmenu = _context.Gerecht
                .Include(g => g.GerechtCategorie)
                .Include(g => g.Bijgerecht)
                .Include(g => g.Groente)
                .Include(g => g.Saus)
                .Where(g => g.GerechtCategorieId == 5)
                .Select(g => new GerechtViewModel
                {
                    Id = g.GerechtId,
                    Naam = g.Naam,
                    Beschrijving = "Ons zorgvuldig samengesteld dagmenu.",
                    Prijs = g.Prijs,
                    Category = g.GerechtCategorie != null ? g.GerechtCategorie.Naam : string.Empty,
                    Bijgerecht = g.Bijgerecht != null ? g.Bijgerecht.Naam : null,
                    Groente = g.Groente != null ? g.Groente.Naam : null,
                    Saus = g.Saus != null ? g.Saus.Naam : null
                })
                .FirstOrDefault();

            return View("~/Views/Gerechten/Index.cshtml", dagmenu);
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
