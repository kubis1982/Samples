## Utworzenie nowej migracji
dotnet ef migrations add InitialDb --context SqliteDbContext --project .\EntityFramework\EntityFramework.csproj --output-dir .\Sqlite\Migrations
## Aktualizacja bazy danych
dotnet ef database update --context SqliteDbContext --project .\EntityFramework\EntityFramework.csproj