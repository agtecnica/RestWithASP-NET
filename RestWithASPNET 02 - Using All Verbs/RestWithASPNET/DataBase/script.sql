CREATE TABLE Person(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50)  NULL,
	Address varchar(500)  NULL,
	Gender varchar(20)  NULL,
)


/*
--PostgresSql
create sequence Person_seq;

create table Person(
Id INT DEFAULT NEXTVAL ('Person_seq') PRIMARY KEY,
FirstName varchar(50) NOT NULL,
LastName varchar(50)  NULL,
Address varchar(500)  NULL,
Gender varchar(20)  NULL
);
*/