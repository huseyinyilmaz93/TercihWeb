/*
DROP TABLE UniFak
DROP TABLE UniFakBol
DROP TABLE Universite
DROP TABLE Fakulte
DROP TABLE Bolum
*/


CREATE TABLE Universite (
uniNo INT PRIMARY KEY IDENTITY(1,1),
uniAdi NVARCHAR(200) NOT NULL,
il NVARCHAR(20) NOT NULL,
uniTuru NVARCHAR(20),
webAdresi CHAR(30),
);


CREATE TABLE Fakulte (
fakNo INT PRIMARY KEY IDENTITY(1,1),
fakAdi NVARCHAR(200) NOT NULL,
);

CREATE TABLE Bolum (
bolumKodu NVARCHAR(20) PRIMARY KEY,
bolAdi NVARCHAR(200) NOT NULL,
puanTuru NVARCHAR(10) NOT NULL,
siralama INT,
kontenjan INT,
yerlesen INT,
enKucukPuan REAL,
enYuksekPuan REAL,
oEnKucukPuan REAL,
oEnYuksekPuan REAL,
);

CREATE TABLE UniFak (
uniNo INT FOREIGN KEY REFERENCES Universite(uniNo),
fakNo INT FOREIGN KEY REFERENCES Fakulte(fakNo),
);

CREATE TABLE UniFakBol (
uniNo INT FOREIGN KEY REFERENCES Universite(uniNo),
fakNo INT FOREIGN KEY REFERENCES Fakulte(fakNo),
bolumKodu NVARCHAR(20) FOREIGN KEY REFERENCES Bolum(bolumKodu),
);