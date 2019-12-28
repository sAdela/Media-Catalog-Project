CREATE DATABASE [Media-Catalog]
use [Media-Catalog]

INSERT INTO Artists VALUES ('Dino', 'Merlin')
INSERT INTO Artists VALUES ('Kiki', 'Lesendric')
INSERT INTO Artists VALUES ('Petar', 'Graso')


INSERT INTO Genres VALUES ('Pop')
INSERT INTO Genres VALUES ('Rock')

INSERT INTO Countries VALUES ('BiH')
INSERT INTO Countries VALUES ('Croatia')
INSERT INTO Countries VALUES ('Serbia')

INSERT INTO Publishers VALUES ('Record Media')
INSERT INTO Publishers VALUES ('Magaza')
INSERT INTO Publishers VALUES ('TopMedia')

SELECT * FROM Publishers
SELECT * FROM Artists
SELECT * FROM Genres
SELECT * FROM Countries

INSERT INTO MediaItems VALUES ('Deset mlada', 2, 1, 1, 1, '12-12-2012')
INSERT INTO MediaItems VALUES ('Leto', 1, 2, 3, 2, '12-10-2010')
INSERT INTO MediaItems VALUES ('Ako te pitaju', 3, 3, 2, 1, '08-08-2018')
INSERT INTO MediaItems VALUES ('Nedostajes', 2, 1, 1, 1, '10-12-2014')
INSERT INTO MediaItems VALUES ('To je sudbina', 1, 2, 3, 2, '08-10-2017')
INSERT INTO MediaItems VALUES ('Fritula', 3, 3, 2, 1, '08-08-2019')
INSERT INTO MediaItems VALUES ('Slucajno', 1, 2, 3, 1, '12-10-2010')
