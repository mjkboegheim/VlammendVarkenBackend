using VlammendVarkenBackend.Models;
using VlammendVarkenBackend.ViewModels;

namespace VlammendVarkenBackend.Helpers
{
    public static class ViewModelMapper
    {
        public static GerechtViewModel MapToViewModel(Gerecht gerecht)
        {
            return new GerechtViewModel
            {
                GerechtId = gerecht.GerechtId,
                Naam = gerecht.Naam,
                Beschrijving = gerecht.Beschrijving,
                Prijs = gerecht.Prijs,
                Bereidingstijd = gerecht.Bereidingstijd,
                Categorie = gerecht.GerechtCategorie?.Naam ?? string.Empty,
                BijgerechtNaam = gerecht.Bijgerecht?.Naam,
                GroenteNaam = gerecht.Groente?.Naam,
                SausNaam = gerecht.Saus?.Naam,
                Allergieen = gerecht.GerechtAllergieen != null
                    ? gerecht.GerechtAllergieen
                        .Where(ga => ga.Allergie != null)
                        .Select(ga => ga.Allergie!.Naam)
                        .ToList()
                    : new List<string>(),
                Ingredienten = gerecht.Ingredienten != null
                    ? gerecht.Ingredienten
                        .Where(i => i.Product != null)
                        .Select(i => new IngredientViewModel
                        {
                            ProductNaam = i.Product!.Naam,
                            Hoeveelheid = i.Hoeveelheid
                        }).ToList()
                    : new List<IngredientViewModel>()
            };
        }

        public static AllergieViewModel MapToViewModel(Allergie allergie, string? emoji = null)
        {
            return new AllergieViewModel
            {
                AllergieId = allergie.AllergieId,
                Naam = allergie.Naam,
            };
        }

        public static ProductViewModel MapToViewModel(Product product)
        {
            return new ProductViewModel
            {
                ProductId = product.ProductId,
                Naam = product.Naam,
                Categorie = product.ProductCategorie?.Naam ?? ""
            };
        }

        public static BestellingViewModel MapToViewModel(Bestelling bestelling)
        {
            return new BestellingViewModel
            {
                BestellingId = bestelling.BestellingId,
                IsVolwassen = bestelling.IsVolwassen,
                BesteldVoorgerecht = bestelling.BesteldVoorgerecht,
                BesteldHoofdgerecht = bestelling.BesteldHoofdgerecht,
                BesteldNagerecht = bestelling.BesteldNagerecht,
                Gerechten = bestelling.BestellingGerechten != null
                    ? bestelling.BestellingGerechten
                        .Where(bg => bg.Gerecht != null)
                        .Select(bg => MapToViewModel(bg.Gerecht!))
                        .ToList()
                    : new(),
                Allergieen = bestelling.BestellingAllergieen != null
                    ? bestelling.BestellingAllergieen
                        .Where(ba => ba.Allergie != null)
                        .Select(ba => MapToViewModel(ba.Allergie!))
                        .ToList()
                    : new()
            };
        }

        public static ReserveringViewModel MapToViewModel(Reservering r)
        {
            return new ReserveringViewModel
            {
                ReserveringId = r.ReserveringId,
                Tijd = r.Tijd,
                Status = r.Status,
                TafelId = r.TafelId,
                TafelGroepId = r.TafelGroepId,
                Bestellingen = r.Bestellingen != null
                    ? r.Bestellingen
                        .Select(b => MapToViewModel(b))
                        .ToList()
                    : new()
            };
        }

        public static GerechtOverzichtViewModel MapToOverzicht(Gerecht g)
        {
            return new GerechtOverzichtViewModel
            {
                Id = g.GerechtId,
                Naam = g.Naam,
                Prijs = g.Prijs,
                Bijgerecht = g.Bijgerecht?.Naam,
                Groente = g.Groente?.Naam,
                Saus = g.Saus?.Naam,
                Allergieen = g.GerechtAllergieen != null
                    ? g.GerechtAllergieen
                        .Where(ga => ga.Allergie != null)
                        .Select(ga => MapAllergieNaamNaarEmoji(ga.Allergie!.Naam))
                        .Where(e => !string.IsNullOrWhiteSpace(e))
                        .ToList()
                    : new()
            };
        }

        public static string MapAllergieNaamNaarEmoji(string? naam)
        {
            return naam?.ToLower() switch
            {
                "gluten" => "🌾",
                "lactose" => "🥛",
                "schaaldieren" => "🤐",
                _ => ""
            };
        }
    }
}
