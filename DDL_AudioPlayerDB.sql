CREATE DATABASE AudioPlayerDB;
GO

USE AudioPlayerDB;
GO

IF OBJECT_ID('tblUser', 'U') IS NOT NULL DROP TABLE tblUser;
IF OBJECT_ID('tblSong', 'U') IS NOT NULL DROP TABLE tblSong;

CREATE TABLE tblUser (
    ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Username nvarchar(50) NOT NULL,
	Password nvarchar(50) NOT NULL,
);

CREATE TABLE tblSong (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	SongName nvarchar(50) NOT NULL,
	Author nvarchar(50) NOT NULL,
	Duration time,
);