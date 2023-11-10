# -------- Przydatne dla EF Core  --------

## Utworzenie nowej migracji
dotnet ef migrations add InitialDb --context EntityFramework.TPH.MyDbContext --output-dir .\TPH\Migrations --project .\EntityFramework\EntityFramework.csproj --startup-project .\EntityFramework\EntityFramework.csproj
## Aktualizacja bazy danych
dotnet ef database update --context EntityFramework.TPH.MyDbContext --project .\EntityFramework\EntityFramework.csproj

