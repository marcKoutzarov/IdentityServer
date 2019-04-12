

BEGIN
IF NOT EXISTS (select ID FROM [IdentityServerDB].[dbo].[EnumRoles] WHERE [Role]='user' )
INSERT INTO [IdentityServerDB].[dbo].[EnumRoles]
           ([Role]
           ,[Description]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('user', 'An human user.', 'init script','init script')
END


BEGIN
IF NOT EXISTS (select ID FROM [IdentityServerDB].[dbo].[EnumRoles] WHERE [Role]='admin' )
INSERT INTO [IdentityServerDB].[dbo].[EnumRoles]
           ([Role]
           ,[Description]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('admin', 'God mode.', 'init script','init script')
END

BEGIN
IF NOT EXISTS (select ID FROM [IdentityServerDB].[dbo].[EnumRoles] WHERE [Role]='appl' )
INSERT INTO [IdentityServerDB].[dbo].[EnumRoles]
           ([Role]
           ,[Description]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('appl', 'An application.', 'init script','init script')
END

BEGIN
IF NOT EXISTS (select ID FROM [IdentityServerDB].[dbo].[EnumRoles] WHERE [Role]='opco' )
INSERT INTO [IdentityServerDB].[dbo].[EnumRoles]
           ([Role]
           ,[Description]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('opco', 'Operational company.', 'init script','init script')
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
IF NOT EXISTS (select ID FROM [IdentityServerDB].[dbo].[EnumScopes] WHERE [Scope]='read' )
INSERT INTO [IdentityServerDB].[dbo].[EnumScopes]
           ([Scope]
           ,[Description]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('read', 'Read permission', 'init script','init script')
END


BEGIN
IF NOT EXISTS (select ID FROM [IdentityServerDB].[dbo].[EnumScopes] WHERE [Scope]='write' )
INSERT INTO [IdentityServerDB].[dbo].[EnumScopes]
           ([Scope]
           ,[Description]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('write', 'Write permission', 'init script','init script')
END


BEGIN
IF NOT EXISTS (select ID FROM [IdentityServerDB].[dbo].[EnumScopes] WHERE [Scope]='aprove' )
INSERT INTO [IdentityServerDB].[dbo].[EnumScopes]
           ([Scope]
           ,[Description]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('aprove', '4 eye aproval permission', 'init script','init script')
END








