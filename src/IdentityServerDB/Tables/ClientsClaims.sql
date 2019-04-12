CREATE TABLE [dbo].[ClientsClaims]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ClientID] INT NOT NULL, 
    [JwtName] NVARCHAR(255) NOT NULL,
	[JwtEmail] NVARCHAR(255) NOT NULL,
	[EnumRoleId] INT NOT NULL,
	[DateCreated] DATETIME NOT NULL DEFAULT Getdate(), 
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [Updated] DATETIME NOT NULL DEFAULT Getdate(), 
    [UpdatedBy] NVARCHAR(50) NOT NULL
	CONSTRAINT [FK_ClientsClaims_Clients] FOREIGN KEY ([ClientID]) REFERENCES Clients([ID])
)
