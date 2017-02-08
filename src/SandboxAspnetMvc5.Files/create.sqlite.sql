/*
//------------------------------------------------------------------------------
/// File       : create.sqlite.sql
/// Version    : 0.1
/// Created    : 2017-02-06
/// Modified   : 2017-02-07
///
/// Author     : William Chang
/// Email      : william@babybluebox.com
/// Website    : http://williamchang.org
///
/// Compatible : SQLite 3
//------------------------------------------------------------------------------
/// References:
/// https://www.tutorialspoint.com/sqlite/sqlite_data_types.htm
/// http://techreadme.blogspot.com/2012/11/sqlite-read-write-datetime-values-using.html
//------------------------------------------------------------------------------
*/

/* Code Snippets
//----------------------------------------------------------------------------*/
/*

Storage Classes
null
integer
real
text
blob

Data Types By Popularity
datetime
boolean

Get Current Date and Time (YYYY-MM-DD HH:MM:SS) for System.DateTime compatibility
datetime('now')

Get Current Date and Time (YYYY-MM-DD HH:MM:SS.SSS) for System.DateTime compatibility
strftime('%Y-%m-%d %H:%M:%f', 'now')
strftime('%Y-%m-%d %H:%M:%f', 'now', 'utc')
strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime')

Get Current Unix Timestamp aka Unix Epoch
strftime('%s', 'now')

Use Data Type for System.Guid (separated by hyphens, lowercase, no enclosed curly braces)
text

*/

/* Create Tables (columns are default "null" and primary keys are default "clustered")
//----------------------------------------------------------------------------*/
CREATE TABLE SystemSetting (
    Id text not null,
    ApplicationName text not null,
    Name text not null,
    Value text not null,
    DateModified datetime not null,
    PRIMARY KEY (Id)
);
INSERT INTO SystemSetting (Id, ApplicationName, Name, Value, DateModified) VALUES ('9e90c293-98c0-4ddc-b18c-4993a71d08ab', 'DefaultApplication', 'YourGroupName.YourKey1', 'YourValue1', strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime'));
INSERT INTO SystemSetting (Id, ApplicationName, Name, Value, DateModified) VALUES ('31adab0a-afdb-4a4e-b1ea-d11bd7fcf0a2', 'DefaultApplication', 'YourGroupName.YourKey2', 'YourValue2', strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime'));
INSERT INTO SystemSetting (Id, ApplicationName, Name, Value, DateModified) VALUES ('c92199a1-a4d0-413b-9d51-254756357ec5', 'DefaultApplication', 'YourGroupName.YourKey3', 'YourValue3', strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime'));

CREATE TABLE SystemLog (
    Id integer not null,
    DateCreated datetime not null,
    Thread text not null,
    Level text not null,
    Logger text not null,
    Message text not null,
    Exception text not null,
    PRIMARY KEY (Id)
);
INSERT INTO SystemLog (DateCreated, Thread, Level, Logger, Message, Exception) VALUES (strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime'), '0', 'Debug', 'DefaultLogger', 'YourMessage1', 'YourException1');
INSERT INTO SystemLog (DateCreated, Thread, Level, Logger, Message, Exception) VALUES (strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime'), '0', 'Debug', 'DefaultLogger', 'YourMessage2', 'YourException2');
INSERT INTO SystemLog (DateCreated, Thread, Level, Logger, Message, Exception) VALUES (strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime'), '0', 'Debug', 'DefaultLogger', 'YourMessage3', 'YourException3');

CREATE TABLE SystemSession (
    Id text not null,
    ApplicationName text not null,
    DateCreated datetime not null,
    DateExpire datetime not null,
    DateLock datetime not null,
    LockId integer not null,
    Timeout integer not null,
    IsLocked boolean not null,
    Value text not null,
    Flag integer not null,
    PRIMARY KEY (Id)
);

CREATE TABLE UserAccount (
    Id text not null,
    ApplicationName text not null,
    RoleName text not null,
    Alias text not null,
    NameFirst text not null,
    NameMiddle text not null,
    NameLast text not null,
    Email text not null,
    SessionKey text not null,
    DateSessionCreated datetime not null,
    DateActive datetime not null,
    DateCreated datetime not null,
    IsAnonymous boolean not null,
    IsDeleted boolean not null,
    PRIMARY KEY (Id)
);

CREATE TABLE UserCredential (
    Id text not null,
    UserAccountId text not null,
    Password nvarchar(255) not null,
    PasswordFormat integer not null,
    PasswordSalt text not null,
    ActivationKey text not null,
    IsActivated boolean not null,
    IsLockedOut boolean not null,
    FailedAttemptCount integer not null,
    DateFailedAttempt text not null,
    DateLogin text not null,
    DatePasswordChanged text not null,
    DateLockout text not null,
    PRIMARY KEY (Id),
    FOREIGN KEY (UserAccountId) REFERENCES UserAccount (Id) ON DELETE CASCADE ON UPDATE NO ACTION
);

CREATE TABLE UserProfile (
    Id text not null,
    UserAccountId text not null,
    Type integer not null,
    Subtype int not null,
    Label text not null,
    Value text not null,
    DateModified datetime not null,
    PRIMARY KEY (Id),
    FOREIGN KEY (UserAccountId) REFERENCES UserAccount (Id) ON DELETE CASCADE ON UPDATE NO ACTION
);

CREATE TABLE UserSetting (
    Id text not null,
    UserAccountId text not null,
    Name text not null,
    Value text not null,
    DateModified datetime not null,
    PRIMARY KEY (Id),
    FOREIGN KEY (UserAccountId) REFERENCES UserAccount (Id) ON DELETE CASCADE ON UPDATE NO ACTION
);

/* Create Views
//----------------------------------------------------------------------------*/
