CREATE TABLE [dbo].[ApisScopes]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ApiID] INT NOT NULL, 
    [ScopeEnumId] INT NOT NULL,
	[DateCreated] DATETIME NOT NULL DEFAULT Getdate(), 
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [Updated] DATETIME NOT NULL DEFAULT Getdate(), 
    [UpdatedBy] NVARCHAR(50) NOT NULL,
	CONSTRAINT [FK_ApisScopes_Apis] FOREIGN KEY ([ApiID]) REFERENCES Apis([ID]),
	CONSTRAINT [FK_ApisScopes_EnumScopes] FOREIGN KEY ([ScopeEnumId]) REFERENCES EnumScopes([ID])
)
