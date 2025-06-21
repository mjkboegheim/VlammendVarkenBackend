-- ===========================
-- TAFELS EN TAFELGROEPEN
-- ===========================

CREATE TABLE Tafel (
  tafel_id INT PRIMARY KEY
);

CREATE TABLE TafelGroep (
  tafelgroep_id INT PRIMARY KEY,
  code VARCHAR(10) NOT NULL,
  aantal_personen INT NOT NULL
);

CREATE TABLE TafelGroepTafel (
  tafelgroep_id INT,
  tafel_id INT,
  PRIMARY KEY (tafelgroep_id, tafel_id),
  FOREIGN KEY (tafelgroep_id) REFERENCES TafelGroep(tafelgroep_id),
  FOREIGN KEY (tafel_id) REFERENCES Tafel(tafel_id)
);

-- ===============
-- RESERVERINGEN
-- ===============

CREATE TABLE Reservering (
  reservering_id INT PRIMARY KEY,
  tafel_id INT,
  tafelgroep_id INT,
  tijd DATETIME NOT NULL,
  status VARCHAR(50) NOT NULL,
  FOREIGN KEY (tafel_id) REFERENCES Tafel(tafel_id),
  FOREIGN KEY (tafelgroep_id) REFERENCES TafelGroep(tafelgroep_id)
);

-- ============
-- BESTELLINGEN
-- ============

CREATE TABLE Bestelling (
  bestelling_id INT PRIMARY KEY,
  reservering_id INT NOT NULL,
  besteld_voorgerecht BOOLEAN,
  besteld_hoofdgerecht BOOLEAN,
  besteld_nagerecht BOOLEAN,
  is_volwassen BOOLEAN,
  FOREIGN KEY (reservering_id) REFERENCES Reservering(reservering_id)
);

-- ===============
-- ALLERGIEËN
-- ===============

CREATE TABLE Allergie (
  allergie_id INT PRIMARY KEY,
  naam VARCHAR(100) NOT NULL
);

CREATE TABLE BestellingAllergie (
  bestelling_id INT,
  allergie_id INT,
  PRIMARY KEY (bestelling_id, allergie_id),
  FOREIGN KEY (bestelling_id) REFERENCES Bestelling(bestelling_id),
  FOREIGN KEY (allergie_id) REFERENCES Allergie(allergie_id)
);

-- ==================
-- GERECHTEN & CATEGORIEËN
-- ==================

CREATE TABLE GerechtCategorie (
  gerechtcategorie_id INT PRIMARY KEY,
  naam VARCHAR(100) NOT NULL
);

CREATE TABLE Gerecht (
  gerecht_id INT PRIMARY KEY,
  gerechtcategorie_id INT NOT NULL,
  naam VARCHAR(100) NOT NULL,
  bereidingstijd INT NOT NULL,
  prijs DECIMAL(5,2) NOT NULL,
  bijgerecht_id INT,
  groente_id INT,
  saus_id INT,
  FOREIGN KEY (gerechtcategorie_id) REFERENCES GerechtCategorie(gerechtcategorie_id),
  FOREIGN KEY (bijgerecht_id) REFERENCES Gerecht(gerecht_id),
  FOREIGN KEY (groente_id) REFERENCES Product(product_id),
  FOREIGN KEY (saus_id) REFERENCES Product(product_id)
);

CREATE TABLE BestellingGerecht (
  bestellinggerecht_id INT PRIMARY KEY,
  bestelling_id INT NOT NULL,
  gerecht_id INT NOT NULL,
  serveren_na INT,
  FOREIGN KEY (bestelling_id) REFERENCES Bestelling(bestelling_id),
  FOREIGN KEY (gerecht_id) REFERENCES Gerecht(gerecht_id)
);

-- =================
-- PRODUCTEN & INGREDIËNTEN
-- =================

CREATE TABLE ProductCategorie (
  productcategorie_id INT PRIMARY KEY,
  naam VARCHAR(100) NOT NULL
);

CREATE TABLE Product (
  product_id INT PRIMARY KEY,
  productcategorie_id INT NOT NULL,
  naam VARCHAR(100) NOT NULL,
  FOREIGN KEY (productcategorie_id) REFERENCES ProductCategorie(productcategorie_id)
);

CREATE TABLE Ingredient (
  gerecht_id INT,
  product_id INT,
  hoeveelheid DECIMAL(10,2) NOT NULL,
  PRIMARY KEY (gerecht_id, product_id),
  FOREIGN KEY (gerecht_id) REFERENCES Gerecht(gerecht_id),
  FOREIGN KEY (product_id) REFERENCES Product(product_id)
);

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
-- PRODUCT CATEGORIEËN
-- =======================

