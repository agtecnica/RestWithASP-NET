CREATE SEQUENCE  IF NOT EXISTS Person_seq;

CREATE TABLE IF NOT EXISTS Person(
	id INT DEFAULT NEXTVAL ('Person_seq') PRIMARY KEY,
	firstname varchar(50) NOT NULL,
	lastname varchar(50)  NULL,
	address varchar(500)  NULL,
	gender varchar(20)  NULL
);
