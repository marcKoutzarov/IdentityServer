CREATE TABLE [dbo].[Users]
(
	[SubjectId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Username] NVARCHAR(100) NOT NULL,
   	[Password] NVARCHAR(MAX) NOT NULL , 
	[AllowedClients] NVARCHAR(MAX) NOT NULL, 
    [GivenName] NVARCHAR(70) NULL, 
    [FamilyName] NVARCHAR(70) NULL, 
	[Role] NVARCHAR(40) NOT NULL, 
    [Email] NVARCHAR(100) NOT NULL, 
	[IsActive] BIT NOT NULL DEFAULT 1, 
	[Salt] NVARCHAR(MAX) NOT NULL DEFAULT 'defaultSalt', 
	[DateCreated] DATETIME NOT NULL DEFAULT Getdate(), 
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [Updated] DATETIME NOT NULL DEFAULT Getdate(), 
    [UpdatedBy] NVARCHAR(50) NOT NULL, 
	CONSTRAINT [FK_Clients_EnumUsertRoles] FOREIGN KEY ([Role]) REFERENCES [EnumUserRoles]([Role]), 
    UNIQUE (Username)
)