INSERT INTO ProductCategorie (productcategorie_id, naam) VALUES
(1, 'Vlees'),
(2, 'Vis'),
(3, 'Groenten'),
(4, 'Zuivel'),
(5, 'Overige'),
(6, 'Sauzen');  -- Nieuw toegevoegd

-- =======================
-- PRODUCTEN (grillgericht)
-- =======================

INSERT INTO Product (product_id, productcategorie_id, naam) VALUES
(1, 1, 'Ribeye'),
(2, 1, 'Kipfilet'),
(3, 1, 'Varkenshaas'),
(4, 1, 'BBQ-Worst'),
(5, 2, 'Garnalen'),
(6, 3, 'Paprika'),
(7, 3, 'Maïs'),
(8, 3, 'Sla'),
(9, 4, 'Feta'),
(10, 4, 'Vanille-ijs'),
(11, 5, 'Brownie'),
(12, 5, 'Burgerbroodje'),
(13, 6, 'BBQ-Saus'); -- Correcte saus toegevoegd

-- =======================
-- GERECHTEN (grillrestaurant)
-- =======================

INSERT INTO Gerecht (gerecht_id, gerechtcategorie_id, naam, bereidingstijd, prijs, bijgerecht_id, groente_id, saus_id) VALUES
(1, 1, 'Gegrilde Paprika met Feta', 12, 7.50, NULL, NULL, NULL),
(2, 1, 'Spies van Garnalen', 15, 9.00, NULL, NULL, NULL),
(3, 2, 'Ribeye van de Grill', 25, 21.00, NULL, NULL, NULL),
(4, 2, 'Mixed Grill (Kip, Varkenshaas, Worst)', 30, 24.50, NULL, NULL, NULL),
(5, 3, 'Gegrilde Maïskolf', 10, 4.50, NULL, NULL, NULL),
(6, 4, 'Brownie met Vanille-ijs', 10, 6.50, NULL, NULL, NULL),
(7, 5, 'Dagemenu: BBQ Burger & Cheesecake', 35, 19.50, 5, 8, 13); -- Correcte saus (BBQ-Saus)

-- =======================
-- INGREDIËNTEN
-- =======================

INSERT INTO Ingredient (gerecht_id, product_id, hoeveelheid) VALUES
(1, 6, 0.50),
(1, 9, 0.30),
(2, 5, 0.70),
(3, 1, 1.00),
(4, 2, 0.50),
(4, 3, 0.40),
(4, 4, 0.40),
(5, 7, 1.00),
(6, 11, 1.00),
(6, 10, 0.50),
(7, 12, 1.00),
(7, 2, 0.40),
(7, 11, 0.50);

-- =======================
-- TAFELS
-- =======================

INSERT INTO Tafel (tafel_id) VALUES
(1), (2), (3);

-- =======================
-- TAFELGROEPEN
-- =======================

INSERT INTO TafelGroep (tafelgroep_id, code, aantal_personen) VALUES
(1, 'G1', 2),
(2, 'G2', 4);

-- =======================
-- KOPPELING TAFELGROEP - TAFEL
-- =======================

INSERT INTO TafelGroepTafel (tafelgroep_id, tafel_id) VALUES
(1, 1),
(2, 2),
(2, 3);

-- =======================
-- RESERVERINGEN
-- =======================

INSERT INTO Reservering (reservering_id, tafel_id, tafelgroep_id, tijd, status) VALUES
(1, 1, NULL, '2025-06-21 18:00:00', 'Gereserveerd'),
(2, NULL, 2, '2025-06-21 19:30:00', 'Bevestigd');

-- =======================
-- BESTELLINGEN
-- =======================

INSERT INTO Bestelling (bestelling_id, reservering_id, besteld_voorgerecht, besteld_hoofdgerecht, besteld_nagerecht, is_volwassen) VALUES
(1, 1, 1, 3, 0, 1),
(2, 2, 2, 4, 6, 1);

-- =======================
-- ALLERGIEËN
-- =======================

INSERT INTO Allergie (allergie_id, naam) VALUES
(1, 'Gluten'),
(2, 'Lactose'),
(3, 'Schaaldieren');

-- =======================
-- KOPPELING BESTELLING - ALLERGIE
-- =======================

INSERT INTO BestellingAllergie (bestelling_id, allergie_id) VALUES
(1, 1),
(2, 3);

-- =======================
-- BESTELLING GERECHTEN
-- =======================

INSERT INTO BestellingGerecht (bestellinggerecht_id, bestelling_id, gerecht_id, serveren_na) VALUES
(1, 1, 5, NULL),
(2, 1, 3, 15),
(3, 2, 4, NULL),
(4, 2, 6, 20);
