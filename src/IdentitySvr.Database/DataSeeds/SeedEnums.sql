
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






/* add client */
begin 
INSERT INTO [IdentityServerDB].[dbo].[Clients]
           ([ClientUserName]
           ,[Description]
           ,[Secret]
           ,[AccessTokenType]
           ,[AccessTokenLifetime]
           ,[Role]
           ,[IsActive]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('ManagementConsole' 
           ,'Client used by the Management console'
           ,'secretClientManagementConsole'
           ,'REF'
           ,300
           ,'frontend'
           ,1
           ,'init script'
           ,'init script')

end



/* add API */
INSERT INTO [IdentityServerDB].[dbo].[Apis]
           ([ApiId]
           ,[DisplayName]
           ,[Description]
           ,[ApiSecrets]
           ,[Enabled]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('bankapi'
           ,'Api for Bank resources'
           ,'Add Banknames, Bank branches and bank Accounts'
           ,'bankapisecret'
           ,1
           ,'init script'
           ,'init script')


 /*add api scopes */
 INSERT INTO [IdentityServerDB].[dbo].[ApisScopes] ([ApiID],[Scope],[CreatedBy],[UpdatedBy]) VALUES (1,'read','init','init')
 INSERT INTO [IdentityServerDB].[dbo].[ApisScopes]([ApiID],[Scope],[CreatedBy] ,[UpdatedBy]) VALUES (1,'insert','init','init')
 INSERT INTO [IdentityServerDB].[dbo].[ApisScopes]([ApiID],[Scope],[CreatedBy] ,[UpdatedBy]) VALUES (1,'update','init','init')


/*add Client scopes */
INSERT INTO [IdentityServerDB].[dbo].[ClientsScopes]([ClientID] ,[ApiScopesId],[CreatedBy],[UpdatedBy])  VALUES (1 ,1 ,'init','init')
INSERT INTO [IdentityServerDB].[dbo].[ClientsScopes]([ClientID] ,[ApiScopesId],[CreatedBy],[UpdatedBy])  VALUES (1 ,2 ,'init','init')
INSERT INTO [IdentityServerDB].[dbo].[ClientsScopes]([ClientID] ,[ApiScopesId],[CreatedBy],[UpdatedBy])  VALUES (1 ,3 ,'init','init')



 /*add user */
INSERT INTO [IdentityServerDB].[dbo].[Users]
           ([Username]
           ,[Password]
           ,[AllowedClients]
           ,[GivenName]
           ,[FamilyName]
           ,[Role]
           ,[Email]
           ,[IsActive]
           ,[Salt]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('admin'
           ,'admin123'
           ,'bankapi'
           ,'marc'
           ,'koetsie'
           ,'admin'
           ,'marc@emial.com'
           ,1
           ,'1111'
           ,'init'
           ,'init')




