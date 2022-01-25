@echo off
dotnet ef database update -c ApplicationDbContext -s ..\..\Api\Api.csproj
echo Done Updating ApplicationDbContext
dotnet ef database update -c ConfigurationDbContext -s ..\..\Api\Api.csproj
echo Done Updating ConfigurationDbContext
dotnet ef database update -c PersistedGrantDbContext -s ..\..\Api\Api.csproj
echo Done Updating PersistedGrantDbContext
dotnet ef database update -c EntitiesDbContext -s ..\..\Api\Api.csproj
echo Done Updating EntityDbContext
echo Done Updating all DbContexts!