-- Tabellen

CREATE TABLE Allergenen (
  allergeenId INT PRIMARY KEY,
  symbool VARCHAR(100) NOT NULL,
  beschrijving VARCHAR(100) NOT NULL
);

CREATE TABLE Gerechten (
  gerechtId INT PRIMARY KEY,
  soort VARCHAR(100) NOT NULL,
  naam VARCHAR(100) NOT NULL
);

CREATE TABLE Hoofdonderdelen (
  hoofdonderdeelId INT PRIMARY KEY,
  naam VARCHAR(100) NOT NULL,
  prijs DECIMAL NOT NULL
);

CREATE TABLE Bijgerechten (
  bijgerechtId INT PRIMARY KEY,
  naam VARCHAR(100) NOT NULL,
  prijs DECIMAL NOT NULL
);

CREATE TABLE Groenten (
  groenteId INT PRIMARY KEY,
  naam VARCHAR(100) NOT NULL,
  prijs DECIMAL NOT NULL
);

CREATE TABLE Sausen (
  sausId INT PRIMARY KEY,
  naam VARCHAR(100) NOT NULL,
  prijs DECIMAL NOT NULL
);

CREATE TABLE Tafels (
  tafelId INT PRIMARY KEY,
  nummer INT NOT NULL
);

CREATE TABLE Tafelgroepen (
  tafelgroepId INT PRIMARY KEY,
  naam VARCHAR(100) NOT NULL
);

CREATE TABLE TafelsTafelgroepen (
  tafelId INT NOT NULL,
  tafelgroepId INT NOT NULL,
  PRIMARY KEY (tafelId, tafelgroepId),
  FOREIGN KEY (tafelId) REFERENCES Tafels(tafelId),
  FOREIGN KEY (tafelgroepId) REFERENCES Tafelgroepen(tafelgroepId)
);

CREATE TABLE Levertijden (
  levertijdId INT PRIMARY KEY,
  minuten INT NOT NULL
);

CREATE TABLE Bestellingen (
  bestellingId INT PRIMARY KEY,
  levertijdId INT NOT NULL,
  besteldatum DATETIME NOT NULL,
  FOREIGN KEY (levertijdId) REFERENCES Levertijden(levertijdId)
);

CREATE TABLE GerechtSamenstellingen (
  gerechtId INT NOT NULL,
  hoofdonderdeelId INT NOT NULL,
  bijgerechtId INT NOT NULL,
  groenteId INT NOT NULL,
  sausId INT NOT NULL,
  PRIMARY KEY (gerechtId, hoofdonderdeelId, bijgerechtId, groenteId, sausId),
  FOREIGN KEY (gerechtId) REFERENCES Gerechten(gerechtId),
  FOREIGN KEY (hoofdonderdeelId) REFERENCES Hoofdonderdelen(hoofdonderdeelId),
  FOREIGN KEY (bijgerechtId) REFERENCES Bijgerechten(bijgerechtId),
  FOREIGN KEY (groenteId) REFERENCES Groenten(groenteId),
  FOREIGN KEY (sausId) REFERENCES Sausen(sausId)
);

CREATE TABLE HoofdonderdeelAllergenen (
  hoofdonderdeelId INT NOT NULL,
  allergeenId INT NOT NULL,
  PRIMARY KEY (hoofdonderdeelId, allergeenId),
  FOREIGN KEY (hoofdonderdeelId) REFERENCES Hoofdonderdelen(hoofdonderdeelId),
  FOREIGN KEY (allergeenId) REFERENCES Allergenen(allergeenId)
);

CREATE TABLE BijgerechtAllergenen (
  bijgerechtId INT NOT NULL,
  allergeenId INT NOT NULL,
  PRIMARY KEY (bijgerechtId, allergeenId),
  FOREIGN KEY (bijgerechtId) REFERENCES Bijgerechten(bijgerechtId),
  FOREIGN KEY (allergeenId) REFERENCES Allergenen(allergeenId)
);

CREATE TABLE GroenteAllergenen (
  groenteId INT NOT NULL,
  allergeenId INT NOT NULL,
  PRIMARY KEY (groenteId, allergeenId),
  FOREIGN KEY (groenteId) REFERENCES Groenten(groenteId),
  FOREIGN KEY (allergeenId) REFERENCES Allergenen(allergeenId)
);

CREATE TABLE SausAllergenen (
  sausId INT NOT NULL,
  allergeenId INT NOT NULL,
  PRIMARY KEY (sausId, allergeenId),
  FOREIGN KEY (sausId) REFERENCES Sausen(sausId),
  FOREIGN KEY (allergeenId) REFERENCES Allergenen(allergeenId)
);

CREATE TABLE BestellingGerechten (
  bestellingId INT NOT NULL,
  gerechtId INT NOT NULL,
  PRIMARY KEY (bestellingId, gerechtId),
  FOREIGN KEY (bestellingId) REFERENCES Bestellingen(bestellingId),
  FOREIGN KEY (gerechtId) REFERENCES Gerechten(gerechtId)
);

CREATE TABLE BestellingTafels (
  bestellingId INT NOT NULL,
  tafelId INT NOT NULL,
  PRIMARY KEY (bestellingId, tafelId),
  FOREIGN KEY (bestellingId) REFERENCES Bestellingen(bestellingId),
  FOREIGN KEY (tafelId) REFERENCES Tafels(tafelId)
);

-- Allergenen

INSERT INTO Allergenen (allergeenId, symbool, beschrijving) VALUES
(1, 'GLU', 'Bevat gluten'),
(2, 'LAC', 'Bevat lactose'),
(3, 'NOT', 'Bevat noten');

-- Gerechten

