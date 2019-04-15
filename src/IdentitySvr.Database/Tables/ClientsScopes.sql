CREATE TABLE [dbo].[ClientsScopes]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ClientID] INT NOT NULL, 
    [ApiScopesId] INT NOT NULL,
	[DateCreated] DATETIME NOT NULL DEFAULT Getdate(), 
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [Updated] DATETIME NOT NULL DEFAULT Getdate(), 
    [UpdatedBy] NVARCHAR(50) NOT NULL, 
	CONSTRAINT [FK_ClientsScopes_Clients] FOREIGN KEY ([ClientID]) REFERENCES Clients([ID]),
	CONSTRAINT [FK_ClientsScopes_ApiScopes] FOREIGN KEY ([ApiScopesID]) REFERENCES ApisScopes([ID]),
	CONSTRAINT [UQ_ClientId_ScopeId] UNIQUE NONCLUSTERED
   (
      [ClientID], [ApiScopesID]
   )
)
