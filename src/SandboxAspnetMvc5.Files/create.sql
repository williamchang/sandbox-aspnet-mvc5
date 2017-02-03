/*
//------------------------------------------------------------------------------
/// File       : create.sql
/// Version    : 0.2
/// Created    : 2015-08-20
/// Modified   : 2016-10-22
///
/// Author     : William Chang
/// Email      : william@babybluebox.com
/// Website    : http://williamchang.org
///
/// Compatible : Microsoft SQL Server 2014 or 12+
//------------------------------------------------------------------------------
/// References:
/// http://www.techonthenet.com/sql/tables/create_table.php
/// http://www.1keydata.com/sql/sqlcreate.html
/// http://www.1keydata.com/sql/sql-foreign-key.html
/// http://www.w3schools.com/SQL/sql_view.asp
/// http://www.techonthenet.com/sql/views.php
//------------------------------------------------------------------------------
*/

/* Code Snippets
//----------------------------------------------------------------------------*/
/*

Create GUID
NEWID()

Create GUID, Only for DEFAULT Clause of Table
NEWSEQUENTIALID()

Get Current Date and Time
GETDATE()

Use Data Type for System.DateTime.MinValue and range from 0001-01-01 through 9999-12-31
datetime2

Create View
CREATE VIEW view_name AS
SELECT columns FROM table WHERE condition

Update View
CREATE OR REPLACE VIEW view_name AS
SELECT columns FROM table WHERE condition

Query View
SELECT * FROM view_name;

Drop View
DROP VIEW view_name;

Add Primary Key
ALTER TABLE dbo.UserProfile ADD CONSTRAINT PK_UserProfileId PRIMARY KEY CLUSTERED (Id);
ALTER TABLE dbo.UserProfile ADD CONSTRAINT PK_UserProfileId PRIMARY KEY NONCLUSTERED (Id);

Add Foreign Key
ALTER TABLE dbo.UserProfile ADD CONSTRAINT FK_UserProfile_User FOREIGN KEY (UserId) REFERENCES dbo.User (Id);

Drop Constraint
ALTER TABLE dbo.UserProfile DROP CONSTRAINT PK_UserProfileId;
ALTER TABLE dbo.UserProfile DROP CONSTRAINT FK_UserProfile_User;

Stored Procedure Naming Convention
usp_SelectPerson
usp_InsertPerson
usp_UpdatePerson
usp_DeletePerson

*/

/* Create Database
//----------------------------------------------------------------------------*/
CREATE DATABASE Sandbox;
GO

/* Use Database
//----------------------------------------------------------------------------*/
USE Sandbox;
GO

/* Create Tables (columns are default "null" and primary keys are default "clustered")
//----------------------------------------------------------------------------*/
CREATE TABLE SystemSetting (
    Id uniqueidentifier not null,
    ApplicationName nvarchar(255) not null,
    Name nvarchar(255) not null,
    Value nvarchar(510) not null,
    DateModified datetime2 not null
);
ALTER TABLE SystemSetting ADD CONSTRAINT PK_SystemSetting_Id PRIMARY KEY NONCLUSTERED (Id);
INSERT INTO SystemSetting (Id, ApplicationName, Name, Value, DateModified) VALUES (NEWID(), 'DefaultApplication', 'YourGroupName.YourKey1', 'YourValue1', GETDATE());
INSERT INTO SystemSetting (Id, ApplicationName, Name, Value, DateModified) VALUES (NEWID(), 'DefaultApplication', 'YourGroupName.YourKey2', 'YourValue2', GETDATE());
INSERT INTO SystemSetting (Id, ApplicationName, Name, Value, DateModified) VALUES (NEWID(), 'DefaultApplication', 'YourGroupName.YourKey3', 'YourValue3', GETDATE());