INSERT INTO Gerechten (gerechtId, soort, naam) VALUES
(1, 'Hoofdgerecht', 'Spaghetti Bolognese'),
(2, 'Hoofdgerecht', 'Kip Saté'),
(3, 'Dessert', 'Chocoladecake'),
(7, 'Voorgerecht', 'Caesar Salad'),
(8, 'Hoofdgerecht', 'Zalmfilet'),
(9, 'Dessert', 'Appeltaart');

-- Hoofdonderdelen

INSERT INTO Hoofdonderdelen (hoofdonderdeelId, naam, prijs) VALUES
(1, 'Spaghetti', 8.50),
(2, 'Kipfilet', 9.00),
(3, 'Rundvlees', 10.00),
(4, 'Zalm', 12.00),
(5, 'Tofu', 8.00);

-- Bijgerechten

INSERT INTO Bijgerechten (bijgerechtId, naam, prijs) VALUES
(1, 'Frietjes', 3.00),
(2, 'Rijst', 2.50),
(3, 'Salade', 2.00),
(4, 'Aardappelpuree', 2.80),
(5, 'Quinoa', 3.20);

-- Groenten

INSERT INTO Groenten (groenteId, naam, prijs) VALUES
(1, 'Broccoli', 1.50),
(2, 'Sperziebonen', 1.20),
(3, 'Worteltjes', 1.00),
(4, 'Spinazie', 1.30),
(5, 'Courgette', 1.40);

-- Sausen

INSERT INTO Sausen (sausId, naam, prijs) VALUES
(1, 'Tomatensaus', 0.50),
(2, 'Pindasaus', 0.70),
(3, 'Pepersaus', 0.60),
(4, 'Knoflooksaus', 0.65),
(5, 'Champignonsaus', 0.75);

-- Tafels

INSERT INTO Tafels (tafelId, nummer) VALUES
(1, 10),
(2, 11),
(3, 12),
(4, 13),
(5, 14),
(6, 15),
(7, 16),
(8, 17);

-- Tafelgroepen

INSERT INTO Tafelgroepen (tafelgroepId, naam) VALUES
(1, 'Terras'),
(2, 'Binnen'),
(3, 'VIP'),
(4, 'Balie');

-- Tafels en tafelgroepen koppeling (meerdere per tafel mogelijk)

INSERT INTO TafelsTafelgroepen (tafelId, tafelgroepId) VALUES
(1, 1),
(2, 1),
(3, 2),
(4, 2),
(5, 3),
(6, 3),
(7, 4),
(8, 4);

-- Levertijden

INSERT INTO Levertijden (levertijdId, minuten) VALUES
(1, 5),
(2, 15),
(3, 20),
(4, 25);

-- Bestellingen

INSERT INTO Bestellingen (bestellingId, levertijdId, besteldatum) VALUES
(1, 1, '2025-06-23 18:30:00'),
(2, 2, '2025-06-23 18:45:00'),
(6, 3, '2025-06-23 19:30:00'),
(7, 4, '2025-06-23 19:45:00'),
(8, 1, '2025-06-23 20:00:00'),
(9, 2, '2025-06-23 20:10:00'),
(10, 3, '2025-06-23 20:20:00'),
(11, 4, '2025-06-23 20:30:00'),
(12, 1, '2025-06-23 20:45:00');

-- Gerecht samenstellingen

INSERT INTO GerechtSamenstellingen (gerechtId, hoofdonderdeelId, bijgerechtId, groenteId, sausId) VALUES
(1, 1, 1, 1, 1),
(2, 2, 2, 2, 2),
(3, 3, 1, 3, 3),
(7, 5, 4, 4, 4),
(8, 4, 5, 5, 5),
(9, 3, 3, 2, 1),
(1, 5, 5, 5, 4),
(2, 4, 4, 4, 2),
(1, 2, 3, 3, 5),
(7, 1, 1, 1, 1);

-- Hoofdonderdeel allergenen

INSERT INTO HoofdonderdeelAllergenen (hoofdonderdeelId, allergeenId) VALUES
(1, 1), -- Spaghetti bevat gluten
(2, 2), -- Kipfilet bevat lactose
(4, 3), -- Zalm bevat noten (fictief)
(5, 2); -- Tofu bevat lactose (fictief)

-- Bijgerecht allergenen

INSERT INTO BijgerechtAllergenen (bijgerechtId, allergeenId) VALUES
(1, 1), -- Frietjes bevatten gluten
(4, 2), -- Aardappelpuree bevat lactose
(5, 1); -- Quinoa bevat gluten (fictief)

-- Groente allergenen

INSERT INTO GroenteAllergenen (groenteId, allergeenId) VALUES
(1, 3), -- Broccoli bevat noten (fictief)
(4, 1), -- Spinazie bevat gluten (fictief)
(5, 2); -- Courgette bevat lactose (fictief)

-- Saus allergenen

INSERT INTO SausAllergenen (sausId, allergeenId) VALUES
(2, 3), -- Pindasaus bevat noten
(4, 2), -- Knoflooksaus bevat lactose
(5, 3); -- Champignonsaus bevat noten

-- BestellingGerechten: meerdere gerechten per bestelling

INSERT INTO BestellingGerechten (bestellingId, gerechtId) VALUES
(1, 1),
(2, 2),
(6, 7),
(6, 8),
(7, 8),
(7, 9),
(8, 1),
(8, 3),
(9, 2),
(9, 4),
(10, 5),
(10, 6),
(11, 7),
(12, 8);

-- BestellingTafels: meerdere tafels per bestelling

INSERT INTO BestellingTafels (bestellingId, tafelId) VALUES
(1, 1),
(2, 2),
(6, 3),
(6, 4),
(7, 4),
(7, 5),
(8, 1),
(8, 5),
(9, 2),
(9, 3),
(10, 4),
(10, 5),
(11, 6),
(12, 7);

