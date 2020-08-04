Sql

CREATE DATABASE RealcommerceSystem;


CREATE TABLE CITIES (
	cityKey nvarchar(50) PRIMARY KEY NOT NULL,
	cityLocalizedName nvarchar(50) NOT NULL,
	cityCountryLocalizedName nvarchar(50) NOT NULL,
	cityAdministrativeAreaLocalizedName nvarchar(50) NOT NULL
);

CREATE TABLE WEATHER (
	weatherKey nvarchar(50) PRIMARY KEY FOREIGN KEY REFERENCES CITIES(cityKey) NOT NULL,
	weatherText nvarchar(50) NOT NULL,
	weatherValue nvarchar(50) NOT NULL,
	weatherEpochTime bigint NOT NULL
);