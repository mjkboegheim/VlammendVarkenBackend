-- =======================
-- GERECHT CATEGORIEËN
-- =======================

INSERT INTO GerechtCategorie (gerechtcategorie_id, naam) VALUES
(1, 'Voorgerechten'),
(2, 'Hoofdgerechten'),
(3, 'Bijgerechten'),
(4, 'Nagerechten'),
(5, 'Dagemenu');

-- =======================
-- GERECHTEN
-- =======================

INSERT INTO Gerecht (gerecht_id, gerechtcategorie_id, naam, bereidingstijd) VALUES
(1, 1, 'Biefstuk met friet', 20),
(2, 1, 'Zalmfilet met groenten', 25),
(3, 2, 'Frietjes', 10),
(4, 2, 'Groene salade', 8),
(5, 3, 'Tomatensoep', 15),
(6, 4, 'Tiramisu', 12),
(7, 5, 'Dagemenu: Pasta & IJs', 30);

-- =======================
-- PRODUCT CATEGORIEËN
-- =======================

INSERT INTO ProductCategorie (productcategorie_id, naam) VALUES
(1, 'Vlees'),
(2, 'Vis'),
(3, 'Groenten'),
(4, 'Zuivel'),
(5, 'Overige');

-- =======================
-- PRODUCTEN
-- =======================

INSERT INTO Product (product_id, productcategorie_id, naam) VALUES
(1, 1, 'Biefstuk'),
(2, 2, 'Zalmfilet'),
(3, 3, 'Tomaten'),
(4, 3, 'Sla'),
(5, 3, 'Aardappelen'),
(6, 4, 'Room'),
(7, 5, 'Pasta');

-- =======================
-- INGREDIËNTEN
-- =======================

INSERT INTO Ingredient (gerecht_id, product_id, hoeveelheid) VALUES
(1, 1, 1.00),  -- Biefstuk met biefstuk
(1, 5, 0.50),  -- en aardappelen
(2, 2, 1.00),
(2, 4, 0.30),
(3, 5, 0.40),
(4, 4, 0.20),
(5, 3, 0.30),
(6, 6, 0.15),
(7, 7, 0.50);

-- =======================
-- TAFELS EN TAFELGROEPEN
-- =======================

INSERT INTO Tafel (tafel_id) VALUES (1), (2), (3);

INSERT INTO TafelGroep (tafelgroep_id, code, aantal_personen) VALUES
(1, 'T1', 2),
(2, 'T2', 4);

INSERT INTO TafelGroepTafel (tafelgroep_id, tafel_id) VALUES
(1, 1),
(2, 2),
(2, 3);

-- =======================
-- RESERVERINGEN
-- =======================

INSERT INTO Reservering (reservering_id, tafel_id, tafelgroep_id, tijd, status) VALUES
(1, 1, NULL, '2025-06-20 18:00:00', 'Gereserveerd'),
(2, NULL, 2, '2025-06-20 19:00:00', 'Bevestigd');

-- =======================
-- BESTELLINGEN
-- =======================

INSERT INTO Bestelling (bestelling_id, reservering_id, besteld_voorgerecht, besteld_hoofdgerecht, besteld_nagerecht, is_volwassen) VALUES
(1, 1, 1, 1, 0, 1),
(2, 2, 0, 1, 1, 0);

-- =======================
-- ALLERGIEËN
-- =======================

INSERT INTO Allergie (allergie_id, naam) VALUES
(1, 'Gluten'),
(2, 'Lactose'),
(3, 'Noten');

INSERT INTO BestellingAllergie (bestelling_id, allergie_id) VALUES
(1, 1),
(2, 2);

-- =======================
-- BESTELLING GERECHTEN
-- =======================

INSERT INTO BestellingGerecht (bestellinggerecht_id, bestelling_id, gerecht_id, serveren_na) VALUES
(1, 1, 5, NULL),  -- Tomatensoep (voorgerecht)
(2, 1, 1, 15),    -- Biefstuk na 15 min
(3, 2, 2, NULL),  -- Zalm
(4, 2, 6, 20);    -- Tiramisu na 20 min
