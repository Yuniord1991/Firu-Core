
/*--------------------------------------------------------------------------------------TAMAÑO*/
create table tamano_mascota /*cree una tabla para enum en los tamaños*/
(
   id integer primary key, -- no identity, so you can control the values
   tamano varchar(10) not null unique
);

insert into tamano_mascota (id, tamano)
values
  (1, 'Pequeno'),
  (2, 'Mediano'),
  (3, 'Grande');

/*--------------------------------------------------------------------------------------RESPONSABLE*/
 CREATE TABLE [Responsable] (
  id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
  nombre varchar(50) DEFAULT NULL,
  edad int NULL,
  provincia varchar(50) DEFAULT NULL,
  ciudad varchar(50) DEFAULT NULL,
  localidad varchar(50) DEFAULT NULL,
);

insert into Responsable (NOMBRE, EDAD, PROVINCIA, CIUDAD, LOCALIDAD)
values
  ('example1', 10, 'example1', 'example1', 'example1'),
  ('example2', 20, 'example2', 'example2', 'example2'),
  ('example3', 30, 'example3', 'example3', 'example3'),
  ('example4', 40, 'example4', 'example4', 'example4');

  --agregado por criterio de malos adoptantes --- niveles (ALTA - MEDIANA - BAJA))
  ALTER TABLE Responsable ADD puntuacion varchar(20)

/*--------------------------------------------------------------------------------------MASCOTA*/
CREATE TABLE [Mascota] (
  id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
  nombre varchar(50) DEFAULT NULL,
  raza varchar(50) DEFAULT NULL,
  edad int NULL,
  peso decimal(8,2) NULL,
  castrado bit default 0, /*booleano: default 0 = false, 1 = true*/
  tamano integer not null default 1,
  responsable_id int DEFAULT NULL,
  provincia varchar(50) DEFAULT NULL,
  ciudad varchar(50) DEFAULT NULL,
  localidad varchar(50) DEFAULT NULL,
  constraint fk_tamano_mascota foreign key (tamano) references tamano_mascota (id),
  constraint fk_Responsable foreign key (responsable_id) references Responsable (id)
);

INSERT INTO Mascota (nombre, raza, edad, peso, castrado, tamano, responsable_id, provincia, ciudad, localidad)
	VALUES
		('Max', 'Border Collie', 3, 25, 1, 3, 3, 'Cordoba', 'Cordoba', 'Capital'),
		('example2', 'example2', 2, 20, 0, 1, 2, 'example2', 'example2', 'example2');

/*--------------------------------------------------------------------------------------ORGANIZACION*/
CREATE TABLE [Organizacion] (
  id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
  cuit int NULL,
  nombre varchar(50) DEFAULT NULL,
  provincia varchar(50) DEFAULT NULL,
  ciudad varchar(50) DEFAULT NULL,
  localidad varchar(50) DEFAULT NULL,
);

INSERT INTO Organizacion (cuit, nombre, provincia, ciudad, localidad)
	VALUES
		(99999111, 'Organizacion1', 'Cordoba', 'Cordoba', 'Capital'),
		(99999222, 'Organizacion2', 'Cordoba', 'Cordoba', 'Capital'),
		(99999333, 'Organizacion3', 'Cordoba', 'Cordoba', 'Capital'),
		(99999444, 'Organizacion4', 'Cordoba', 'Cordoba', 'Capital');

/*--------------------------------------------------------------------------------------VOLUNTARIO*/
CREATE TABLE [Voluntario] (
  id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
  dni int NULL,
  nombre varchar(50) DEFAULT NULL,
  apellido varchar(50) DEFAULT NULL,
  edad int NULL,
  organizacion_id int DEFAULT NULL,
  provincia varchar(50) DEFAULT NULL,
  ciudad varchar(50) DEFAULT NULL,
  localidad varchar(50) DEFAULT NULL,
  constraint fk_Organizacion foreign key (organizacion_id) references Organizacion (id)
);

INSERT INTO Voluntario (dni, nombre, apellido, edad, organizacion_id, provincia, ciudad, localidad)
	VALUES
		(99999111, 'Voluntario7', 'Voluntario7', 47, 1, 'Cordoba', 'Cordoba', 'Capital'),
		(99999111, 'Voluntario6', 'Voluntario6', 21, 1, 'Cordoba', 'Cordoba', 'Capital'),
		(99999111, 'Voluntario1', 'Voluntario1', 21, 1, 'Cordoba', 'Cordoba', 'Capital'),
		(99999111, 'Voluntario2', 'Voluntario2', 22, 2, 'Cordoba', 'Cordoba', 'Capital'),
		(99999111, 'Voluntario3', 'Voluntario3', 23, 3, 'Cordoba', 'Cordoba', 'Capital'),
		(99999111, 'Voluntario4', 'Voluntario4', 24, 4, 'Cordoba', 'Cordoba', 'Capital');

