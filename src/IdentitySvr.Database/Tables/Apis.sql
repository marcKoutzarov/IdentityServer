CREATE TABLE [dbo].[Apis]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ApiId] NVARCHAR(100) NOT NULL, 
    [DisplayName] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(50) NOT NULL, 
    [ApiSecrets] NVARCHAR(100) NOT NULL, 
	[Enabled] BIT NOT NULL DEFAULT 1, 
    [DateCreated] DATETIME NOT NULL DEFAULT Getdate(), 
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [Updated] DATETIME NOT NULL DEFAULT Getdate(), 
    [UpdatedBy] NVARCHAR(50) NOT NULL,
	UNIQUE (ApiId)
)