CREATE TABLE SystemLog (
    Id int not null IDENTITY(1,1),
    DateCreated datetime2 not null,
    Thread nvarchar(255) not null,
    Level nvarchar(50) not null,
    Logger nvarchar(255) not null,
    Message nvarchar(max) not null,
    Exception nvarchar(max) not null
);
ALTER TABLE SystemLog ADD CONSTRAINT PK_SystemLog_Id PRIMARY KEY CLUSTERED (Id);
INSERT INTO SystemLog (DateCreated, Thread, Level, Logger, Message, Exception) VALUES (GETDATE(), '0', 'Debug', 'DefaultLogger', 'YourMessage1', 'YourException1');
INSERT INTO SystemLog (DateCreated, Thread, Level, Logger, Message, Exception) VALUES (GETDATE(), '0', 'Debug', 'DefaultLogger', 'YourMessage2', 'YourException2');
INSERT INTO SystemLog (DateCreated, Thread, Level, Logger, Message, Exception) VALUES (GETDATE(), '0', 'Debug', 'DefaultLogger', 'YourMessage3', 'YourException3');

CREATE TABLE SystemSession (
    Id nvarchar(80) not null,
    ApplicationName nvarchar(255) not null,
    DateCreated datetime2 not null,
    DateExpire datetime2 not null,
    DateLock datetime2 not null,
    LockId int not null,
    Timeout int not null,
    IsLocked bit not null,
    Value nvarchar(max) not null,
    Flag int not null
);
ALTER TABLE SystemSession ADD CONSTRAINT PK_SystemSession PRIMARY KEY NONCLUSTERED (Id, ApplicationName);

CREATE TABLE UserAccount (
    Id uniqueidentifier not null,
    ApplicationName nvarchar(255) not null,
    RoleName nvarchar(255) not null,
    Alias nvarchar(255) not null,
    NameFirst nvarchar(255) not null,
    NameMiddle nvarchar(255) not null,
    NameLast nvarchar(255) not null,
    Email nvarchar(255) not null,
    SessionKey nvarchar(255) not null,
    DateSessionCreated datetime2 not null,
    DateActive datetime2 not null,
    DateCreated datetime2 not null,
    IsAnonymous bit not null,
    IsDeleted bit not null
);
ALTER TABLE UserAccount ADD CONSTRAINT PK_UserAccount_Id PRIMARY KEY NONCLUSTERED (Id);

CREATE TABLE UserCredential (
    Id uniqueidentifier not null,
    UserAccountId uniqueidentifier not null,
    Password nvarchar(255) not null,
    PasswordFormat int not null,
    PasswordSalt nvarchar(255) not null,
    ActivationKey nvarchar(255) not null,
    IsActivated bit not null,
    IsLockedOut bit not null,
    FailedAttemptCount int not null,
    DateFailedAttempt datetime2 not null,
    DateLogin datetime2 not null,
    DatePasswordChanged datetime2 not null,
    DateLockout datetime2 not null
);
ALTER TABLE UserCredential ADD CONSTRAINT PK_UserCredential_Id PRIMARY KEY NONCLUSTERED (Id);
ALTER TABLE UserCredential ADD CONSTRAINT FK_UserCredential_UserAccount FOREIGN KEY (UserAccountId) REFERENCES UserAccount (Id);

CREATE TABLE UserProfile (
    Id uniqueidentifier not null,
    UserAccountId uniqueidentifier not null,
    Type int not null,
    Subtype int not null,
    Label nvarchar(255) not null,
    Value nvarchar(255) not null,
    DateModified datetime2 not null
);
ALTER TABLE UserProfile ADD CONSTRAINT PK_UserProfile_Id PRIMARY KEY NONCLUSTERED (Id);

CREATE TABLE UserSetting (
    Id uniqueidentifier not null,
    UserAccountId uniqueidentifier not null,
    Name nvarchar(255) not null,
    Value nvarchar(255) not null,
    DateModified datetime2 not null
);
ALTER TABLE UserSetting ADD CONSTRAINT PK_UserSetting_Id PRIMARY KEY NONCLUSTERED (Id);

/* Create Views
//----------------------------------------------------------------------------*/
