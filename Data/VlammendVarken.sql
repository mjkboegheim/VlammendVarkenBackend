-- ===========================
-- TAFELS EN TAFELGROEPEN
-- ===========================

CREATE TABLE Tafels (
  tafel_id INTEGER PRIMARY KEY
);

CREATE TABLE TafelGroepen (
  tafelgroep_id INTEGER PRIMARY KEY,
  code VARCHAR(10) NOT NULL CHECK (TRIM(code) <> ''),
  aantal_personen INTEGER NOT NULL CHECK (aantal_personen > 0)
);

CREATE TABLE TafelGroepTafels (
  tafelgroep_id INTEGER NOT NULL,
  tafel_id INTEGER NOT NULL,
  PRIMARY KEY (tafelgroep_id, tafel_id),
  FOREIGN KEY (tafelgroep_id) REFERENCES TafelGroepen(tafelgroep_id) ON DELETE CASCADE,
  FOREIGN KEY (tafel_id) REFERENCES Tafels(tafel_id) ON DELETE CASCADE
);

-- ===============
-- RESERVERINGEN
-- ===============

CREATE TABLE Reserveringen (
  reservering_id INTEGER PRIMARY KEY,
  tafel_id INTEGER,
  tafelgroep_id INTEGER,
  tijd DATETIME NOT NULL,
  status VARCHAR(50) NOT NULL CHECK (TRIM(status) <> ''),
  FOREIGN KEY (tafel_id) REFERENCES Tafels(tafel_id),
  FOREIGN KEY (tafelgroep_id) REFERENCES TafelGroepen(tafelgroep_id)
);

-- ============
-- BESTELLINGEN
-- ============

CREATE TABLE Bestellingen (
  bestelling_id INTEGER PRIMARY KEY,
  reservering_id INTEGER NOT NULL,
  besteld_voorgerecht BOOLEAN NOT NULL DEFAULT 0 CHECK (besteld_voorgerecht IN (0, 1)),
  besteld_hoofdgerecht BOOLEAN NOT NULL DEFAULT 0 CHECK (besteld_hoofdgerecht IN (0, 1)),
  besteld_nagerecht BOOLEAN NOT NULL DEFAULT 0 CHECK (besteld_nagerecht IN (0, 1)),
  is_volwassen BOOLEAN NOT NULL DEFAULT 1 CHECK (is_volwassen IN (0, 1)),
  FOREIGN KEY (reservering_id) REFERENCES Reserveringen(reservering_id)
);

-- ===============
-- ALLERGIEEN
-- ===============

CREATE TABLE Allergieen (
  allergie_id INTEGER PRIMARY KEY,
  naam VARCHAR(100) NOT NULL CHECK (TRIM(naam) <> '')
);

CREATE TABLE BestellingAllergieen (
  bestelling_id INTEGER NOT NULL,
  allergie_id INTEGER NOT NULL,
  PRIMARY KEY (bestelling_id, allergie_id),
  FOREIGN KEY (bestelling_id) REFERENCES Bestellingen(bestelling_id),
  FOREIGN KEY (allergie_id) REFERENCES Allergieen(allergie_id)
);

CREATE TABLE GerechtAllergieen (
  gerecht_id INTEGER NOT NULL,
  allergie_id INTEGER NOT NULL,
  PRIMARY KEY (gerecht_id, allergie_id),
  FOREIGN KEY (gerecht_id) REFERENCES Gerechten(gerecht_id),
  FOREIGN KEY (allergie_id) REFERENCES Allergieen(allergie_id)
);

-- ==================
-- GERECHTEN & CATEGORIEEN
-- ==================

CREATE TABLE GerechtCategorieen (
  gerechtcategorie_id INTEGER PRIMARY KEY,
  naam VARCHAR(100) NOT NULL CHECK (TRIM(naam) <> '')
);

CREATE TABLE ProductCategorieen (
  productcategorie_id INTEGER PRIMARY KEY,
  naam VARCHAR(100) NOT NULL CHECK (TRIM(naam) <> '')
);

CREATE TABLE Producten (
  product_id INTEGER PRIMARY KEY,
  productcategorie_id INTEGER NOT NULL,
  naam VARCHAR(100) NOT NULL CHECK (TRIM(naam) <> ''),
  FOREIGN KEY (productcategorie_id) REFERENCES ProductCategorieen(productcategorie_id)
);

CREATE TABLE Gerechten (
  gerecht_id INTEGER PRIMARY KEY,
  gerechtcategorie_id INTEGER NOT NULL,
  naam VARCHAR(100) NOT NULL CHECK (TRIM(naam) <> ''),
  beschrijving TEXT,
  bereidingstijd INTEGER NOT NULL CHECK (bereidingstijd > 0),
  prijs DECIMAL(5,2) NOT NULL CHECK (prijs >= 0),
  bijgerecht_id INTEGER,
  groente_id INTEGER,
  saus_id INTEGER,
  FOREIGN KEY (gerechtcategorie_id) REFERENCES GerechtCategorieen(gerechtcategorie_id),
  FOREIGN KEY (bijgerecht_id) REFERENCES Gerechten(gerecht_id),
  FOREIGN KEY (groente_id) REFERENCES Producten(product_id),
  FOREIGN KEY (saus_id) REFERENCES Producten(product_id)
);

