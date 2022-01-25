@echo off
set /p args1=Enter Migration Name:
dotnet ef migrations add %args1% -c EntitiesDbContext -s ..\..\Api\Api.csproj -o .\DatabaseContext\Migrations\EntityDb