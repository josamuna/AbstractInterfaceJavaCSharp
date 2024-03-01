-- SQL Server

--drop database db_person
--go
 
create database db_person
go

use db_person
go


create table employee (
	id int ,
	firstName varchar(100) not null,
	lastName varchar(100) not null,
	cnss varchar(100),
	constraint pk_employee primary key(id)
)
go

create table student (
	id int,
	firstName varchar(100) not null,
	lastName varchar(100) not null,
	rollNumber varchar(100),
	constraint pk_student primary key(id)
)
go


-- MySQL
create database db_person;

create table employee (
	id int primary key,
	firstName varchar(100) not null,
	lastName varchar(100) not null,
	cnss varchar(100)
);

create table student (
	id int primary key,
	firstName varchar(100) not null,
	lastName varchar(100) not null,
	rollNumber varchar(100)
);