CREATE TABLE BestellingGerechten (
  bestellinggerecht_id INTEGER PRIMARY KEY,
  bestelling_id INTEGER NOT NULL,
  gerecht_id INTEGER NOT NULL,
  serveren_na INTEGER,
  FOREIGN KEY (bestelling_id) REFERENCES Bestellingen(bestelling_id),
  FOREIGN KEY (gerecht_id) REFERENCES Gerechten(gerecht_id)
);

-- ===================
-- INGREDIENTEN
-- ===================

CREATE TABLE Ingredienten (
  gerecht_id INTEGER NOT NULL,
  product_id INTEGER NOT NULL,
  hoeveelheid DECIMAL(10,2) NOT NULL CHECK (hoeveelheid > 0),
  PRIMARY KEY (gerecht_id, product_id),
  FOREIGN KEY (gerecht_id) REFERENCES Gerechten(gerecht_id),
  FOREIGN KEY (product_id) REFERENCES Producten(product_id)
);

-- =======================
-- INSERTS
-- =======================

INSERT INTO GerechtCategorieen VALUES
(1, 'Voorgerechten'),
(2, 'Hoofdgerechten'),
(3, 'Bijgerechten'),
(4, 'Nagerechten'),
(5, 'Dagmenu');

INSERT INTO ProductCategorieen VALUES
(1, 'Vlees'), (2, 'Vis'), (3, 'Groenten'), (4, 'Zuivel'), (5, 'Overige'), (6, 'Sauzen');

INSERT INTO Producten VALUES
(1, 1, 'Ribeye'), (2, 1, 'Kipfilet'), (3, 1, 'Varkenshaas'), (4, 1, 'BBQ-Worst'),
(5, 2, 'Garnalen'), (6, 3, 'Paprika'), (7, 3, 'Maïs'), (8, 3, 'Sla'),
(9, 4, 'Feta'), (10, 4, 'Vanille-ijs'), (11, 5, 'Brownie'), (12, 5, 'Burgerbroodje'), (13, 6, 'BBQ-Saus'),
(14, 2, 'Zalmfilet'); -- ✅ nieuwe vis toegevoegd

INSERT INTO Gerechten VALUES
(1, 1, 'Gegrilde Paprika met Feta', 'Geroosterde paprika met romige feta', 12, 7.50, NULL, NULL, NULL),
(2, 1, 'Spies van Garnalen', 'Gegrilde spies met gemarineerde garnalen', 15, 9.00, NULL, NULL, NULL),
(3, 2, 'Ribeye van de Grill', 'Perfect gegrilde ribeye met een rijke smaak', 25, 21.00, NULL, NULL, NULL),
(4, 2, 'Mixed Grill (Kip, Varkenshaas, Worst)', 'Combinatie van gegrild vlees', 30, 24.50, NULL, NULL, NULL),
(5, 3, 'Gegrilde Maïskolf', 'Maïskolf met rokerige grillsmaak', 10, 4.50, NULL, NULL, NULL),
(6, 4, 'Brownie met Vanille-ijs', 'Warme brownie met romig ijs', 10, 6.50, NULL, NULL, NULL),
(7, 5, 'Dagmenu: BBQ Burger & Cheesecake', 'Ons zorgvuldig samengesteld dagmenu.', 35, 19.50, 5, 8, 13),
(9, 2, 'Gegrilde Paprika met Feta (hoofdgerecht)', 'Paprika met feta, als hoofdgerecht', 15, 12.50, NULL, 6, NULL),
(10, 2, 'Zalmfilet met Groenten', 'Zacht gegaarde zalmfilet met seizoensgroenten', 20, 18.00, NULL, 7, NULL);

INSERT INTO Ingredienten VALUES
(1, 6, 0.50), (1, 9, 0.30),
(2, 5, 0.70),
(3, 1, 1.00),
(4, 2, 0.50), (4, 3, 0.40), (4, 4, 0.40),
(5, 7, 1.00),
(6, 11, 1.00), (6, 10, 0.50),
(7, 12, 1.00), (7, 2, 0.40), (7, 11, 0.50),
(9, 6, 0.50), (9, 9, 0.30), -- Paprika + feta
(10, 14, 1.00), (10, 7, 0.50); -- Zalmfilet + Maïs

INSERT INTO Tafels VALUES (1), (2), (3);

INSERT INTO TafelGroepen VALUES (1, 'G1', 2), (2, 'G2', 4);
INSERT INTO TafelGroepTafels VALUES (1, 1), (2, 2), (2, 3);

INSERT INTO Reserveringen VALUES
(1, 1, NULL, '2025-06-21 18:00:00', 'Gereserveerd'),
(2, NULL, 2, '2025-06-21 19:30:00', 'Bevestigd');

INSERT INTO Bestellingen VALUES
(1, 1, 1, 1, 0, 1),
(2, 2, 1, 1, 1, 1);

INSERT INTO Allergieen VALUES
(1, 'Gluten'), (2, 'Lactose'), (3, 'Schaaldieren');

INSERT INTO BestellingAllergieen VALUES
(1, 1), (2, 3);

INSERT INTO GerechtAllergieen VALUES
(2, 3), (6, 2), (7, 1);

INSERT INTO BestellingGerechten VALUES
(1, 1, 5, NULL), (2, 1, 3, 15), (3, 2, 4, NULL), (4, 2, 6, 20);
