create database jardines;
use jardines;

/* Tabla usuarios */
drop table if exists usuario;
create table usuario (
	id int not null primary key auto_increment,
    nombre varchar(15) not null,
    apellido varchar(15) not null,
    username varchar(20) not null unique,
    correo varchar(50) not null unique,
    contraseña longtext,
    fecha_nacimiento date,
    fecha_registro datetime,
    pregunta_seguridad text,
    rol enum ('U', 'A')
);
insert into usuario (nombre, apellido, username, correo, contraseña, fecha_nacimiento, fecha_registro, pregunta_seguridad, rol) values ('Emil', 'Solano', 'E1000', 'emilsolano@gmail.com', 'admin12345', '2003-08-16', '2022-07-15 08:03:02', 'Doki', 'A');
insert into usuario (nombre, apellido, username, correo, contraseña, fecha_nacimiento, fecha_registro, pregunta_seguridad, rol) values ('Divanny', 'Perez', 'Divanny', 'divannyjpm@gmail.com', 'admin12345', '2004-06-01', '2022-07-15 08:03:02', 'Chiqui', 'A');
insert into usuario (nombre, apellido, username, correo, contraseña, fecha_nacimiento, fecha_registro, pregunta_seguridad, rol) values ('Ronnie', 'Difo', 'ridifo', 'ridifo@gmail.com', 'admin12345', '2003-10-12', '2022-07-15 08:03:02', 'Toby', 'A');
select * from usuario;

/* Tabla jardines*/
drop table if exists jardines;
create table jardines (
	id int primary key auto_increment,
    titulo_jardin varchar(30) not null,
    descripcion_jardin text,
    precio varchar(40),
    ubicacion text,
    gama varchar (10) not null,
    maximo_de_personas int,
    titulo_imagen text
);
describe jardines;
select * from jardines;

/* Tabla reservas */
drop table if exists reservas;
create table reservas (
	id int primary key auto_increment,
	id_usuario int not null,
	id_jardines int not null,
	fecha_reserva date,
	cantidad_personas int,
	hora_inicio time, 
	hora_cierre time
);
describe reservas;
select * from reservas;

/* Consultas usados en el programa */
select titulo_jardin, descripcion_jardin, precio, ubicacion, fecha_reserva, cantidad_personas, hora_inicio, hora_cierre, titulo_imagen from jardines join reservas on jardines.id = reservas.id_jardines and reservas.id_usuario = 5;
select titulo_jardin, descripcion_jardin, precio, ubicacion, fecha_reserva, cantidad_personas, hora_inicio, hora_cierre from jardines join reservas on jardines.id = reservas.id_jardines and reservas.id_usuario = 4;
select count(id) from reservas where fecha_reserva = '2022-08-20' and id_jardines = 1;
update reservas set id_jardines = (select id from jardines where titulo_jardin = '{0}'), id_usuario = (select id from usuario where username = '{1}'), fecha_reserva = '', cantidad_personas = 2, hora_inicio = '', hora_cierre = ''  where id = 2;
update jardines set descripcion_jardin = "ad", precio = "2", ubicacion = "sda", gama = "media", maximo_de_personas = 2, titulo_imagen = "" where id = 3;
select titulo_jardin, descripcion_jardin, precio, ubicacion, fecha_reserva, cantidad_personas, hora_inicio, hora_cierre, titulo_imagen from reservas join jardines on jardines.id = reservas.id_jardines where id_usuario = 6;
