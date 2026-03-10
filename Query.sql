DROP TABLE IF EXISTS admins;
DROP TABLE IF EXISTS teachers;
DROP TABLE IF EXISTS students;
DROP TABLE IF EXISTS sections;
DROP TABLE IF EXISTS subjects;
DROP TABLE IF EXISTS enrollments;
DROP TABLE IF EXISTS attendances;

CREATE TABLE admins(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	AdminName VARCHAR(50),
	AdminPassword VARCHAR(50),
	AdminDescription VARCHAR(225),
	Active BIT,
	);

CREATE TABLE students(
	Id INT Identity(1,1) Primary Key,
	StudentName Varchar(50),
	DateOfBirth DATE,
	Gender Varchar(10),
	Phone Varchar(15),
	Email Varchar(50),
	Active BIT
	);

CREATE TABLE teachers(
	Id Int Identity(1,1) Primary Key,
	TeacherName Varchar(50),
	Gender Varchar(10),
	Phone Varchar(15),
	Section Varchar(50),
	Active Bit
	);

CREATE TABLE sections(
	Id Int Identity(1,1) Primary Key,
	Section Varchar(50),
	StudentName Varchar(50),
	SubjectName Varchar(50),
	SectionDescription Varchar(225)
	);

CREATE TABLE subjects(
	Id INT Identity(1,1) Primary key,
	SubjectName Varchar(50),
	SectionName Varchar(50)
	);

CREATE TABLE enrollments(
	Id Int Identity(1,1) Primary key,
	StudenName Varchar(50),
	SectionName Varchar(50),
	EnrollDate Date,
	);

CREATE TABLE attendances(
	Id Int Identity(1,1) Primary Key,
	StudentName Varchar(50),
	Student Varchar(50)
	);