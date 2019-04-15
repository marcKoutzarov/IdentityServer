CREATE VIEW [dbo].[vw_ApiScopes]
	AS 
	SELECT 
	dbo.ApisScopes.ID AS ScopeId, 
	dbo.Apis.ApiId AS Api, 
	dbo.Apis.ApiId + N'.' + dbo.ApisScopes.Scope AS Scope
	FROM 
	dbo.Apis INNER JOIN dbo.ApisScopes ON dbo.Apis.ID = dbo.ApisScopes.ApiID
	
