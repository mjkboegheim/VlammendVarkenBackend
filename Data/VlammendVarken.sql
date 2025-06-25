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

INSERT INTO Allergenen (allergeenId, symbool, beschrijving) VALUES
(1, 'GLU', 'Bevat gluten'),
(2, 'LAC', 'Bevat lactose'),
(3, 'NOT', 'Bevat noten');

INSERT INTO Gerechten (gerechtId, soort, naam) VALUES
(1, 'Dagmenu', 'Dagmenu Special'),
(2, 'Voorgerecht', 'Tomatensoep'),
(3, 'Hoofdgerecht', 'Gegrilde Zalm'),
(4, 'Nagerecht', 'Vanilleijs');

INSERT INTO Hoofdonderdelen (hoofdonderdeelId, naam, prijs) VALUES
(1, 'Tomatensoep', 4.50),
(2, 'Zalmfilet', 12.00),
(3, 'Vanilleijs', 3.50);

INSERT INTO Bijgerechten (bijgerechtId, naam, prijs) VALUES
(1, 'Aardappelpuree', 3.50),
(2, '-', 0.00);

INSERT INTO Groenten (groenteId, naam, prijs) VALUES
(1, 'Spinazie', 2.00),
(2, '-', 0.00);

INSERT INTO Sausen (sausId, naam, prijs) VALUES
(1, 'Dillesaus', 0.75),
(2, '-', 0.00);

INSERT INTO Tafels (tafelId, nummer) VALUES
(1, 10),
(2, 11),
(3, 12);

INSERT INTO Levertijden (levertijdId, minuten) VALUES
(1, 5),
(2, 15);

INSERT INTO Bestellingen (bestellingId, levertijdId, besteldatum) VALUES
(1, 1, '2025-06-23 18:30:00'),
(2, 2, '2025-06-23 18:45:00');

INSERT INTO GerechtSamenstellingen (gerechtId, hoofdonderdeelId, bijgerechtId, groenteId, sausId) VALUES
(1, 2, 1, 1, 1),
(2, 1, 2, 2, 2),
(3, 2, 1, 1, 1),
(4, 3, 2, 2, 2);

INSERT INTO HoofdonderdeelAllergenen (hoofdonderdeelId, allergeenId) VALUES
(1, 2),
(2, 2),
(3, 1);

INSERT INTO BijgerechtAllergenen (bijgerechtId, allergeenId) VALUES
(1, 1);

INSERT INTO GroenteAllergenen (groenteId, allergeenId) VALUES
(1, 3);

INSERT INTO SausAllergenen (sausId, allergeenId) VALUES
(1, 2);

INSERT INTO BestellingGerechten (bestellingId, gerechtId) VALUES
(1, 1),
(2, 2);

INSERT INTO BestellingTafels (bestellingId, tafelId) VALUES
(1, 1),
(2, 2);
