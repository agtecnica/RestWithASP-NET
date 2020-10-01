CREATE SEQUENCE  IF NOT EXISTS Book_seq;

CREATE TABLE IF NOT EXISTS Book (
  id  INT DEFAULT NEXTVAL ('Book_seq') PRIMARY KEY,
  author varchar(200) NOT NULL,
  launchdate timestamp NOT NULL,
  price decimal(18,2) NOT NULL,
  title varchar(100) NULL
);
