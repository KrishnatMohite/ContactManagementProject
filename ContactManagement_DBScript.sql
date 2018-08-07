
CREATE DATABASE ContactManagement;
GO

use [ContactManagement]


CREATE TABLE [dbo].[MContacts] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (100) NOT NULL,
    [LastName]  NVARCHAR (100) NULL,
    [Email]     VARCHAR (100)  NOT NULL,
    [PhoneNo]   VARCHAR (10)   NOT NULL,
    [Status]    VARCHAR (1)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO

CREATE PROCEDURE [dbo].[USP_DeleteContact]
	@Id int 
AS
begin
	Delete from MContacts where Id = @Id
end

GO

CREATE PROCEDURE [dbo].[USP_GetContact]
	@Id int
AS
begin
	SELECT * from MContacts
	where Id = @Id
end

GO

CREATE PROCEDURE [dbo].[USP_GetContacts]
	
AS
begin
	SELECT * from MContacts
end

GO

CREATE PROCEDURE [dbo].[USP_InsertContact]
	@FirstName VARCHAR(100)
	,@LastName  VARCHAR(100) = null
	,@Email  VARCHAR(100)
	,@PhoneNo  VARCHAR(10)
	,@Status  VARCHAR(1)
AS
BEGIN

	INSERT INTO MContacts (FirstName, LastName, Email, PhoneNo, Status)
	VALUES (@FirstName, @LastName, @Email, @PhoneNo, @Status)

	SELECT SCOPE_IDENTITY();

END

GO

CREATE PROCEDURE [dbo].[USP_UpdateContact]
	@Id INT 
	,@FirstName VARCHAR(100)
	,@LastName  VARCHAR(100) = null
	,@Email  VARCHAR(100)
	,@PhoneNo  VARCHAR(10)
	,@Status  VARCHAR(1)
AS
BEGIN

	UPDATE MContacts
	SET FirstName = @FirstName
		,LastName = @LastName
		,Email = @Email
		,PhoneNo = @PhoneNo
		,Status = @Status
	WHERE Id = @Id

	select @Id;
END

GO