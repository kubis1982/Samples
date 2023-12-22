# -------- Przydatne dla EF Core  --------

## Utworzenie nowej migracji
dotnet ef migrations add InitialDb --context EntityFramework.SqlQueries.MyDbContext --output-dir .\SqlQueries\Migrations --project .\EntityFramework\EntityFramework.csproj --startup-project .\EntityFramework\EntityFramework.csproj
## Aktualizacja bazy danych
dotnet ef database update --context EntityFramework.SqlQueries.MyDbContext --project .\EntityFramework\EntityFramework.csproj

