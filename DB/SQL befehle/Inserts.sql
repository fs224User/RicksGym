--Skript zum erstellen der Testdaten

INSERT INTO GYM_SETTINGS
VALUES 
('3','1','1');
INSERT INTO GYM_KUNDEN
VALUES
('0000000003','0000000003','80333','Caldewell','Tan',TO_DATE('2001/11/24','YYYY/MM/DD'),'09495/560622','T.C@djöm.de','Am Landgraben',18);
INSERT INTO GYM_VERTRAEGE
VALUES
('C000000003','0000000003','Promo',20.10,TO_DATE('2024/07/01','YYYY/MM/DD'),'aktiv',TO_DATE('2024/07/02','YYYY/MM/DD'),'keine','DE89519519546574');
INSERT INTO GYM_ACCOUNT
VALUES
('tcal','tan','sklave',1,'0000000003','C000000003');
INSERT INTO GYM_GERAETE
VALUES
('M000000003','Maschine 3','Typ 3','Marke 3','Muskelgruppe 3','Type 3','Funktioniert',TO_DATE('2024/07/03','YYYY/MM/DD'),1542.99,'100-200','unten','150x150x150');
INSERT INTO GYM_MAINTENANCE
VALUES
('M000000003',TO_TIMESTAMP('2025-03-01 12:00:00','YYYY-MM-DD HH24:MI:SS'),5.5);
INSERT INTO GYM_PERSONALKURSE
VALUES
('0123456790','CAD0907242');

alter TABLE GYM_KUNDEN
Drop COLUMN CONTRACTNUMBER;

ALTER TABLE GYM_MAINTENANCE 
ADD PRIMARY KEY (MAINTENANCE_ID, NEXTMAINTENANCE);