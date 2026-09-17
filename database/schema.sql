-- Creates the database and tables for the attendance app

CREATE DATABASE IF NOT EXISTS attendance_registry;
USE attendance_registry;

CREATE TABLE Students (
    StudentId VARCHAR(20)  NOT NULL,
    FirstName VARCHAR(50)  NOT NULL,
    LastName  VARCHAR(50)  NOT NULL,
    Email     VARCHAR(100),
    PRIMARY KEY (StudentId)
);

CREATE TABLE Classes (
    ClassId   INT          NOT NULL AUTO_INCREMENT,
    ClassCode VARCHAR(20)  NOT NULL,
    ClassName VARCHAR(100) NOT NULL,
    Teacher   VARCHAR(100),
    PRIMARY KEY (ClassId),
    UNIQUE (ClassCode)
);

CREATE TABLE Enrolments (
    EnrolmentId INT         NOT NULL AUTO_INCREMENT,
    StudentId   VARCHAR(20) NOT NULL,
    ClassId     INT         NOT NULL,
    EnrolledOn  DATE        NOT NULL,
    PRIMARY KEY (EnrolmentId),
    UNIQUE (StudentId, ClassId),
    FOREIGN KEY (StudentId) REFERENCES Students (StudentId) ON DELETE CASCADE,
    FOREIGN KEY (ClassId)   REFERENCES Classes (ClassId)    ON DELETE CASCADE
);

CREATE TABLE Attendance (
    AttendanceId   INT         NOT NULL AUTO_INCREMENT,
    StudentId      VARCHAR(20) NOT NULL,
    ClassId        INT         NOT NULL,
    AttendanceDate DATE        NOT NULL,
    IsPresent      BOOLEAN     NOT NULL,
    PRIMARY KEY (AttendanceId),
    FOREIGN KEY (StudentId) REFERENCES Students (StudentId) ON DELETE CASCADE,
    FOREIGN KEY (ClassId)   REFERENCES Classes (ClassId)    ON DELETE CASCADE
);
