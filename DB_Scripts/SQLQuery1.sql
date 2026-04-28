CREATE DATABASE SmallWorld;
USE SmallWorld;

CREATE TABLE Roles(
    RoleID INT PRIMARY KEY,
    RoleName NVARCHAR(20) NOT NULL
);

INSERT INTO Roles (RoleID,RoleName)VALUES(1,N'管理者')
INSERT INTO Roles (RoleID,RoleName)VALUES(2,N'VIP')
INSERT INTO Roles (RoleID,RoleName)VALUES(3,N'一般會員')
SELECT*FROM Roles

USE SmallWorld;
GO
CREATE OR ALTER PROCEDURE dbo.usp_RegisterUser
    @Account NVARCHAR(50),
    @Password NVARCHAR(255),
    @UserName NVARCHAR(50),
    @Birthday DATE,
    @Email NVARCHAR(100),
    @RoleID INT

USE SmallWorld;
GO
CREATE TABLE Users(
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Account NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    UserName NVARCHAR(50) NOT NULL,
    Birthday DATE,
    Email NVARCHAR(100),
    CreateTime DATETIME DEFAULT GETDATE(),
    RoleID INT,
    CONSTRAINT FK_User_Role FOREIGN KEY(RoleID) REFERENCES Roles(RoleID)
);

AS
BEGIN

IF EXISTS (SELECT 1 FROM Users WHERE Account = @Account)
    BEGIN
        SELECT -1 AS Result;
    END
    ELSE
    BEGIN
        INSERT INTO Users (Account,Password,UserName,Birthday,Email,RoleID)
        VALUES (@Account,@Password,@UserName,@Birthday,@Email,@RoleID);
        SELECT 1 AS Result;
    END
END

USE SmallWorld
GO
EXEC dbo.usp_RegisterUser
    @Account = 'yao0314',
    @Password = 'a910314560314',
    @UserName = 'yaojjj',
    @Birthday = '2002-03-14',
    @Email = 'a131156136@gmail.com',
    @RoleID = 2;
SELECT*FROM Users;

USE SmallWorld;
GO
CREATE OR ALTER PROCEDURE dbo.usp_LoginUser
    @Account NVARCHAR(50),
    @Password NVARCHAR(255)
AS
BEGIN
    SELECT UserID,UserName,RoleID
    FROM Users
    WHERE Account = @Account AND Password = @Password;
END
GO

CREATE OR ALTER PROCEDURE dbo.usp_UpdatePassword
    @UserID INT,
    @NewPassword NVARCHAR(255)
AS
BEGIN
    UPDATE Users
    SET Password = @NewPassword 
    WHERE UserID = @UserID;
    SELECT 1 AS Result;
END
GO

CREATE OR ALTER PROCEDURE dbo.usp_updateUserInfo
    @UserID INT,
    @UserName NVARCHAR(50),
    @Birthday DATE,
    @Email NVARCHAR(100)
AS
BEGIN
    Update Users
    SET UserName = @UserName,
        Birthday = @Birthday,
        Email = @Email
    WHERE UserID = @UserID;
    SELECT 1 AS Result;
END

GO
CREATE OR ALTER VIEW v_UserRoleList
AS
SELECT 
    U.UserID, 
    U.Account, 
    U.UserName, 
    U.Email, 
    R.RoleName 
FROM Users U
JOIN Roles R ON U.RoleID = R.RoleID;

USE SmallWorld;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Admin_UpdateRole
    @TargetUserID INT,
    @NewRoleID INT
AS
BEGIN
    UPDATE Users
    SET RoleID = @NewRoleID
    WHERE UserID = @TargetUserID;
    SELECT 1 AS Result;
END
GO