CREATE TABLE [dbo].[EnumTokenTypes]
(
    [ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Type] NVARCHAR(40) NOT NULL, 
    [Description] NVARCHAR(100) NOT NULL, 
    [DateCreated] DATETIME NOT NULL DEFAULT Getdate(), 
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [Updated] DATETIME NOT NULL DEFAULT Getdate(), 
    [UpdatedBy] NVARCHAR(50) NOT NULL,
	UNIQUE (Type)
)
