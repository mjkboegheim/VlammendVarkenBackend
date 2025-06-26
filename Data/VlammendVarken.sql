CREATE TABLE Allergenen (
  id INT PRIMARY KEY,
  symbool VARCHAR(100) NOT NULL,
  beschrijving VARCHAR(100) NOT NULL
);

CREATE TABLE Gerechten (
  id INT PRIMARY KEY,
  soort VARCHAR(100) NOT NULL,
  naam VARCHAR(100) NOT NULL
);

CREATE TABLE Hoofdonderdelen (
  id INT PRIMARY KEY,
  naam VARCHAR(100) NOT NULL,
  prijs DECIMAL NOT NULL
);

CREATE TABLE Bijgerechten (
  id INT PRIMARY KEY,
  naam VARCHAR(100) NOT NULL,
  prijs DECIMAL NOT NULL
);

CREATE TABLE Groenten (
  id INT PRIMARY KEY,
  naam VARCHAR(100) NOT NULL,
  prijs DECIMAL NOT NULL
);

CREATE TABLE Sausen (
  id INT PRIMARY KEY,
  naam VARCHAR(100) NOT NULL,
  prijs DECIMAL NOT NULL
);

CREATE TABLE Tafels (
  id INT PRIMARY KEY,
  nummer INT NOT NULL
);

CREATE TABLE Levertijden (
  id INT PRIMARY KEY,
  minuten INT NOT NULL
);

CREATE TABLE Bestellingen (
  id INT PRIMARY KEY,
  levertijdId INT NOT NULL,
  besteldatum DATETIME NOT NULL,
  FOREIGN KEY (levertijdId) REFERENCES Levertijden(id)
);

CREATE TABLE GerechtSamenstellingen (
  gerechtId INT NOT NULL,
  hoofdonderdeelId INT NOT NULL,
  bijgerechtId INT NOT NULL,
  groenteId INT NOT NULL,
  sausId INT NOT NULL,
  PRIMARY KEY (gerechtId, hoofdonderdeelId, bijgerechtId, groenteId, sausId),
  FOREIGN KEY (gerechtId) REFERENCES Gerechten(id),
  FOREIGN KEY (hoofdonderdeelId) REFERENCES Hoofdonderdelen(id),
  FOREIGN KEY (bijgerechtId) REFERENCES Bijgerechten(id),
  FOREIGN KEY (groenteId) REFERENCES Groenten(id),
  FOREIGN KEY (sausId) REFERENCES Sausen(id)
);

CREATE TABLE HoofdonderdeelAllergenen (
  hoofdonderdeelId INT NOT NULL,
  allergeenId INT NOT NULL,
  PRIMARY KEY (hoofdonderdeelId, allergeenId),
  FOREIGN KEY (hoofdonderdeelId) REFERENCES Hoofdonderdelen(id),
  FOREIGN KEY (allergeenId) REFERENCES Allergenen(id)
);

CREATE TABLE BijgerechtAllergenen (
  bijgerechtId INT NOT NULL,
  allergeenId INT NOT NULL,
  PRIMARY KEY (bijgerechtId, allergeenId),
  FOREIGN KEY (bijgerechtId) REFERENCES Bijgerechten(id),
  FOREIGN KEY (allergeenId) REFERENCES Allergenen(id)
);

CREATE TABLE GroenteAllergenen (
  groenteId INT NOT NULL,
  allergeenId INT NOT NULL,
  PRIMARY KEY (groenteId, allergeenId),
  FOREIGN KEY (groenteId) REFERENCES Groenten(id),
  FOREIGN KEY (allergeenId) REFERENCES Allergenen(id)
);

CREATE TABLE SausAllergenen (
  sausId INT NOT NULL,
  allergeenId INT NOT NULL,
  PRIMARY KEY (sausId, allergeenId),
  FOREIGN KEY (sausId) REFERENCES Sausen(id),
  FOREIGN KEY (allergeenId) REFERENCES Allergenen(id)
);

