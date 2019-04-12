IDENTITY SERVER 4 .net Core
===================================

Project contains 2 sollutions. 

1. An in-memory implementation of IdentityServer4.
2. A pesistant storage implementation of IdentityServer4 (in proggress).

Both sollutions include one test-client: requesting a referance token (RequestClientCredentialsToken) from the server and swapping it for a claim token (IntrospectionResponse) using the Api resource. 

Sample database project (IdentityServerDB) contains the minimal schema to store all clients, claims,scopes & recources. The database minimalistic and is much smaller then the official Identity server schema.

