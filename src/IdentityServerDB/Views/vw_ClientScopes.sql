CREATE VIEW [dbo].[vw_ClientScopes]
AS 

SELECT 
dbo.ClientsScopes.ID AS ScopeId, 
dbo.Clients.ClientUserName AS Client, 
dbo.Apis.ApiId AS Api, 
dbo.Apis.ApiId + N'.' + dbo.ApisScopes.Scope AS Scope
FROM   
dbo.ClientsScopes INNER JOIN
dbo.Clients ON dbo.ClientsScopes.ClientID = dbo.Clients.ID INNER JOIN
dbo.ApisScopes ON dbo.ClientsScopes.ApiScopesId = dbo.ApisScopes.ID INNER JOIN
dbo.Apis ON dbo.ApisScopes.ApiID = dbo.Apis.ID


