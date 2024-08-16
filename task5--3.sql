--create table tb_task5
--(
-- Id int identity(1,1) primary key,
-- Name varchar(50) ,
-- Mobile varchar(20),
-- Email varchar(30),
-- State varchar(50),
-- City varchar(50));
-- create table task5state
-- (
-- StateId varchar(50),
-- StateName varchar(50));
-- create table task5city
-- (
-- CityId varchar(50),
-- CityName varchar(50),
-- StateId varchar(50) reference
 -- Create the table to store tasks
CREATE TABLE tb_task5
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50),
    Mobile VARCHAR(20),
    Email VARCHAR(30),
    StateId VARCHAR(50),  
    CityId VARCHAR(50),     
    FOREIGN KEY (StateId) REFERENCES task5state(StateId),
    FOREIGN KEY (CityId) REFERENCES task5city(CityId)
);

-- Create the table to store states
CREATE TABLE task5state
(
    StateId VARCHAR(50) PRIMARY KEY,
    StateName VARCHAR(50) NOT NULL
);

-- Create the table to store cities with a reference to the state
CREATE TABLE task5city
(
    CityId VARCHAR(50) PRIMARY KEY,
    CityName VARCHAR(50) NOT NULL,
    StateId VARCHAR(50) NOT NULL,
    FOREIGN KEY (StateId) REFERENCES task5state(StateId)
);




 
 
