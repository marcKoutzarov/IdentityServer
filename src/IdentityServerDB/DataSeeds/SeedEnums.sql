
BEGIN
IF NOT EXISTS (select ID FROM [IdentityServerDB].[dbo].[EnumClientRoles] WHERE [Role]='frontend' )
INSERT INTO [IdentityServerDB].[dbo].[EnumClientRoles]
           ([Role]
           ,[Description]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('frontend', 'A frontend application.', 'init script','init script')
END
BEGIN
IF NOT EXISTS (select ID FROM [IdentityServerDB].[dbo].[EnumClientRoles] WHERE [Role]='api' )
INSERT INTO [IdentityServerDB].[dbo].[EnumClientRoles]
           ([Role]
           ,[Description]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('api', 'An webapi application.', 'init script','init script')
END
BEGIN
IF NOT EXISTS (select ID FROM [IdentityServerDB].[dbo].[EnumClientRoles] WHERE [Role]='internal' )
INSERT INTO [IdentityServerDB].[dbo].[EnumClientRoles]
           ([Role]
           ,[Description]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('internal', 'An internal user', 'init script','init script')
END
BEGIN
IF NOT EXISTS (select ID FROM [IdentityServerDB].[dbo].[EnumClientRoles] WHERE [Role]='service' )
INSERT INTO [IdentityServerDB].[dbo].[EnumClientRoles]
           ([Role]
           ,[Description]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('service', 'A service application.', 'init script','init script')
END








BEGIN
IF NOT EXISTS (select ID FROM [IdentityServerDB].[dbo].[EnumUserRoles] WHERE [Role]='customer' )
INSERT INTO [IdentityServerDB].[dbo].[EnumUserRoles]
           ([Role]
           ,[Description]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('customer', 'A customer using the application', 'init script','init script')
END
BEGIN
IF NOT EXISTS (select ID FROM [IdentityServerDB].[dbo].[EnumUserRoles] WHERE [Role]='employee' )
INSERT INTO [IdentityServerDB].[dbo].[EnumUserRoles]
           ([Role]
           ,[Description]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('employee', 'A employee using the application', 'init script','init script')
END
BEGIN
IF NOT EXISTS (select ID FROM [IdentityServerDB].[dbo].[EnumUserRoles] WHERE [Role]='admin' )
INSERT INTO [IdentityServerDB].[dbo].[EnumUserRoles]
           ([Role]
           ,[Description]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('admin', 'administrator', 'init script','init script')
END










BEGIN
IF NOT EXISTS (select ID FROM [IdentityServerDB].[dbo].[EnumTokenTypes] WHERE [Type]='JWT' )
INSERT INTO [IdentityServerDB].[dbo].[EnumTokenTypes]
           ([Type]
           ,[Description]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('JWT', 'A JWT token.', 'init script','init script')
END

BEGIN
IF NOT EXISTS (select ID FROM [IdentityServerDB].[dbo].[EnumTokenTypes] WHERE [Type]='REF' )
INSERT INTO [IdentityServerDB].[dbo].[EnumTokenTypes]
           ([Type]
           ,[Description]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('REF', 'A reference token.', 'init script','init script')
END



BEGIN
IF NOT EXISTS (select ID FROM [IdentityServerDB].[dbo].[EnumApiScopes] WHERE [Scope]='read' )
INSERT INTO [IdentityServerDB].[dbo].[EnumApiScopes]
           ([Scope]
           ,[Description]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('read', 'Read permission', 'init script','init script')
END

BEGIN
IF NOT EXISTS (select ID FROM [IdentityServerDB].[dbo].[EnumApiScopes] WHERE [Scope]='insert' )
INSERT INTO [IdentityServerDB].[dbo].[EnumApiScopes]
           ([Scope]
           ,[Description]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('insert', 'Read permission', 'init script','init script')
END

BEGIN
IF NOT EXISTS (select ID FROM [IdentityServerDB].[dbo].[EnumApiScopes] WHERE [Scope]='update' )
INSERT INTO [IdentityServerDB].[dbo].[EnumApiScopes]
           ([Scope]
           ,[Description]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('update', 'Read permission', 'init script','init script')
END