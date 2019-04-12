CREATE TABLE [dbo].[Clients]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ClientId] NVARCHAR(100) NOT NULL, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(100) NOT NULL, 
    [Secret] NVARCHAR(100) NOT NULL, 
    [Enabled] BIT NOT NULL , 
    [EnumTokenTypeId] INT NOT NULL, 
	[AccessTokenLifetime] INT NOT NULL DEFAULT 900, 
    [DateCreated] DATETIME NOT NULL DEFAULT Getdate(), 
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [Updated] DATETIME NOT NULL DEFAULT Getdate(), 
    [UpdatedBy] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Clients_EnumTokenTypes] FOREIGN KEY ([EnumTokenTypeId]) REFERENCES [EnumTokenTypes]([ID]), 
	UNIQUE (clientId)
)
