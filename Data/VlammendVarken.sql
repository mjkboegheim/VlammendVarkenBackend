-- =======================
-- TAFELS EN TAFELGROEPEN
-- =======================

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
  -- XOR-logica moet in applicatielaag worden afgedwongen
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
  FOREIGN KEY (gerechtcategorie_id) REFERENCES GerechtCategorie(gerechtcategorie_id)
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
