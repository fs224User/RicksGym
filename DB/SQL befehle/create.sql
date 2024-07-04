--Skript zum erstellen der Tabellen
CREATE TABLE GYM_SETTINGS(
	SETTINGSUID	varchar2(1) PRIMARY KEY,
	keepmeloggedin varchar2(1),
	darkmode varchar(1)
);
CREATE TABLE GYM_CITYS(
	ZIPCODE varchar2(5) PRIMARY KEY,
	city varchar2(255)
);
CREATE TABLE GYM_ACCOUNT(
	username varchar2(255) PRIMARY KEY,
	password varchar2(255),
	_role varchar2(255),
	settingsuid varchar2(1),
	kundenid varchar2(10),
	vertragsnummer varchar2(10),
	FOREIGN KEY (settingsuid) REFERENCES gym_settings(settingsuid),
	FOREIGN KEY (kundenid) REFERENCES gym_kunden(kundenid),
	FOREIGN KEY (vertragsnummer) REFERENCES gym_vertraege(vertragsnummer)
);
CREATE TABLE gym_kursekunden(
	kursid varchar2(10) PRIMARY KEY,
	kundenid varchar2(10) PRIMARY KEY,
	FOREIGN KEY (kursid) REFERENCES gym_kurse(kursid),
	FOREIGN KEY (kundenid) REFERENCES gym_kunden(kundenid)
);
CREATE TABLE gym_kurse(
	kursid varchar2(10) PRIMARY KEY,
	name varchar2(255),
	beschreibung varchar2(255),
	startzeit timestamp,
	dauer float(10),
	capacity number(3),
	teilnehmer number(3)
);
CREATE TABLE gym_personalkurse(
	trainerID varchar2(10) PRIMARY KEY,
	kursid varchar2(10) PRIMARY KEY,
	FOREIGN KEY (trainerid) REFERENCES gym_personal(trainerid),
	FOREIGN KEY (kursid) REFERENCES gym_kurse(kursid)
);
ALTER TABLE GYM_KUNDEN 
ADD FOREIGN KEY (ZIPCODE) REFERENCES GYM_CITYS (ZIPCODE);

ALTER TABLE GYM_PERSONAL 
ADD FOREIGN KEY (ZIPCODE) REFERENCES gym_citys(zipcode);

CREATE TABLE gym_Geraete (
	machine_id varchar2(10),
	name varchar2(255),
	typ varchar2(255),
	brand varchar2(255),
	muscleGroup varchar2(255),
	equipmentType varchar2(255),
	status varchar2(255),
	aquisitiontime date,
	aquisitionprice number(10,2),
	weightrange varchar2(255),
	location varchar2(255),
	dimension varchar2(255)
);

CREATE TABLE gym_Kurse ( 
	kursid varchar2(10),
	name varchar2(255),
	description varchar2(255),
	startingtime timestamp,
	duration float,
	capacity number(3,0),
	participants number(3,0),
	room varchar2(255)
);

CREATE TABLE gym_Kunden (
	customer_id varchar2(10),
	contractNumber varchar2(10),
	zipCode varchar2(5),
	lastName varchar2(255),
	firstName varchar2(255),
	birthday date,
	telephone varchar2(255),
	email varchar2(255),
	streetName varchar2(255),
	houseNumber number(3,0)
);

CREATE TABLE gym_Personal (
	trainer_id varchar2(10),
	firstName varchar2(255),
	lastName varchar2(255),
	email varchar(255),
	telephone varchar2(255),
	jobtitle varchar2(255),
	salary number(10,2),
	iban varchar2(255),
	gender varchar2(255),
	hiringDate date,
	zipcode varchar2(5),
	street varchar2(255),
	hausnummer number(3,0)
);

CREATE TABLE gym_Vertraege (
	contractNumber varchar2(10),
	customer_id varchar2(10),
	contractType varchar2(255),
	amount number(10,2),
	startingDate date,
	status varchar2(255),
	endDate date,
	paymentMethod varchar2(255),
	iban varchar2(255)
);

CREATE TABLE GYM_SETTINGS(
	SETTINGSUID	varchar2(1) PRIMARY KEY,
	keepmeloggedin varchar2(1),
	darkmode varchar2(1)
);
CREATE TABLE GYM_ACCOUNT(
	username varchar2(255) PRIMARY KEY,
	password varchar2(255),
	rolle varchar2(255),
	settingsuid varchar2(1),
	customer_id varchar2(10),
	contractnumber varchar2(10),
	FOREIGN KEY (settingsuid) REFERENCES gym_settings(settingsuid),
	FOREIGN KEY (customer_id) REFERENCES gym_kunden(customer_id),
	FOREIGN KEY (contractnumber) REFERENCES gym_vertraege(contractnumber)
);
CREATE TABLE gym_kursekunden(
	kursid varchar2(10),
	customer_id varchar2(10),
	FOREIGN KEY (kursid) REFERENCES gym_kurse(kursid),
	FOREIGN KEY (customer_id) REFERENCES gym_kunden(customer_id),
	CONSTRAINT kursekunden_pk PRIMARY KEY (kursid, customer_id)
);
CREATE TABLE gym_kurse(
	kursid varchar2(10) PRIMARY KEY,
	name varchar2(255),
	beschreibung varchar2(255),
	startzeit timestamp,
	dauer float(10),
	capacity number(3),
	teilnehmer number(3)
);

ALTER TABLE gym_kurse ADD room varchar2(255);

CREATE TABLE gym_personalkurse(
	trainer_id varchar2(10),
	kursid varchar2(10),
	FOREIGN KEY (trainer_id) REFERENCES gym_personal(trainer_id),
	FOREIGN KEY (kursid) REFERENCES gym_kurse(kursid),
	CONSTRAINT personalkurse_pk PRIMARY KEY (kursid, trainer_id)
);

