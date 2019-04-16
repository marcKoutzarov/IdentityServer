IDENTITY SERVER 4 .net Core
===================================

Identity Server4 Sample project for persistent storage. 

The testClient requests a reference Token using a ClientResource and a User. 
Then gets the Claims of the User Calling an Api Resource. 

An ORM is not implemented , the data still is pulled from Memory. So your free to write your own Persistante storage logic using any orm.


Projects included in the solution: 

 - IdentitySvr.Core (helper classes)
 - IdentitySvr.Database (Database schema which the poco's in the project rely on)
 - IdentitySvr.Entities (project containing the used poco's models and DTO's)
 - IdentitySvr.Host  (IDENTITY SERVER 4  implementation)
 - IdentitySvr.IdentityServerUI (work in progress. UI to manage the Identity server )
 - IdentitySvr.Interfaces
 - IdentitySvr.Repositories (Still use mock data. U can implement Any desired ORM)
 - TestClient (Console application for testing)
