--SE REALIZA LA CREACIÓN DE LA BASE DE DATOS.
CREATE DATABASE MacroPay;

/*CREACIÓN DE TABLA PARA ALMACENAR DATOS RELACIONADOS AL LIBRO.*/
DROP TABLE IF EXISTS Books;
CREATE TABLE Books (
  Book_id int DEFAULT NULL,
  Title varchar(250) DEFAULT NULL,
  [Year] int DEFAULT NULL,
  Author varchar(250) DEFAULT NULL,
  PRIMARY KEY(Book_id)
)
--INSERCIÓN DE DATOS A LA TABLA BOOK
INSERT INTO Books VALUES 
(101,'A tale Of Two Cities',1859,'Charles Dickens'),
(102,'The Lord of the Rings',1955,'J. R. R. Tolkien'),
(103,'The Hobbit',1937,NULL),
(104,'The Little Prince',1943,'Antoine de Saint-Exupéry');

/*CREACIÓN DE TABLA Reviewers*/
DROP TABLE IF EXISTS Reviewers;
CREATE TABLE Reviewers (
  Reviewer_id int NOT NULL,
  [Name] varchar(250) DEFAULT NULL
  PRIMARY KEY(Reviewer_id)
)
--INSERCIÓN A LA TABLA REVIEWERS
INSERT INTO Reviewers VALUES 
(15201,'Joe Martinez'),
(53202,'Alice Lewis'),
(44203,'John Smith');

/*CREACIÓN DE TABLA RAITNGS CON LLAVE COMPUESTA POR Reviewer,Book y Rating IDS.*/

DROP TABLE IF EXISTS Ratings;
CREATE TABLE Ratings (
  Reviewer_id int NOT NULL,
  Book_id int NOT NULL,
  Rating int NOT NULL,
  Rating_date date DEFAULT NULL
  PRIMARY KEY(Reviewer_id,Book_id,Rating)
)
--INSERCIÓN A LA TABLA RAING
INSERT INTO Ratings VALUES 
(15201,101,2,'2015-02-11'),
(15201,101,4,'2015-06-16'),
(53202,103,4,NULL);


/*CONSULTA PARA OBTENER LOS DATOS SOLICTADOS*/
SELECT Rev.Name, Bk.Title, Rat.Rating, Rat.Rating_date
FROM dbo.Ratings Rat
INNER JOIN dbo.Books (NOLOCK) Bk ON Rat.Book_id = Bk.Book_id 
INNER JOIN dbo.Reviewers (NOLOCK) Rev ON Rat.Reviewer_id = Rev.Reviewer_id
ORDER BY Rev.Name ASC, Bk.Title ASC, Rat.Rating ASC