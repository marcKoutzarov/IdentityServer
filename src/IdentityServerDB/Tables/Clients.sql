CREATE TABLE [dbo].[Clients]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ClientUserName] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(100) NOT NULL, 
    [Secret] NVARCHAR(MAX) NOT NULL , 
    [EnumTokenType] NVARCHAR(40) NOT NULL, 
	[AccessTokenLifetime] INT NOT NULL DEFAULT 900, 
	[Role] NVARCHAR(40) NOT NULL, 
	[IsActive] BIT NOT NULL, 
    [DateCreated] DATETIME NOT NULL DEFAULT Getdate(), 
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [Updated] DATETIME NOT NULL DEFAULT Getdate(), 
    [UpdatedBy] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Clients_EnumTokenTypes] FOREIGN KEY ([EnumTokenType]) REFERENCES [EnumTokenTypes]([Type]), 
	CONSTRAINT [FK_Clients_EnumClientRoles] FOREIGN KEY ([Role]) REFERENCES [EnumClientRoles]([role]), 
	UNIQUE ([ClientUserName])
)