CREATE TABLE BestellingGerechten (
  bestellingId INT NOT NULL,
  gerechtId INT NOT NULL,
  PRIMARY KEY (bestellingId, gerechtId),
  FOREIGN KEY (bestellingId) REFERENCES Bestellingen(id),
  FOREIGN KEY (gerechtId) REFERENCES Gerechten(id)
);

CREATE TABLE BestellingTafels (
  bestellingId INT NOT NULL,
  tafelId INT NOT NULL,
  PRIMARY KEY (bestellingId, tafelId),
  FOREIGN KEY (bestellingId) REFERENCES Bestellingen(id),
  FOREIGN KEY (tafelId) REFERENCES Tafels(id)
);

INSERT INTO Allergenen (id, symbool, beschrijving) VALUES
(1, 'GLU', 'Bevat gluten'), (2, 'LAC', 'Bevat lactose'), (3, 'NOT', 'Bevat noten');

INSERT INTO Gerechten (id, soort, naam) VALUES
(1, 'dagmenu', 'Dagmenu Special'), (2, 'voorgerecht', 'Tomatensoep'), (3, 'hoofdgerecht-vlees', 'Gegrilde Biefstuk'),
(4, 'hoofdgerecht-vis', 'Gegrilde Zalm'), (5, 'hoofdgerecht-vegetarisch', 'Gevulde Paprika'), (6, 'nagerecht', 'Chocolade Mousse');

INSERT INTO Hoofdonderdelen (id, naam, prijs) VALUES
(1, 'Biefstuk', 14.00), (2, 'Zalmfilet', 12.00), (3, 'Tomatensoep', 4.50), (4, 'Gevulde Paprika', 9.50), (5, 'Chocolade Mousse', 5.00);

INSERT INTO Bijgerechten (id, naam, prijs) VALUES
(1, 'Aardappelpuree', 3.50), (2, 'Rijst', 3.00), (3, '-', 0.00);

INSERT INTO Groenten (id, naam, prijs) VALUES
(1, 'Spinazie', 2.00), (2, 'Gegrilde Groenten', 2.50), (3, '-', 0.00);

INSERT INTO Sausen (id, naam, prijs) VALUES
(1, 'Pepersaus', 1.00), (2, 'Dillesaus', 0.75), (3, '-', 0.00);

INSERT INTO Tafels (id, nummer) VALUES
(1, 10), (2, 11), (3, 12);

INSERT INTO Levertijden (id, minuten) VALUES
(1, 5), (2, 15);

INSERT INTO Bestellingen (id, levertijdId, besteldatum) VALUES
(1, 1, '2025-06-23 18:30:00'), (2, 2, '2025-06-23 18:45:00');

INSERT INTO GerechtSamenstellingen (gerechtId, hoofdonderdeelId, bijgerechtId, groenteId, sausId) VALUES
(1, 2, 2, 2, 2), (2, 3, 3, 3, 3), (3, 1, 1, 1, 1), (4, 2, 2, 2, 2), (5, 4, 1, 1, 3), (6, 5, 3, 3, 3);

INSERT INTO HoofdonderdeelAllergenen (hoofdonderdeelId, allergeenId) VALUES
(1, 3), (2, 2), (3, 1), (4, 1), (5, 2);

INSERT INTO BijgerechtAllergenen (bijgerechtId, allergeenId) VALUES
(1, 1);

INSERT INTO GroenteAllergenen (groenteId, allergeenId) VALUES
(1, 3);

INSERT INTO SausAllergenen (sausId, allergeenId) VALUES
(2, 2);

INSERT INTO BestellingGerechten (bestellingId, gerechtId) VALUES
(1, 1), (2, 2);

INSERT INTO BestellingTafels (bestellingId, tafelId) VALUES
(1, 1), (2, 2);
