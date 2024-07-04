INSERT INTO GYM_CITYS gc 
VALUES
('33100', 'Paderborn');


INSERT INTO GYM_PERSONAL gp 
VALUES
('0123456791','Maria','Mustermann','maria.mustermann@gamil.com','017322234480','Trainer',125000,'DE69100900001234568873','Female', To_Date('2022/09/05','YYYY/MM/DD'), '80333', 'Kuh Weg', 3);


INSERT INTO GYM_KURSE gk 
VALUES
('CAD0907242', 'CADIO', 'Cardio Training ist ein Ausdauertraining und zeichnet sich vor allem dadurch aus, dass es die Herz- und Atemfrequenz sowie auf längere Sicht die Ausdauer erhöht.', To_Date('2024/07/09','YYYY/MM/DD'), 75, 12, 11, 'Raum 5');

INSERT INTO GYM_KURSEKUNDEN gk 
VALUES
('BBP0207243','0000000003');

UPDATE GYM_PERSONAL  
SET ZIPCODE ='33100'
WHERE GYM_Personal.ZIPCODE = '30100';