/*--------------------------------------------------------------------------------------USER INFO*/

Create Table [UserInfo](
UserId Int Identity(1,1) Not null Primary Key,
FirstName Varchar(30) Not null,
LastName Varchar(30) Not null,
UserName Varchar(30) Not null,
Email Varchar(50) Not null,
Password Varchar(20) Not null,
CreatedDate DateTime Default(GetDate()) Not Null)
GO
Insert Into UserInfo(FirstName, LastName, UserName, Email, Password) 
Values ('Inventory', 'Admin', 'InventoryAdmin', 'InventoryAdmin@abc.com', '$admin@2017')

/*--------------------------------------------------------------------------------------CAMBIO DE NOMBRE DATABASE*/
ALTER DATABASE [FiruProjectDB] MODIFY NAME = [FiruDB]

select * from mascota

/*--------------------------------------------------------------------------------------CAMPO ESPECIE*/
ALTER TABLE Mascota ADD especie varchar(20)

select * from mascota

/*--------------------------------------------------------------------------------------MOVIMIENTOS*/
CREATE TABLE [Movimiento] (
  id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
  tipo varchar(50) DEFAULT NULL,
  remitente varchar(50) DEFAULT NULL,
  destino varchar(50) DEFAULT NULL,
  motivo varchar(100) DEFAULT NULL,
  fecha date NULL,
  monto decimal(19,2) NULL,
  direccion_remitente varchar(100) DEFAULT NULL,
  direccion_destino varchar(100) DEFAULT NULL
);

select * from MOVIMIENTO

INSERT INTO Movimiento (tipo, remitente, destino, motivo, fecha, monto, direccion_remitente, direccion_destino)
	VALUES
		('INGRESO', 'REMITENTE1', 'REMITENTE2', 'FACTURACION', convert(datetime,'18-06-12 10:34:09 PM',5), 75.000,'Cordoba', 'Cordoba'),
		('EGRESO', 'REMITENTE1', 'REMITENTE2', 'MANTENIMIENTO', convert(datetime,'18-06-12 10:34:09 PM',5), 12000.00,'Buenos Aires', 'Cordoba'),
		('DONACION', 'REMITENTE2', 'REMITENTE3', 'DONACION', convert(datetime,'18-06-12 10:34:09 PM',5), 7000.00,'Cordoba', 'Cordoba'),
		('INGRESO', 'REMITENTE3', 'REMITENTE4', 'FACTURACION', convert(datetime,'18-06-12 10:34:09 PM',5), 24000.00,'Cordoba', 'Cordoba')

UPDATE Movimiento 
SET monto = 75000.00 
WHERE ID = 1

/*--------------------------------------------------------------------------------------ADOPTANTES*/
CREATE TABLE [Adoptantes] (
  id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
  dni int NULL,
  nombre varchar(50) DEFAULT NULL,
  apellido varchar(50) DEFAULT NULL,
  edad int NULL,
  provincia varchar(50) DEFAULT NULL,
  ciudad varchar(50) DEFAULT NULL,
  localidad varchar(50) DEFAULT NULL,
  calificacion varchar(50) DEFAULT NULL,
  en_espera varchar(50) DEFAULT NULL
);

INSERT INTO Adoptantes (dni, nombre, apellido, edad, provincia, ciudad, localidad, calificacion, en_espera)
	VALUES
		(99999111, 'Adoptante1', 'Adoptante1', 47, 'Cordoba', 'Cordoba', 'Capital', NULL, ''),
		(99999111, 'Adoptante2', 'Adoptante2', 21, 'Cordoba', 'Cordoba', 'Capital', 'BAD', ''),
		(99999111, 'Adoptante3', 'Adoptante3', 21, 'Cordoba', 'Cordoba', 'Capital', NULL, ''),
		(99999111, 'Adoptante4', 'Adoptante4', 22, 'Cordoba', 'Cordoba', 'Capital', 'BAD', ''),
		(99999111, 'Adoptante5', 'Adoptante5', 23, 'Cordoba', 'Cordoba', 'Capital', NULL, ''),
		(99999111, 'Adoptante6', 'Adoptante6', 24, 'Cordoba', 'Cordoba', 'Capital', 'BAD', ''),
		(99999111, 'Adoptante7', 'Adoptante7', 29, 'Cordoba', 'Cordoba', 'Capital', 'BAD', ''),
		(99999111, 'Adoptante8', 'Adoptante8', 32, 'Cordoba', 'Cordoba', 'Capital', 'BAD', '');

UPDATE Adoptantes 
SET calificacion = 'GOOD' 
WHERE calificacion = null